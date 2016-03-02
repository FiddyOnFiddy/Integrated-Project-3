using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class toggleUIScript : MonoBehaviour 
{
    public Canvas buildingUI;
	// Use this for initialization
	void Start () 
    {
        buildingUI = this.gameObject.GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            buildingUI.enabled = false;
        }
	
	}
}
