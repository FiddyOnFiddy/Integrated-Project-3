using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;


public class BuildingInteractionScript : MonoBehaviour
{
    public Button sellButton;
    public Button upgradeButton;
    public toggleUIScript toggleUI;
    GameObject buildingGridPos;
    GameObject tileAbove;


	// Use this for initialization
	void Start ()
    {
        toggleUI = GameObject.FindObjectOfType<toggleUIScript>();

        buildingGridPos = GameObject.Find("Tile: " + (gameObject.transform.position.x) + "_" + gameObject.transform.position.z);
        tileAbove = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + gameObject.transform.position.z);


        Transform t = toggleUI.gameObject.transform;

        foreach (Transform child in t)
        {
            foreach (Transform c in child)
            {
                if(c.gameObject.name == "Sell")
                {
                    sellButton = c.gameObject.GetComponent<Button>();
                }
                if(c.gameObject.name == "Upgrade Button")
                {
                    upgradeButton = c.gameObject.GetComponent<Button>();
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        


	
	}

    void OnMouseUpAsButton()
    {
        //Find buildings tile position by name

        sellButton.onClick.AddListener(delegate { SellBuilding(); });


        toggleUI.GetComponent<Canvas>().enabled = true;
        Debug.Log("Click");
    }

    public void SellBuilding()
    {
        //destroy the appropriate building by name and turn the bool clickable at that tile to false
        toggleUI.GetComponent<Canvas>().enabled = false;
        Destroy(this.gameObject);
    }
}
