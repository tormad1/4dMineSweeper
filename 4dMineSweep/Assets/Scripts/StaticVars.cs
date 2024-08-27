using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVars
{
    public static bool Is4D = true;
    public static int boardWidth = 4;
    public static int boardHeight = 4;
    public static int boardDepth = 4;
    public static int boardQuor = 4;
    public static int mineCount = 4;
    public static bool revealAllCells = false;

    public static CellController[,,,] cellMatrix;

    public static Vector4Int[] mineOffset = new Vector4Int[] {
    new Vector4Int(-1, -1, -1, -1), new Vector4Int(-1, -1, -1, 0), new Vector4Int(-1, -1, -1, 1),
    new Vector4Int(-1, -1,  0, -1), new Vector4Int(-1, -1,  0, 0), new Vector4Int(-1, -1,  0, 1),
    new Vector4Int(-1, -1,  1, -1), new Vector4Int(-1, -1,  1, 0), new Vector4Int(-1, -1,  1, 1),
    new Vector4Int(-1,  0, -1, -1), new Vector4Int(-1,  0, -1, 0), new Vector4Int(-1,  0, -1, 1),
    new Vector4Int(-1,  0,  0, -1), new Vector4Int(-1,  0,  0, 0), new Vector4Int(-1,  0,  0, 1),
    new Vector4Int(-1,  0,  1, -1), new Vector4Int(-1,  0,  1, 0), new Vector4Int(-1,  0,  1, 1),
    new Vector4Int(-1,  1, -1, -1), new Vector4Int(-1,  1, -1, 0), new Vector4Int(-1,  1, -1, 1),
    new Vector4Int(-1,  1,  0, -1), new Vector4Int(-1,  1,  0, 0), new Vector4Int(-1,  1,  0, 1),
    new Vector4Int(-1,  1,  1, -1), new Vector4Int(-1,  1,  1, 0), new Vector4Int(-1,  1,  1, 1),

    new Vector4Int( 0, -1, -1, -1), new Vector4Int( 0, -1, -1, 0), new Vector4Int( 0, -1, -1, 1),
    new Vector4Int( 0, -1,  0, -1), new Vector4Int( 0, -1,  0, 0), new Vector4Int( 0, -1,  0, 1),
    new Vector4Int( 0, -1,  1, -1), new Vector4Int( 0, -1,  1, 0), new Vector4Int( 0, -1,  1, 1),
    new Vector4Int( 0,  0, -1, -1), new Vector4Int( 0,  0, -1, 0), new Vector4Int( 0,  0, -1, 1),
    new Vector4Int( 0,  0,  0, -1),
    new Vector4Int( 0,  0,  0, 1),
    new Vector4Int( 0,  0,  1, -1), new Vector4Int( 0,  0,  1, 0), new Vector4Int( 0,  0,  1, 1),
    new Vector4Int( 0,  1, -1, -1), new Vector4Int( 0,  1, -1, 0), new Vector4Int( 0,  1, -1, 1),
    new Vector4Int( 0,  1,  0, -1), new Vector4Int( 0,  1,  0, 0), new Vector4Int( 0,  1,  0, 1),
    new Vector4Int( 0,  1,  1, -1), new Vector4Int( 0,  1,  1, 0), new Vector4Int( 0,  1,  1, 1),

    new Vector4Int( 1, -1, -1, -1), new Vector4Int( 1, -1, -1, 0), new Vector4Int( 1, -1, -1, 1),
    new Vector4Int( 1, -1,  0, -1), new Vector4Int( 1, -1,  0, 0), new Vector4Int( 1, -1,  0, 1),
    new Vector4Int( 1, -1,  1, -1), new Vector4Int( 1, -1,  1, 0), new Vector4Int( 1, -1,  1, 1),
    new Vector4Int( 1,  0, -1, -1), new Vector4Int( 1,  0, -1, 0), new Vector4Int( 1,  0, -1, 1),
    new Vector4Int( 1,  0,  0, -1), new Vector4Int( 1,  0,  0, 0), new Vector4Int( 1,  0,  0, 1),
    new Vector4Int( 1,  0,  1, -1), new Vector4Int( 1,  0,  1, 0), new Vector4Int( 1,  0,  1, 1),
    new Vector4Int( 1,  1, -1, -1), new Vector4Int( 1,  1, -1, 0), new Vector4Int( 1,  1, -1, 1),
    new Vector4Int( 1,  1,  0, -1), new Vector4Int( 1,  1,  0, 0), new Vector4Int( 1,  1,  0, 1),
    new Vector4Int( 1,  1,  1, -1), new Vector4Int( 1,  1,  1, 0), new Vector4Int( 1,  1,  1, 1)
};


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
}
