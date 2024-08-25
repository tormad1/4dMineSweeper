using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public int boardWidth;
    public int boardHeight;
    public int boardDepth;
    public int boardQuor;
    private int[,,,] matrix;

    // Start is called before the first frame update
    void Start()
    {
        matrix = new int[boardWidth, boardHeight, boardDepth, boardQuor];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
