using UnityEngine;
using System.Collections;

public class IsoCameraFixScript : MonoBehaviour
{
    public bool fix = true;
    public bool active = false;
    public Vector3 fixPosition = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(active)
        {
            Fix();
        }
	}

    private void OnEnable()
    {
        Fix();
    }

    private void Fix()
    {
        if(fix)
        {
            this.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward) * Quaternion.Euler (fixPosition);
        }
    }
}
