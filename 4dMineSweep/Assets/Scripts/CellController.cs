using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CellController : MonoBehaviour
{
    public bool IsMine;
    public bool IsFlagged;
    public bool reveal;
    public bool revealAll;
    public int MineAdj;
    public Vector3 cellPosition1;
    public Vector3 cellPosition2;
    public Vector4 cellCoords;


    private Renderer CellRenderer;

    private List<Renderer> highlightedCells = new List<Renderer>();


    void Start()
    {
        CellRenderer = GetComponent<Renderer>();
        IsFlagged = false;
        reveal = true;
    }

    public void Reveal()
    {
        if (reveal== true || revealAll == true)
        {
            if (IsMine)
            {
                CellRenderer.material.color = Color.red;
            }
            InstText(transform, MineAdj.ToString(), Color.black);
        }
    }
    public void InstText(Transform cubeTransform,string text, Color colour)
    {

        Transform textTransform = cubeTransform.Find("TextFront");
        TextMeshPro textMeshPro = textTransform.GetComponent<TextMeshPro>();
        textMeshPro.text = text;
        textMeshPro.color = colour;

        textTransform = cubeTransform.Find("TextSide");
        textMeshPro = textTransform.GetComponent<TextMeshPro>();
        textMeshPro.text = text;
        textMeshPro.color = colour;

        textTransform = cubeTransform.Find("TextTop");
        textMeshPro = textTransform.GetComponent<TextMeshPro>();
        textMeshPro.text = text;
        textMeshPro.color = colour;
    }

    public void SwitchView(int view)
    {
        Reveal();
        switch (view)
        {
            case 1:
                transform.position = cellPosition1;
                break;
            case 2:
                transform.position = cellPosition2;
                break;

        }
    }

    public void ShowAdj()
    {

        foreach (var cell in highlightedCells)
        {
            cell.material.color = Color.white; // Assuming white is the default color
        }
        highlightedCells.Clear();

        foreach (var direction in StaticVars.mineOffset)
        {
            int dx = direction.x;
            int dy = direction.y;
            int dz = direction.z;

            int nx = (int)(cellCoords.x + dx);
            int ny = (int)(cellCoords.y + dy);
            int nz = (int)(cellCoords.z + dz);

            if (StaticVars.Is4D)
            {
                int dw = direction.w;
                int nw = (int)(cellCoords.w + dw);

                if (nx >= 0 && nx < StaticVars.boardWidth && ny >= 0 && ny < StaticVars.boardHeight && nz >= 0 && nz < StaticVars.boardDepth && nw >= 0 && nw < StaticVars.boardQuor)
                {
                    var cell = StaticVars.cellMatrix[nx, ny, nz, nw];
                    if (cell.CellRenderer != null)
                    {
                        Renderer targetCell = cell.CellRenderer;
                        targetCell.material.color = Color.red;
                        highlightedCells.Add(targetCell);
                    }
                }
            }
            else
            {
                if (nx >= 0 && nx < StaticVars.boardWidth && ny >= 0 && ny < StaticVars.boardHeight && nz >= 0 && nz < StaticVars.boardDepth)
                {
                    var cell = StaticVars.cellMatrix[nx, ny, nz, (int)cellCoords.w];
                    if (cell.CellRenderer != null)
                    {
                        Renderer targetCell = cell.CellRenderer;
                        targetCell.material.color = Color.red;
                        highlightedCells.Add(targetCell);
                    }
                }
            }
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            ShowAdj();
        }
        else
        {
            foreach (var cell in highlightedCells)
            {
                if (cell != null) 
                {
                    cell.material.color = Color.white; 
                }
            }
            highlightedCells.Clear(); 
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    if (!IsFlagged)
                    {
                        RevealCell();
                    }
                }
            }
        }

        // Detect right-click (flag or unflag the cell)
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    ToggleFlag();
                }
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            if (transform.position == cellPosition1) 
            { 
                SwitchView(2); 
            }
            else
            {
                SwitchView(1);
            }
        }
    }

    void RevealCell()
    {
        if (IsMine)
        {
            Debug.Log("Boom! You clicked on a mine.");
            CellRenderer.material.color = Color.red;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void ToggleFlag()
    {
        IsFlagged = !IsFlagged;

        if (IsFlagged)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }
    }
}
