using UnityEngine;
using System.Collections;

public class TileColorChange : MonoBehaviour
{
    BuildingManager bm;
    public GameObject tileAbove;
	//public TileColorChange tileAboveClickable;
	public GameObject tileLeft;
	//public TileColorChange tileLeftClickable;
	public GameObject tileAboveLeft;
	//public TileColorChange tileAboveLeftClickable;
    MeshRenderer mr;
    MeshRenderer mr2;
	MeshRenderer mr3;
	MeshRenderer mr4;

	public BuildingData buildingData;

    public bool clickable = true;

    // Use this for initialization
    void Start()
    {
        bm = GameObject.FindObjectOfType<BuildingManager>();
        tileAbove = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + gameObject.transform.position.z);
		tileLeft = GameObject.Find("Tile: " + (gameObject.transform.position.x) + "_" + (gameObject.transform.position.z + 1));
		tileAboveLeft = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + (gameObject.transform.position.z + 1));

/*		tileAboveClickable = tileAbove.GetComponent<TileColorChange> ();
		tileLeftClickable = tileLeft.GetComponent<TileColorChange> ();
		tileAboveLeftClickable = tileLeft.GetComponent<TileColorChange> ();
*/


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

       
			if (bm.selectedBuilding.tag == "Factory"  || bm.selectedBuilding.tag == "Science Building" /*&& tileAboveClickable.clickable == true*/)
            {
				if (tileAbove != null)
                {
                    mr2 = tileAbove.GetComponent<MeshRenderer>();
                    mr2.material.color = Color.red;
                }
            }

			if (bm.selectedBuilding.tag == "Water Tower" /* && tileAboveClickable.clickable == true && tileAboveLeftClickable.clickable == true && tileLeftClickable.clickable == true*/) 
			{
				if (tileAbove != null && tileLeft != null && tileAboveLeft != null)
				{
					mr2 = tileAbove.GetComponent<MeshRenderer>();
					mr2.material.color = Color.red;

					/*mr3 = tileLeft.GetComponent<MeshRenderer>();
					mr3.material.color = Color.red;

					mr4 = tileAboveLeft.GetComponent<MeshRenderer>();
					mr4.material.color = Color.red;*/
				}
			}
        }
        
    }
    void OnMouseExit()
    {

        if (clickable == true)
        {
            mr.material.color = Color.white;

			if (bm.selectedBuilding.tag == "Factory"  || bm.selectedBuilding.tag == "Science Building")
			{
				if (tileAbove != null)
				{
					mr2 = tileAbove.GetComponent<MeshRenderer>();
					mr2.material.color = Color.white;
				}
			}

			if (bm.selectedBuilding.tag == "Water Tower") 
			{
				if (tileAbove != null && tileLeft != null && tileAboveLeft != null)
				{
					mr2 = tileAbove.GetComponent<MeshRenderer>();
					mr2.material.color = Color.white;

					/*mr3 = tileLeft.GetComponent<MeshRenderer>();
					mr3.material.color = Color.white;

					mr4 = tileAboveLeft.GetComponent<MeshRenderer>();
					mr4.material.color = Color.white;*/
				}
			}
        }
        
    }
}
