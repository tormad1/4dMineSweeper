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
    private int[,,,] mineMatrix;
    private CellController[,,,] cellMatrix;

    public GameObject CellPrefab;
    private int minePosCount;

    // Start is called before the first frame update
    void Start()
    {
        mineMatrix = new int[boardWidth, boardHeight, boardDepth, boardQuor];
        cellMatrix = new CellController[boardWidth, boardHeight, boardDepth, boardQuor];

        while (minePosCount < mineCount)
        {
            int x = Random.Range(0, boardWidth);
            int y = Random.Range(0, boardHeight);
            int z = Random.Range(0, boardDepth);
            int w = Random.Range(0, boardQuor);
            if (mineMatrix[x, y, z, w] != 1)
            {
                minePosCount++;
                mineMatrix[x, y, z, w] = 1;
            }
        }

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
                        cellMatrix[x, y, z, w] = cellController;

                        if (mineMatrix[x, y, z, w] == 1)
                        {
                            cellController.IsMine = true;
                        }
                        else
                        {
                            foreach (var direction in StaticVars.mineOffset)
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
                                        if (mineMatrix[nx, ny, nz, nw] == 1)
                                        {
                                        cellController.MineAdj++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (nx >= 0 && nx < boardWidth && ny >= 0 && ny < boardHeight && nz >= 0 && nz < boardDepth)
                                    {
                                        if (mineMatrix[nx, ny, nz, w] == 1)
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
