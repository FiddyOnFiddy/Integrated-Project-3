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


	// Use this for initialization
	void Start ()
    {
        toggleUI = GameObject.FindObjectOfType<toggleUIScript>();


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

        sellButton.onClick.AddListener(delegate { SellBuilding(); });
	}
	
	// Update is called once per frame
	void Update ()
    {
        


	
	}

    void OnMouseUpAsButton()
    {
        toggleUI.GetComponent<Canvas>().enabled = true;
        Debug.Log("Click");
    }

    public void SellBuilding()
    {
        toggleUI.GetComponent<Canvas>().enabled = false;
        Destroy(this.gameObject);
    }
}
