using UnityEngine;
using System.Collections;

public class TileColorChange : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        
      
	}

    void OnMouseOver()
    {
        MeshRenderer mr = this.gameObject.GetComponent<MeshRenderer>();
        mr.material.color = Color.red;
    }
    void OnMouseExit()
    {
        MeshRenderer mr = this.gameObject.GetComponent<MeshRenderer>();
        mr.material.color = Color.white;
    }


}
