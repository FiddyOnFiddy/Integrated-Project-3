using UnityEngine;
using System.Collections;

public class BuildingData : MonoBehaviour
{

	public bool upgraded = false;

	public TileColorChange tileUnderMouse;
	public TileColorChange tileAbove;
	public TileColorChange tileLeft;
	public TileColorChange tileAboveLeft;

	// Use this for initialization
	void Start () 
	{
		upgraded = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
