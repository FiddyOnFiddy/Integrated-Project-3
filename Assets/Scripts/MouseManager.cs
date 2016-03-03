using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour 
{
    public GameObject placeableTile;
    public float xOffset = -0.25f;
    public float yOffSet = 1.0f;
    public float zOffset = -0.25f;

    public Button sellButton;
    public Button upgradeButton;
    public toggleUIScript toggleUI;
    public GameData gameData;

    public int factoryPollutionCost = 30;
    public int factoryMoneyCost = 30;
    public int towerPollutionCost = 10;
    public int towerMoneyCost = 20;
    public int sciencePollutionCost = 20;
    public int scienceMoneyCost = 60;
    public int waterPollutionCost = 10;
    public int waterMoneyCost = 30;

	// Use this for initialization
	void Start () 
    {
        findBuildingUIButtons();
        gameData = GameObject.FindObjectOfType<GameData>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            GameObject ourHitObject = hit.collider.transform.gameObject;
            DetectBuilding(ourHitObject);
            SpawnBuilding(ourHitObject);
            Debug.Log("Raycast hit: " + ourHitObject.name);
            
        }
	
	}

    void SpawnBuilding(GameObject ourHitObject)
    {
        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        TileColorChange tileColourChange = ourHitObject.GetComponent<TileColorChange>();

        if (Input.GetMouseButtonUp(0) && ourHitObject.tag == "Tile" && tileColourChange.clickable == true && tileColourChange.tileAbove.GetComponent<TileColorChange>().clickable == true)
        {
            if(bm.selectedBuilding.tag == "Factory" || bm.selectedBuilding.tag == "Water Tower" || bm.selectedBuilding.tag == "Science Building" && tileColourChange.tileAbove != null )
            {
                tileColourChange.clickable = false;
                tileColourChange.tileAbove.GetComponent<TileColorChange>().clickable = false;

                tileColourChange.GetComponent<MeshRenderer>().material.color = Color.white;
                tileColourChange.tileAbove.GetComponent<MeshRenderer>().material.color = Color.white;


                Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

                gameData.money -= factoryMoneyCost;
                gameData.pollutionLevel -= factoryPollutionCost;

                gameData.money -= scienceMoneyCost;
                gameData.pollutionLevel -= sciencePollutionCost;

                gameData.money -= waterMoneyCost;
                gameData.pollutionLevel -= waterPollutionCost;
            }
            if(bm.selectedBuilding.tag == "Tower")
            {
                tileColourChange.clickable = false;
                tileColourChange.GetComponent<MeshRenderer>().material.color = Color.white;

                Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

                gameData.money -= towerMoneyCost;
                gameData.pollutionLevel -= towerPollutionCost;

            }

            /*if (ourHitObject.tag == "Factory")
            {
                gameData.money -= factoryMoneyCost;
                gameData.pollutionLevel -= factoryPollutionCost;
                Destroy(ourHitObject);

            }
            else if (ourHitObject.tag == "Science Building")
            {
                gameData.money -= scienceMoneyCost;
                gameData.pollutionLevel -= sciencePollutionCost;
                Destroy(ourHitObject);
            }
            else if (ourHitObject.tag == "Water Building")
            {
                gameData.money -= waterMoneyCost;
                gameData.pollutionLevel -= waterPollutionCost;
                Destroy(ourHitObject);
            }*/

        }
    }

    void DetectBuilding(GameObject ourHitObject)
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(ourHitObject.tag == "Factory" || ourHitObject.tag == "Tower" || ourHitObject.tag == "Science Building" || ourHitObject.tag == "Water Tower")
            {
                sellButton.onClick.AddListener(delegate { SellBuilding(ourHitObject); });

                toggleUI.GetComponent<Canvas>().enabled = true;
                Debug.Log("Click");
            }
        }
    }

    public void SellBuilding(GameObject ourHitObject)
    {
        //Get tile at building or tiles if wide building and change clickable to true. Find the tile by name
        toggleUI.GetComponent<Canvas>().enabled = false;

        if (ourHitObject != null)
        {

            if (ourHitObject.tag == "Factory")
            {
                gameData.money += factoryMoneyCost;
                gameData.pollutionLevel += factoryPollutionCost;
                Destroy(ourHitObject);

            }
            if (ourHitObject.tag == "Tower")
            {
                gameData.money += towerMoneyCost;
                gameData.pollutionLevel += towerPollutionCost;
                Destroy(ourHitObject);
            }
            if (ourHitObject.tag == "Science Building")
            {
                gameData.money += scienceMoneyCost;
                gameData.pollutionLevel += sciencePollutionCost;
                Destroy(ourHitObject);
            }
            if (ourHitObject.tag == "Water Tower")
            {
                gameData.money += waterMoneyCost;
                gameData.pollutionLevel += waterPollutionCost;
                Destroy(ourHitObject);
            }
        }
    }

    void findBuildingUIButtons()
    {
        toggleUI = GameObject.FindObjectOfType<toggleUIScript>();

        Transform t = toggleUI.gameObject.transform;

        foreach (Transform child in t)
        {
            foreach (Transform c in child)
            {
                if (c.gameObject.name == "Sell")
                {
                    sellButton = c.gameObject.GetComponent<Button>();
                }
                if (c.gameObject.name == "Upgrade Button")
                {
                    upgradeButton = c.gameObject.GetComponent<Button>();
                }
            }
        }
    }

   
}
