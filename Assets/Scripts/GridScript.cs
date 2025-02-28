﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    // Create singleton of grid, we only want one and it will hold a lot of data
    private static GridScript _instance;

    public static GridScript Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GridScript>();
            }
            return _instance;
        }
    }

    // Reference our tiles
    public GameObject tile;
    public GameObject[,] tiles;
    private int rows = 24;
    private int cols = 24;
    private float tileSize = 0.3f;

    private int numMaxResources = 8;

    // Start is called before the first frame update
    private void Awake()
    {
        GridSetup();
        
    }
    void Start()
    {
        //LoadTiles();
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                if (tiles[x, y].GetComponent<TileScript>().type == tileType.HIGH) 
                {
                    // On start we set all the tiles here. if the tile is high value do 2 passes to set lower values
                    ThirdPass(tiles, x, y, 2);
                    SecondPass(tiles, x, y, 1);
                }
                tiles[x, y].SetActive(false); // lastly set them all to inactive so that on input the grid will display
            }
        }
    }

    private void GridSetup() // setting up the grid
    {
        int resources = 0;
        tiles = new GameObject[cols, rows];
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 newPos = new Vector3(x * tileSize - 3f, y * -tileSize + 3f, 0);
                
                tiles[x,y] = (Instantiate(tile, newPos, Quaternion.identity));
                //float posX = x * tileSize;
                //float posY = y * tileSize;

                // Set value to tile
                int value = Random.Range(0, 100);
                if (value == 0 && resources != numMaxResources)
                { // it is a heavy material node
                    tiles[x,y].GetComponent<TileScript>().type = tileType.HIGH;
                    resources += 1;
                    //SecondPass(tiles, x, y, 1);
                }
                else // regular node
                    tiles[x,y].GetComponent<TileScript>().type = tileType.EMPTY;

                //tile.transform.position = new Vector3(x * tileSize, y * -tileSize, 0);
            }
        }
    }

    private void SecondPass(GameObject[,] objects, int x, int y, int distance)
    {
        int maxX = x + distance + 1;
        int minX = x - distance;
        int maxY = y + distance + 1;
        int minY = y - distance;

        if (minX < 0)
        {
            minX = 0;
        }
        if (maxX > 24)
        {
            maxX = 24;
        }
        if (minY < 0)
        {
            minY = 0;
        }
        if (maxY > 24)
        {
            maxY = 24;
        }


        for (int i = minX; i < maxX; i++)
        {
            for (int j = minY; j < maxY; j++)
            {
                if (x != i || y != j)
                {
                    objects[i, j].GetComponent<TileScript>().type = tileType.MEDIUM;
                }

            }
        }
    }

    private void ThirdPass(GameObject[,] objects, int x, int y, int distance)
    {
        int maxX = x + distance + 1;
        int minX = x - distance;
        int maxY = y + distance + 1;
        int minY = y - distance;

        if (minX < 0)
        {
            minX = 0;
        }
        if (maxX > 24)
        {
            maxX = 24;
        }
        if (minY < 0)
        {
            minY = 0;
        }
        if (maxY > 24)
        {
            maxY = 24;
        }


        for (int i = minX; i < maxX; i++)
        {
            for (int j = minY; j < maxY; j++)
            {
                if (x != i || y != j)
                {
                    objects[i, j].GetComponent<TileScript>().type = tileType.LOW;
                }

            }
        }
    }

}
