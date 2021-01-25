using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tileType
{
    EMPTY,
    LOW,
    MEDIUM,
    HIGH
}

public class TileScript : MonoBehaviour
{
    public tileType type;
    public int value;
    // Start is called before the first frame update
    void Start() // we check to see what type the tile is and set a value
    {
        if (type == tileType.EMPTY)
        {
            //gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            value = 0;
        }
        if (type == tileType.LOW)
        {
            //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            value = 25;
        }
        if (type == tileType.MEDIUM)
        {
            //gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            value = 50;
        }
        if (type == tileType.HIGH)
        {
            //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            value = 100;
        }
    }

    public void ShowTiles() // helper function that will show the colours of the tiles when scanning
    {
        if (type == tileType.EMPTY)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //value = 0;
        }
        if (type == tileType.LOW)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            //value = 25;
        }
        if (type == tileType.MEDIUM)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            //value = 50;
        }
        if (type == tileType.HIGH)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //value = 100;
        }
    }

    public void HideTiles() // another helper function to hide all the tiles back to white
    {
        if (type == tileType.EMPTY)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //value = 0;
        }
        if (type == tileType.LOW)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //value = 25;
        }
        if (type == tileType.MEDIUM)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //value = 50;
        }
        if (type == tileType.HIGH)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //value = 100;
        }
    }
}
