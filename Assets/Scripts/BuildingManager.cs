using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour 
{
    public GameObject selectedBuilding;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SelectedBuilding(GameObject selectedPrefab)
    {
        selectedBuilding = selectedPrefab;
    }
        
}
