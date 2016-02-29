using UnityEngine;
using System.Collections;

public class TileColorChange : MonoBehaviour 
{
    public bool canPlace = true;
    BuildingManager bm;
    public GameObject tileAbove;
    MeshRenderer mr;

	// Use this for initialization
	void Start ()
    {
        bm = GameObject.FindObjectOfType<BuildingManager>();
        tileAbove = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + gameObject.transform.position.z);
        mr = this.gameObject.GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        
      
	}

    void OnMouseOver()
    {
        mr.material.color = Color.red;

        if (bm.selectedBuilding.tag == "Factory")
        {
            if(tileAbove != null)
            {
                MeshRenderer mr2 = tileAbove.GetComponent<MeshRenderer>();
                mr2.material.color = Color.red;
            }
           
        }


    }
    void OnMouseExit()
    {
        mr.material.color = Color.white;

        if (bm.selectedBuilding.tag == "Factory")
        {
            if (tileAbove != null)
            {
                MeshRenderer mr2 = tileAbove.GetComponent<MeshRenderer>();
                mr2.material.color = Color.white;
            }
           
        }

    }
}
