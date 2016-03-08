using UnityEngine;
using System.Collections;

public class TileColorChange : MonoBehaviour
{
    BuildingManager bm;
    public GameObject tileAbove;
	public GameObject tileLeft;
	public GameObject tileBelow;
	public GameObject tileRight;
    MeshRenderer mr;
    MeshRenderer mr2;
	MeshRenderer mr3;
	MeshRenderer mr4;
	MeshRenderer mr5;


    public bool clickable = true;

    // Use this for initialization
    void Start()
    {
        bm = GameObject.FindObjectOfType<BuildingManager>();
        tileAbove = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + gameObject.transform.position.z);
		tileLeft = GameObject.Find("Tile: " + (gameObject.transform.position.x) + "_" + (gameObject.transform.position.z + 1));
		tileBelow = GameObject.Find("Tile: " + (gameObject.transform.position.x - 1) + "_" + gameObject.transform.position.z);
		tileRight = GameObject.Find("Tile: " + (gameObject.transform.position.x) + "_" + (gameObject.transform.position.z - 1));

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

       
			if (bm.selectedBuilding.tag == "Factory"  || bm.selectedBuilding.tag == "Science Building")
            {
				if (tileAbove != null)
                {
                    mr2 = tileAbove.GetComponent<MeshRenderer>();
                    mr2.material.color = Color.red;
                }
            }

			if (bm.selectedBuilding.tag == "Water Tower") 
			{
				if (tileAbove != null && tileLeft != null && tileRight != null && tileBelow != null)
				{
					mr2 = tileAbove.GetComponent<MeshRenderer>();
					mr2.material.color = Color.red;

					mr3 = tileLeft.GetComponent<MeshRenderer>();
					mr3.material.color = Color.red;

					mr4 = tileRight.GetComponent<MeshRenderer>();
					mr4.material.color = Color.red;

					mr5 = tileBelow.GetComponent<MeshRenderer>();
					mr5.material.color = Color.red;
				}
			}
        }
        
    }
    void OnMouseExit()
    {

        if (clickable == true)
        {
            mr.material.color = Color.white;

			if (bm.selectedBuilding.tag == "Factory"|| bm.selectedBuilding.tag == "Water Tower" || bm.selectedBuilding.tag == "Science Building")
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
