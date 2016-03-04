using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridCreationScript : MonoBehaviour 
{
    public GameObject tilePrefab;

    //Number of tiles wide and high.
    int width = 20;
    int height = 20;


	// Use this for initialization
	void Start () 
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile_go = (GameObject)Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);

                tile_go.name = "Tile: " + x + "_" + y;
                tile_go.transform.SetParent(this.transform);
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
