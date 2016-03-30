using UnityEngine;
using System.Collections;

public class TileColorChange : MonoBehaviour
{
    BuildingManager bm;
    public GameObject tile1Up;
	//public TileColorChange tile1UpClickable;
	public GameObject tileLeft;
	//public TileColorChange tileLeftClickable;
	public GameObject tile1UpLeft;
	//public TileColorChange tile1UpLeftClickable;
    public GameObject tile1UpAbove;

    MeshRenderer mr;
    MeshRenderer mr2;
	MeshRenderer mr3;
	MeshRenderer mr4;
    MeshRenderer mr5;

	public BuildingData buildingData;

    public bool clickable = true;

    // Use this for initialization
    void Start()
    {
        bm = GameObject.FindObjectOfType<BuildingManager>();
        tile1Up = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + gameObject.transform.position.z);
		tileLeft = GameObject.Find("Tile: " + (gameObject.transform.position.x) + "_" + (gameObject.transform.position.z + 1));
		tile1UpLeft = GameObject.Find("Tile: " + (gameObject.transform.position.x + 1) + "_" + (gameObject.transform.position.z + 1));
        tile1UpAbove = GameObject.Find("Tile: " + (gameObject.transform.position.x + 2) + "_" + gameObject.transform.position.z);


/*		tile1UpClickable = tile1Up.GetComponent<TileColorChange> ();
		tileLeftClickable = tileLeft.GetComponent<TileColorChange> ();
		tile1UpLeftClickable = tileLeft.GetComponent<TileColorChange> ();
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

       
			if (bm.selectedBuilding.tag == "Factory"  || bm.selectedBuilding.tag == "Science Building" /*&& tile1UpClickable.clickable == true*/)
            {
				if (tile1Up != null)
                {
                    mr2 = tile1Up.GetComponent<MeshRenderer>();
                    mr2.material.color = Color.red;
                }
            }

			if (bm.selectedBuilding.tag == "Water Tower" /* && tile1UpClickable.clickable == true && tile1UpLeftClickable.clickable == true && tileLeftClickable.clickable == true*/) 
			{
				if (tile1Up != null)
				{
					mr2 = tile1Up.GetComponent<MeshRenderer>();
					mr2.material.color = Color.red;

					/*mr3 = tileLeft.GetComponent<MeshRenderer>();
					mr3.material.color = Color.red;

					mr4 = tile1UpLeft.GetComponent<MeshRenderer>();
					mr4.material.color = Color.red;*/
				}
			}

            if (bm.selectedBuilding.tag == "Clean Factory")
            {
                if (tile1Up != null && tile1UpAbove != null && tileLeft != null && tile1UpLeft != null)
                {
                    mr2 = tile1Up.GetComponent<MeshRenderer>();
                    mr2.material.color = Color.red;

                    mr3 = tileLeft.GetComponent<MeshRenderer>();
                    mr3.material.color = Color.red;

                    mr4 = tile1UpLeft.GetComponent<MeshRenderer>();
                    mr4.material.color = Color.red;

                    mr5 = tile1UpAbove.GetComponent<MeshRenderer>();
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

			if (bm.selectedBuilding.tag == "Factory"  || bm.selectedBuilding.tag == "Science Building")
			{
				if (tile1Up != null)
				{
					mr2 = tile1Up.GetComponent<MeshRenderer>();
					mr2.material.color = Color.white;
				}
			}

			if (bm.selectedBuilding.tag == "Water Tower") 
			{
				if (tile1Up != null)
				{
					mr2 = tile1Up.GetComponent<MeshRenderer>();
					mr2.material.color = Color.white;

					/*mr3 = tileLeft.GetComponent<MeshRenderer>();
					mr3.material.color = Color.white;

					mr4 = tile1UpLeft.GetComponent<MeshRenderer>();
					mr4.material.color = Color.white;*/
				}
			}

            if (bm.selectedBuilding.tag == "Clean Factory")
            {
                if (tile1Up != null && tile1UpAbove != null && tileLeft != null && tile1UpLeft != null)
                {
                    mr2 = tile1Up.GetComponent<MeshRenderer>();
                    mr2.material.color = Color.red;

                    mr3 = tileLeft.GetComponent<MeshRenderer>();
                    mr3.material.color = Color.red;

                    mr4 = tile1UpLeft.GetComponent<MeshRenderer>();
                    mr4.material.color = Color.red;

                    mr5 = tile1UpAbove.GetComponent<MeshRenderer>();
                    mr5.material.color = Color.red;
                }
            }
        }
        
    }
}
