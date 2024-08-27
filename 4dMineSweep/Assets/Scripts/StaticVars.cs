using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVars
{
    public static Vector4Int[] mineOffset;
    static void Start()
    {
        mineOffset = new Vector4Int[] {
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



    }

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
