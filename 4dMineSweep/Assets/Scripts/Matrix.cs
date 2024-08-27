using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using Color = UnityEngine.Color;

public class Matrix : MonoBehaviour
{
    private int[,,,] mineMatrix;
    private CellController[,,,] cellMatrix;

    public GameObject CellPrefab;
    private int minePosCount;

    // Start is called before the first frame update
    void Start()
    {
        mineMatrix = new int[StaticVars.boardWidth, StaticVars.boardHeight, StaticVars.boardDepth, StaticVars.boardQuor];
        cellMatrix = new CellController[StaticVars.boardWidth, StaticVars.boardHeight, StaticVars.boardDepth, StaticVars.boardQuor];

        while (minePosCount < StaticVars.mineCount)
        {
            int x = Random.Range(0, StaticVars.boardWidth);
            int y = Random.Range(0, StaticVars.boardHeight);
            int z = Random.Range(0, StaticVars.boardDepth);
            int w = Random.Range(0, StaticVars.boardQuor);
            if (mineMatrix[x, y, z, w] != 1)
            {
                minePosCount++;
                mineMatrix[x, y, z, w] = 1;
            }
        }

        for (int x = 0; x < StaticVars.boardWidth; x++)
        {
            for (int y = 0; y < StaticVars.boardHeight; y++)
            {
                for (int z = 0; z < StaticVars.boardDepth; z++)
                {
                    for (int w = 0; w < StaticVars.boardQuor; w++)
                    {
                        Vector3 cellPosition1 = new Vector3(x + (StaticVars.boardWidth + 1) * z, y + (StaticVars.boardHeight + 1) * w, 0);
                        Vector3 cellPosition2 = new Vector3(x, y + (StaticVars.boardHeight + 1) * w, z);
                        GameObject cell = Instantiate(CellPrefab, cellPosition2, Quaternion.identity);
                        Transform cubeTransform = cell.transform.Find("Cube");
                        CellController cellController = cubeTransform.GetComponent<CellController>();
                        cellController.cellPosition1 = cellPosition1;
                        cellController.cellPosition2 = cellPosition2;
                        cellController.IsMine = false;
                        cellController.cellCoords = new Vector4(x, y, z, w);
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

                                if (StaticVars.Is4D)
                                {
                                    int dw = direction.w;
                                    int nw = w + dw;
                                
                                    if (nx >= 0 && nx < StaticVars.boardWidth && ny >= 0 && ny < StaticVars.boardHeight && nz >= 0 && nz < StaticVars.boardDepth && nw >= 0 && nw < StaticVars.boardQuor)
                                    {
                                        if (mineMatrix[nx, ny, nz, nw] == 1)
                                        {
                                        cellController.MineAdj++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (nx >= 0 && nx < StaticVars.boardWidth && ny >= 0 && ny < StaticVars.boardHeight && nz >= 0 && nz < StaticVars.boardDepth)
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
        StaticVars.cellMatrix = cellMatrix;
    }
    void Update()
    {

    }
}
