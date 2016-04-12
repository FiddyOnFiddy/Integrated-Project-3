using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HideControlsText : MonoBehaviour
{

    public Text controls1, controls2;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            controls1.enabled = false;
            controls2.enabled = false;
        }
    }
}
