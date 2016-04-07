using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public int pollutionLevel = 100;
    public int money = 200;

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
        pollutionText.text = "Pollution: ";
	}

}
