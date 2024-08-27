using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using Color = UnityEngine.Color;

public class Matrix : MonoBehaviour
{
    public int boardWidth;
    public int boardHeight;
    public int boardDepth;
    public int boardQuor;
    public int mineCount;
    public bool Is4D;
    private int[,,,] matrix;

    public GameObject CellPrefab;
    private int minePosCount;
    public struct Vector4Int
    {
        public int x, y, z, w;

        public Vector4Int(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        matrix = new int[boardWidth, boardHeight, boardDepth, boardQuor];

        while (minePosCount < mineCount)
        {
            int x = Random.Range(0, boardWidth);
            int y = Random.Range(0, boardHeight);
            int z = Random.Range(0, boardDepth);
            int w = Random.Range(0, boardQuor);
            if (matrix[x, y, z, w] != 1)
            {
                minePosCount++;
                matrix[x, y, z, w] = 1;
            }
        }
        Vector4Int[] mineOffset = new Vector4Int[] {
        new Vector4Int(-1,  0,  0,  0), // Left
        new Vector4Int( 1,  0,  0,  0), // Right
        new Vector4Int( 0, -1,  0,  0), // Down
        new Vector4Int( 0,  1,  0,  0), // Up
        new Vector4Int( 0,  0, -1,  0), // Back
        new Vector4Int( 0,  0,  1,  0), // Forward
        new Vector4Int( 0,  0,  0, -1), // Before
        new Vector4Int( 0,  0,  0,  1), // After
        new Vector4Int(-1, -1,  0,  0), // Bottom-left
        new Vector4Int(-1,  1,  0,  0), // Top-left
        new Vector4Int( 1, -1,  0,  0), // Bottom-right
        new Vector4Int( 1,  1,  0,  0), // Top-right
        new Vector4Int(-1,  0, -1,  0), // Left-back
        new Vector4Int(-1,  0,  1,  0), // Left-forward
        new Vector4Int( 1,  0, -1,  0), // Right-back
        new Vector4Int( 1,  0,  1,  0), // Right-forward
        new Vector4Int(-1,  0,  0, -1), // Left-before
        new Vector4Int(-1,  0,  0,  1), // Left-after
        new Vector4Int( 1,  0,  0, -1), // Right-before
        new Vector4Int( 1,  0,  0,  1), // Right-after
        new Vector4Int( 0, -1, -1,  0), // Down-back
        new Vector4Int( 0, -1,  1,  0), // Down-forward
        new Vector4Int( 0,  1, -1,  0), // Up-back
        new Vector4Int( 0,  1,  1,  0), // Up-forward
        new Vector4Int( 0,  0, -1, -1), // Back-before
        new Vector4Int( 0,  0, -1,  1), // Back-after
        new Vector4Int( 0,  0,  1, -1), // Forward-before
        new Vector4Int( 0,  0,  1,  1), // Forward-after
        new Vector4Int(-1, -1, -1,  0), // Bottom-left-back
        new Vector4Int(-1, -1,  1,  0), // Bottom-left-forward
        new Vector4Int(-1,  1, -1,  0), // Top-left-back
        new Vector4Int(-1,  1,  1,  0), // Top-left-forward
        new Vector4Int( 1, -1, -1,  0), // Bottom-right-back
        new Vector4Int( 1, -1,  1,  0), // Bottom-right-forward
        new Vector4Int( 1,  1, -1,  0), // Top-right-back
        new Vector4Int( 1,  1,  1,  0), // Top-right-forward
        new Vector4Int(-1, -1,  0, -1), // Bottom-left-before
        new Vector4Int(-1, -1,  0,  1), // Bottom-left-after
        new Vector4Int(-1,  1,  0, -1), // Top-left-before
        new Vector4Int(-1,  1,  0,  1), // Top-left-after
        new Vector4Int( 1, -1,  0, -1), // Bottom-right-before
        new Vector4Int( 1, -1,  0,  1), // Bottom-right-after
        new Vector4Int( 1,  1,  0, -1), // Top-right-before
        new Vector4Int( 1,  1,  0,  1), // Top-right-after
        new Vector4Int(-1,  0, -1, -1), // Left-back-before
        new Vector4Int(-1,  0, -1,  1), // Left-back-after
        new Vector4Int(-1,  0,  1, -1), // Left-forward-before
        new Vector4Int(-1,  0,  1,  1), // Left-forward-after
        new Vector4Int( 1,  0, -1, -1), // Right-back-before
        new Vector4Int( 1,  0, -1,  1), // Right-back-after
        new Vector4Int( 1,  0,  1, -1), // Right-forward-before
        new Vector4Int( 1,  0,  1,  1), // Right-forward-after
        new Vector4Int( 0, -1, -1, -1), // Down-back-before
        new Vector4Int( 0, -1, -1,  1), // Down-back-after
        new Vector4Int( 0, -1,  1, -1), // Down-forward-before
        new Vector4Int( 0, -1,  1,  1), // Down-forward-after
        new Vector4Int( 0,  1, -1, -1), // Up-back-before
        new Vector4Int( 0,  1, -1,  1), // Up-back-after
        new Vector4Int( 0,  1,  1, -1), // Up-forward-before
        new Vector4Int( 0,  1,  1,  1)  // Up-forward-after
    };

        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                for (int z = 0; z < boardDepth; z++)
                {
                    for (int w = 0; w < boardQuor; w++)
                    {
                        Vector3 cellPosition1 = new Vector3(x + (boardWidth + 1) * z, y + (boardHeight + 1) * w, 0);
                        Vector3 cellPosition2 = new Vector3(x, y + (boardHeight + 1) * w, z);
                        GameObject cell = Instantiate(CellPrefab, cellPosition2, Quaternion.identity);
                        Transform cubeTransform = cell.transform.Find("Cube");
                        CellController cellController = cubeTransform.GetComponent<CellController>();
                        cellController.cellPosition1 = cellPosition1;
                        cellController.cellPosition2 = cellPosition2;
                        cellController.IsMine = false;
                        if (matrix[x, y, z, w] == 1)
                        {
                            cellController.IsMine = true;
                        }
                        else
                        {
                            foreach (var direction in mineOffset)
                            {
                                int dx = direction.x;
                                int dy = direction.y;
                                int dz = direction.z;

                                int nx = x + dx;
                                int ny = y + dy;
                                int nz = z + dz;

                                if (Is4D)
                                {
                                    int dw = direction.w;
                                    int nw = w + dw;
                                
                                    if (nx >= 0 && nx < boardWidth && ny >= 0 && ny < boardHeight && nz >= 0 && nz < boardDepth && nw >= 0 && nw < boardQuor)
                                    {
                                        if (matrix[nx, ny, nz, nw] == 1)
                                        {
                                        cellController.MineAdj++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (nx >= 0 && nx < boardWidth && ny >= 0 && ny < boardHeight && nz >= 0 && nz < boardDepth)
                                    {
                                        if (matrix[nx, ny, nz, w] == 1)
                                        {
                                            cellController.MineAdj++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    void Update()
    {

    }
}
