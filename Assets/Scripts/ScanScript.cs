using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanScript : MonoBehaviour
{
    public Toggle toggle;
    public Text toggleCounter;
    public int counter = 3;

    public Text resourceText;
    public Text clickText;

    public int clicksRemaining = 5;
    public int resources;

    // Start is called before the first frame update
    void Start()
    {
        toggleCounter.text = "Scan remaining " + counter.ToString();
        resourceText.text = "Resources collected " + resources.ToString();
        clickText.text = "Gathering clicks remaining " + clicksRemaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null)
            {
                if (toggle.isOn == true && counter > 0) // Scan area
                {
                    counter -= 1;
                    print("toggle working");
                    for (int x = 0; x < 24; x++)
                    {
                        for (int y = 0; y < 24; y++)
                        {
                            if (hit.collider.gameObject.transform.position == GridScript.Instance.tiles[x, y].transform.position)
                            {
                                Scan(GridScript.Instance.tiles, x, y, 3);
                            }
                            
                        }
                    }
                }
                else if(toggle.isOn == false && clicksRemaining > 0) // gather resource
                {
                    clicksRemaining -= 1;
                    for (int x = 0; x < 24; x++)
                    {
                        for (int y = 0; y < 24; y++)
                        {
                            if (hit.collider.gameObject.transform.position == GridScript.Instance.tiles[x, y].transform.position)
                            {
                                Gather(GridScript.Instance.tiles, x, y, 3);
                            }

                        }
                    }
                }
            }
        }
        toggleCounter.text = "Scan remaining " + counter.ToString();
        resourceText.text = "Resources collected " + resources.ToString();
        clickText.text = "Gathering clicks remaining " + clicksRemaining.ToString();
    }
    private void Scan(GameObject[,] objects, int x, int y, int distance)
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
                GridScript.Instance.tiles[i, j].GetComponent<TileScript>().ShowTiles();
            }
        }
    }

    private void Gather(GameObject[,] objects, int x, int y, int distance)
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
                resources += GridScript.Instance.tiles[i, j].GetComponent<TileScript>().value;
                if(GridScript.Instance.tiles[i, j].GetComponent<TileScript>().type == tileType.LOW)
                {
                    GridScript.Instance.tiles[i, j].GetComponent<TileScript>().type = tileType.EMPTY;
                    GridScript.Instance.tiles[i, j].GetComponent<SpriteRenderer>().color = Color.white;
                    GridScript.Instance.tiles[i, j].GetComponent<TileScript>().value = 0;
                }
                if (GridScript.Instance.tiles[i, j].GetComponent<TileScript>().type == tileType.MEDIUM)
                {
                    GridScript.Instance.tiles[i, j].GetComponent<TileScript>().type = tileType.LOW;
                    GridScript.Instance.tiles[i, j].GetComponent<SpriteRenderer>().color = Color.yellow;
                    GridScript.Instance.tiles[i, j].GetComponent<TileScript>().value = 25;
                }
                if (GridScript.Instance.tiles[i, j].GetComponent<TileScript>().type == tileType.HIGH)
                {
                    GridScript.Instance.tiles[i, j].GetComponent<TileScript>().type = tileType.MEDIUM;
                    GridScript.Instance.tiles[i, j].GetComponent<SpriteRenderer>().color = Color.magenta;
                    GridScript.Instance.tiles[i, j].GetComponent<TileScript>().value = 50;
                }
            }
        }
    }

}
