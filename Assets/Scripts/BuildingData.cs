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

    public MouseManager mouseManager;
    public GameData gameData;

    public float pollutionTimer = 1.0f;
    public float moneyTimer = 1.0f;


	// Use this for initialization
	void Start () 
	{
		upgraded = false;
        mouseManager = GameObject.FindObjectOfType<MouseManager>();
        gameData = GameData.FindObjectOfType<GameData>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (this.gameObject.tag == "Factory")
        {
            pollutionTimer -= Time.deltaTime;
            if (pollutionTimer <= 0)
            {
                gameData.pollutionLevel += mouseManager.factoryPollutionCost;
                mouseManager.pollutionBar.sizeDelta = new Vector2(mouseManager.pollutionBarWidthHeight.x += mouseManager.factoryPollutionCost, mouseManager.pollutionBarWidthHeight.y);
                pollutionTimer = 1.0f;

            }

            moneyTimer -= Time.deltaTime;
            if (moneyTimer <= 0)
            {
                gameData.money += mouseManager.factoryMoneyCost * 0.5f;
                moneyTimer = 1.0f;
            }
        }

        if ( this.gameObject.tag == "Tower")
        {
            pollutionTimer -= Time.deltaTime;
            if (pollutionTimer <= 0)
            {
                gameData.pollutionLevel += mouseManager.towerPollutionCost;;
                mouseManager.pollutionBar.sizeDelta = new Vector2(mouseManager.pollutionBarWidthHeight.x += mouseManager.towerPollutionCost, mouseManager.pollutionBarWidthHeight.y);
                pollutionTimer = 1.0f;
            }
            moneyTimer -= Time.deltaTime;
            if (moneyTimer <= 0)
            {
                gameData.money += mouseManager.towerMoneyCost * 0.5f;
                moneyTimer = 1.0f;
            }
        }

        if(this.gameObject.tag == "Science Building")
        {
            pollutionTimer -= Time.deltaTime;
            if (pollutionTimer <= 0)
            {
                gameData.pollutionLevel += mouseManager.sciencePollutionCost;;
                mouseManager.pollutionBar.sizeDelta = new Vector2(mouseManager.pollutionBarWidthHeight.x += mouseManager.sciencePollutionCost, mouseManager.pollutionBarWidthHeight.y);
                pollutionTimer = 1.0f;
            }
            moneyTimer -= Time.deltaTime;
            if (moneyTimer <= 0)
            {
                gameData.money += mouseManager.scienceMoneyCost * 0.5f;
                moneyTimer = 1.0f;
            }
        }

        if( this.gameObject.tag == "Water Tower")
        {
            pollutionTimer -= Time.deltaTime;
            if (pollutionTimer <= 0)
            {
                gameData.pollutionLevel += mouseManager.waterPollutionCost;;
                mouseManager.pollutionBar.sizeDelta = new Vector2(mouseManager.pollutionBarWidthHeight.x += mouseManager.waterPollutionCost, mouseManager.pollutionBarWidthHeight.y);
                pollutionTimer = 1.0f;
            }
            moneyTimer -= Time.deltaTime;
            if (moneyTimer <= 0)
            {
                gameData.money += mouseManager.waterMoneyCost * 0.5f;
                moneyTimer = 1.0f;
            }
        }
        if( this.gameObject.tag == "Clean Factory")
        {
            pollutionTimer -= Time.deltaTime;
            if (pollutionTimer <= 0)
            {
                gameData.pollutionLevel += mouseManager.cleanFactoryPollutionCost;;
                mouseManager.pollutionBar.sizeDelta = new Vector2(mouseManager.pollutionBarWidthHeight.x += mouseManager.cleanFactoryPollutionCost, mouseManager.pollutionBarWidthHeight.y);
                pollutionTimer = 1.0f;
            }
            moneyTimer -= Time.deltaTime;
            if (moneyTimer <= 0)
            {
                gameData.money += mouseManager.cleanFactoryMoneyCost * 0.5f;
                moneyTimer = 1.0f;
            }
        }
        if( this.gameObject.tag == "Wind Turbine")
        {
            pollutionTimer -= Time.deltaTime;
            if (pollutionTimer <= 0)
            {
                gameData.pollutionLevel += mouseManager.windTurbinePollutionCost;;
                mouseManager.pollutionBar.sizeDelta = new Vector2(mouseManager.pollutionBarWidthHeight.x += mouseManager.windTurbinePollutionCost, mouseManager.pollutionBarWidthHeight.y);
                pollutionTimer = 1.0f;
            }
            moneyTimer -= Time.deltaTime;
            if (moneyTimer <= 0)
            {
                gameData.money += mouseManager.windTurbineMoneyCost * 0.5f;
                moneyTimer = 1.0f;
            }
        }
        if( this.gameObject.tag == "Solar Panel")
        {
            pollutionTimer -= Time.deltaTime;
            if (pollutionTimer <= 0)
            {
                gameData.pollutionLevel += mouseManager.solarPanelPollutionCost;;
                mouseManager.pollutionBar.sizeDelta = new Vector2(mouseManager.pollutionBarWidthHeight.x += mouseManager.solarPanelPollutionCost, mouseManager.pollutionBarWidthHeight.y);
                pollutionTimer = 1.0f;
            }
            moneyTimer -= Time.deltaTime;
            if (moneyTimer <= 0)
            {
                gameData.money += mouseManager.solarPanelMoneyCost * 0.5f;
                moneyTimer = 1.0f;
            }
        }
	
	}
}
