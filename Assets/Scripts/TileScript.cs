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
    void Start()
    {
        if (type == tileType.EMPTY)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            value = 0;
        }
        if (type == tileType.LOW)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            value = 25;
        }
        if (type == tileType.MEDIUM)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            value = 50;
        }
        if (type == tileType.HIGH)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            value = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == tileType.EMPTY)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            value = 0;
        }
        if (type == tileType.LOW)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            value = 25;
        }
        if (type == tileType.MEDIUM)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            value = 50;
        }
        if (type == tileType.HIGH)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            value = 100;
        }
    }
}
