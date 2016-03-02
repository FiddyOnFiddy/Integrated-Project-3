using UnityEngine;
using System.Collections;

public class TileColorChange : MonoBehaviour
{
    BuildingManager bm;
    public GameObject tileAbove;
    MeshRenderer mr;
    MeshRenderer mr2;


    public bool clickable = true;

    // Use this for initialization
    void Start()
    {
        bm = GameObject.FindObjectOfType<BuildingManager>();
        tileAbove = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + gameObject.transform.position.z);
        mr = this.gameObject.GetComponent<MeshRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    { 
        if (clickable == true)
        {
            mr.material.color = Color.red;

       
            if (bm.selectedBuilding.tag == "Factory")
            {
                if (tileAbove != null)
                {
                    mr2 = tileAbove.GetComponent<MeshRenderer>();
                    mr2.material.color = Color.red;
                }

            }
        }
        
    }
    void OnMouseExit()
    {

        if (clickable == true)
        {
            mr.material.color = Color.white;

            if (bm.selectedBuilding.tag == "Factory")
            {
                if (tileAbove != null)
                {
                    mr2 = tileAbove.GetComponent<MeshRenderer>();
                    mr2.material.color = Color.white;
                }

            }
        }
        
    }
}
