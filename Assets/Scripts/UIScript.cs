using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text displayText;
    private bool gridActive = false;

    public ScanScript script;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "Hello comander, please hit space to activate the resource grid.";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    GridScript.Instance.tiles[x, y].SetActive(true);
                    gridActive = true;
                }
            }
        }

        if(gridActive)
        {
            displayText.text = "Click on the toggle in the top right corner to scan.";
            gridActive = false;
        }

        if(script.clicksRemaining == 0)
        {
            displayText.text = "You've ran our of extractions. Your final resource total is " + script.resources;
        }

        if(script.counter == 0)
        {
            displayText.text = "You've ran out of scans, switch back to extract mode.";
        }
    }
}
