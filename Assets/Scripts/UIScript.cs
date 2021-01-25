using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text displayText;
    private bool gridActive = false;

    public ScanScript script;

    public Button escapeButton;
    public Text buttonText;
    public Canvas uiCanvas;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "Hello comander, please hit space to activate the resource grid.";
        escapeButton.gameObject.SetActive(false);
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

        if(gridActive) // to change the display text to tell player to scan first
        {
            displayText.text = "Click on the toggle in the top right corner to scan.";
            gridActive = false;
        }

        if(script.counter == 0) // to change display text telling player to go back to extract
        {
            displayText.text = "You've ran out of scans, switch back to extract mode.";
        }
        if (script.clicksRemaining == 0) // once out of clicks will pop up an exit game button that shuts down the interface
        {
            escapeButton.gameObject.SetActive(true);
            displayText.text = "You've ran out of extractions. Your final gold total is " + script.resources;
            buttonText.text = "Your final gold total is " + script.resources + " click here to close interface.";
        }
    }

    public void ExitInterface() // the button on click function
    {
        for (int x = 0; x < 24; x++)
        {
            for (int y = 0; y < 24; y++)
            {
                GridScript.Instance.tiles[x, y].SetActive(false);
                uiCanvas.gameObject.SetActive(false);
            }
        }
    }
}
