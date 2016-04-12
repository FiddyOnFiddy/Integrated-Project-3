using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public float pollutionLevel = 100.0f;
    public float money = 350;

    public Text moneyText;
    public Text pollutionText;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        moneyText.text = "    $" + money.ToString();
        pollutionText.text = " ";

	}

}
