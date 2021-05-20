using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Grid : MonoBehaviour
{
    #region Parameters

    /// <summary>
    /// Game objects for covering the map for search algorithm
    /// </summary>
    public GameObject bottomLeft;

    /// <summary>
    /// Game objects for covering the map for search algorithm
    /// </summary>
    public GameObject topRight;

    /// <summary>
    /// 2d array for griding the game map
    /// </summary>
    private Node[,] myGrid;

    public List<Node> path;

    public LayerMask unwalkable;

    //Grid info
    private int xStart, zStart;
    private int xEnd, zEnd;
    private int vCells, hCells; //amount of cells in the grid
    private int cellWidth = 1;
    private int cellHeight = 1;

    #endregion

    #region Methods

    private void Awake()
    {
        MPGridCreate();
    }

    void MPGridCreate()
    {
        xStart = (int) bottomLeft.transform.position.x;
        zStart = (int) bottomLeft.transform.position.z;

        xEnd = (int) topRight.transform.position.z;
        zEnd = (int) topRight.transform.position.z;

        //For calculating the numbers of cells
        hCells = (int) ((xEnd - xStart) / cellWidth);
        vCells = (int) ((zEnd - zStart) / cellHeight);
        //The grid array has been initialised with respect to numbers of cells
        myGrid = new Node[hCells + 1, vCells + 1];

        UpdateGrid();
    }

    public void UpdateGrid()
    {
        for (int i = 0; i <= hCells; i++)
        {
            for (int j = 0; j <= vCells; j++)
            {
                //TODO maybe replace with checkbox and adjust the radius
                //Returns true if there are any colliders overlapping the sphere defined by position and radius in world coordinates.
                bool walkable =
                    !(Physics.CheckSphere(new Vector3(xStart + i, 0, zStart + j), 0.4f, unwalkable));

                myGrid[i, j] = new Node(i, j, 0, walkable);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    #endregion
}