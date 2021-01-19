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
    // Start is called before the first frame update
    void Start()
    {
        if(type == tileType.EMPTY)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if(type == tileType.LOW)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if(type == tileType.MEDIUM)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        if(type == tileType.HIGH)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == tileType.EMPTY)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (type == tileType.LOW)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (type == tileType.MEDIUM)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        if (type == tileType.HIGH)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
