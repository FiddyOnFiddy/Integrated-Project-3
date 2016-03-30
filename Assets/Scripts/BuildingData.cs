using UnityEngine;
using System.Collections;

public class BuildingData : MonoBehaviour
{

	public bool upgraded = false;

	public TileColorChange tileUnderMouse;
    public TileColorChange tileUp1;
    public TileColorChange tileUp2;
    public TileColorChange tileUp3;
    public TileColorChange tileUp4;

    public TileColorChange tileLeft;
    public TileColorChange tileLeftUp1;
    public TileColorChange tileLeftUp2;
    public TileColorChange tileLeftUp3;
    public TileColorChange tileLeftUp4;

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
