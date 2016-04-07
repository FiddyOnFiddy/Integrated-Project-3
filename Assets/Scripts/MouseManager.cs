using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour 
{
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
    public int cleanFactoryMoneyCost = 40;
    public int clearnFactoryPollutionCost = 30;
    public int windTurbineMoneyCost = 30;
    public int windTurbinePollutionCost = 40;
    public int solarPanelMoneyCost = 30;
    public int solarPanelPollutionCost = 5;

	public int maxBuildDistance =40;

	public GameObject towerUpgrade;
	public GameObject waterPlantUpgrade;
	public GameObject scienceBuildingUpgrade;
	public GameObject factoryUpgrade;
    public GameObject cleanFactoryUpgrade;

	public GameObject buildingToPlace;

	public BuildingData buildingData;

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


	public SpriteRenderer buildingToUpgrade;

	public CameraSwitcher cameraSwitcher;

    public RectTransform pollutionBar;
    Vector2 pollutionBarWidthHeight;



	// Use this for initialization
	void Start () 
    {
        findBuildingUIButtons();
        gameData = GameObject.FindObjectOfType<GameData>();



	}
	
	// Update is called once per frame
	void Update () 
    {
        pollutionBarWidthHeight = pollutionBar.sizeDelta;


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
          //  Debug.Log("Raycast hit: " + ourHitObject.name);
            Debug.DrawRay(ray.origin, ray.direction * 1000.0f, Color.white);
        }
	
	}

    void SpawnBuilding(GameObject ourHitObject)
    {
        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();

        if (Input.GetMouseButtonUp(0) && ourHitObject.tag == "Tile")
        {
			tileUnderMouse = ourHitObject.GetComponent<TileColorChange>();

            if (tileUnderMouse.tileUp1 != null)
            {
                tileUp1 = tileUnderMouse.tileUp1.GetComponent<TileColorChange>();
            }
            if (tileUnderMouse.tileUp2 != null)
            {
                tileUp2 = tileUnderMouse.tileUp2.GetComponent<TileColorChange>();
            }
            if (tileUnderMouse.tileUp3 != null)
            {
                tileUp3 = tileUnderMouse.tileUp3.GetComponent<TileColorChange>();
            }
            if (tileUnderMouse.tileUp4 != null)
            {
                tileUp4 = tileUnderMouse.tileUp4.GetComponent<TileColorChange>();
            }


            if(tileUnderMouse.tileLeft != null)
            {
                tileLeft = tileUnderMouse.tileLeft.GetComponent<TileColorChange>();
            }
            if (tileUnderMouse.tileLeftUp1 != null)
            {
                tileLeftUp1 = tileUnderMouse.tileLeftUp1.GetComponent<TileColorChange>();
            }
            if (tileUnderMouse.tileLeftUp2 != null)
            {
                tileLeftUp2 = tileUnderMouse.tileLeftUp2.GetComponent<TileColorChange>();
            }
            if (tileUnderMouse.tileLeftUp3 != null)
            {
                tileLeftUp3 = tileUnderMouse.tileLeftUp3.GetComponent<TileColorChange>();
            }
            if (tileUnderMouse.tileLeftUp4 != null)
            {
                tileLeftUp4 = tileUnderMouse.tileLeftUp4.GetComponent<TileColorChange>();
            }

            if (bm.selectedBuilding.tag == "Clean Factory" && tileUnderMouse.clickable == true && tileUp1 != null && tileUp1.clickable == true && tileUp2 != null && tileUp2.clickable == true && tileUp3 != null && tileUp3.clickable == true && tileUp4 != null && tileUp4.clickable == true)
            {
                if (tileLeft != null && tileLeft.clickable == true && tileLeftUp1 != null && tileLeftUp1.clickable == true && tileLeftUp2 != null && tileLeftUp2.clickable == true && tileLeftUp3 != null && tileLeftUp3.clickable == true && tileLeftUp4 !=null && tileLeftUp4.clickable == true)
                {
                    tileUnderMouse.clickable = false;
                    tileUp1.clickable = false;
                    tileUp2.clickable = false;
                    tileUp3.clickable = false;
                    tileUp4.clickable = false;

                    tileLeft.clickable = false;
                    tileLeftUp1.clickable = false;
                    tileLeftUp2.clickable = false;
                    tileLeftUp3.clickable = false;
                    tileLeftUp4.clickable = false;

                    tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
                    tileUp1.GetComponent<MeshRenderer>().material.color = Color.white;
                    tileUp2.GetComponent<MeshRenderer>().material.color = Color.white;
                    tileUp3.GetComponent<MeshRenderer>().material.color = Color.white;
                    tileUp4.GetComponent<MeshRenderer>().material.color = Color.white;

                    tileLeft.GetComponent<MeshRenderer>().material.color = Color.white;
                    tileLeftUp1.GetComponent<MeshRenderer>().material.color = Color.white;
                    tileLeftUp2.GetComponent<MeshRenderer>().material.color = Color.white;
                    tileLeftUp3.GetComponent<MeshRenderer>().material.color = Color.white;
                    tileLeftUp4.GetComponent<MeshRenderer>().material.color = Color.white;

                    buildingToPlace = (GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

                    buildingData = buildingToPlace.GetComponent<BuildingData>();

                    buildingData.tileUnderMouse = tileUnderMouse;
                    buildingData.tileUp1 = tileUp1;
                    buildingData.tileUp2 = tileUp2;
                    buildingData.tileUp3 = tileUp3;
                    buildingData.tileUp4 = tileUp4;

                    buildingData.tileLeft = tileLeft;
                    buildingData.tileLeftUp1 = tileLeftUp1;
                    buildingData.tileLeftUp2 = tileLeftUp2;
                    buildingData.tileLeftUp3 = tileLeftUp3;
                    buildingData.tileLeftUp4 = tileLeftUp4;

                    Vector3 distanceVec = Camera.main.transform.position - buildingToPlace.transform.position;
                    //Does this fix it????????????? or do we need to multiply the magnitude and the maxBuildDistance to get rid of errors
                    int sortOrder = maxBuildDistance - (int)distanceVec.magnitude;

                    Debug.Log("Distance " + distanceVec.magnitude.ToString());
                    buildingToPlace.GetComponent<SpriteRenderer>().sortingOrder = sortOrder;

                    gameData.money -= factoryMoneyCost;
                    pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - factoryPollutionCost, pollutionBarWidthHeight.y);
                    gameData.pollutionLevel += factoryPollutionCost;
                }


            }
                
            if(bm.selectedBuilding.tag == "Factory" && tileUnderMouse.clickable == true && tileUp1 != null && tileUp1.clickable == true)
            {
                tileUnderMouse.clickable = false;
				tileUp1.clickable = false;

                tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
				tileUp1.GetComponent<MeshRenderer>().material.color = Color.white;


				buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

				buildingData = buildingToPlace.GetComponent<BuildingData> ();

				buildingData.tileUnderMouse = tileUnderMouse;
				buildingData.tileUp1 = tileUp1;


				//Calculate distance from camera and assign a value?
				Vector3 distanceVec=Camera.main.transform.position-buildingToPlace.transform.position;
				//Does this fix it????????????? or do we need to multiply the magnitude and the maxBuildDistance to get rid of errors
				int sortOrder=maxBuildDistance-(int)distanceVec.magnitude;

				Debug.Log ("Distance "+distanceVec.magnitude.ToString());
				buildingToPlace.GetComponent<SpriteRenderer> ().sortingOrder = sortOrder;

                gameData.money -= factoryMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - factoryPollutionCost, pollutionBarWidthHeight.y);
                gameData.pollutionLevel += factoryPollutionCost;
                
            }

            if (bm.selectedBuilding.tag == "Water Tower" &&  tileUnderMouse.clickable == true && tileUp1 != null && tileUp1.clickable == true) 
			{
                tileUnderMouse.clickable = false;
                tileUp1.clickable = false;

				tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
				tileUp1.GetComponent<MeshRenderer>().material.color = Color.white;

				buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

				buildingData = buildingToPlace.GetComponent<BuildingData> ();

				buildingData.tileUnderMouse = tileUnderMouse;
				buildingData.tileUp1 = tileUp1;
				buildingData.tileLeft = tileLeft;
				buildingData.tileLeftUp1 = tileLeftUp1;

				//Calculate distance from camera and assign a value?
				Vector3 distanceVec=Camera.main.transform.position-buildingToPlace.transform.position;
				//Does this fix it????????????? or do we need to multiply the magnitude and the maxBuildDistance to get rid of errors
				int sortOrder=maxBuildDistance-(int)distanceVec.magnitude;

				Debug.Log ("Distance "+distanceVec.magnitude.ToString());
				buildingToPlace.GetComponent<SpriteRenderer> ().sortingOrder = sortOrder;

                gameData.money -= waterMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - waterPollutionCost, pollutionBarWidthHeight.y);
                gameData.pollutionLevel -= waterPollutionCost;

                Debug.Log(pollutionBar.sizeDelta);
			}

            if (bm.selectedBuilding.tag == "Science Building"  && tileUnderMouse.clickable == true && tileUp1 != null && tileUp1.clickable == true) 
			{
				tileUnderMouse.clickable = false;
				tileUp1.clickable = false;

				tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
				tileUp1.GetComponent<MeshRenderer>().material.color = Color.white;

				buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

				buildingData = buildingToPlace.GetComponent<BuildingData> ();

				buildingData.tileUnderMouse = tileUnderMouse;
				buildingData.tileUp1 = tileUp1;

				//Calculate distance from camera and assign a value?
				Vector3 distanceVec=Camera.main.transform.position-buildingToPlace.transform.position;
				//Does this fix it????????????? or do we need to multiply the magnitude and the maxBuildDistance to get rid of errors
				int sortOrder=maxBuildDistance-(int)distanceVec.magnitude;

				Debug.Log ("Distance "+distanceVec.magnitude.ToString());
				buildingToPlace.GetComponent<SpriteRenderer> ().sortingOrder =sortOrder;

				gameData.money -= scienceMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - sciencePollutionCost, pollutionBarWidthHeight.y);
				gameData.pollutionLevel += sciencePollutionCost;
			}



			if(bm.selectedBuilding.tag == "Tower" && tileUnderMouse.clickable == true )
            {
                tileUnderMouse.clickable = false;
                tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;

				buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

				buildingData = buildingToPlace.GetComponent<BuildingData> ();

				buildingData.tileUnderMouse = tileUnderMouse;

				//Calculate distance from camera and assign a value?
				Vector3 distanceVec=Camera.main.transform.position-buildingToPlace.transform.position;
				//Does this fix it????????????? or do we need to multiply the magnitude and the maxBuildDistance to get rid of errors
				int sortOrder=maxBuildDistance-(int)distanceVec.magnitude;

				Debug.Log ("Distance "+distanceVec.magnitude.ToString());
				buildingToPlace.GetComponent<SpriteRenderer> ().sortingOrder = sortOrder;

                gameData.money -= towerMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - towerPollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel += towerPollutionCost;
            }

            if (bm.selectedBuilding.tag == "Wind Turbine" && tileUnderMouse.clickable == true)
            {
                tileUnderMouse.clickable = false;
                tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;

                buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);
                buildingData = buildingToPlace.GetComponent<BuildingData>();
                buildingData.tileUnderMouse = tileUnderMouse;

                //Calculate distance from camera and assign a value?
                Vector3 distanceVec=Camera.main.transform.position-buildingToPlace.transform.position;
                //Does this fix it????????????? or do we need to multiply the magnitude and the maxBuildDistance to get rid of errors
                int sortOrder=maxBuildDistance-(int)distanceVec.magnitude;

                Debug.Log ("Distance "+distanceVec.magnitude.ToString());
                buildingToPlace.GetComponent<SpriteRenderer> ().sortingOrder = sortOrder;

                gameData.money -= towerMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - towerPollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel += towerPollutionCost;

            }

            if(bm.selectedBuilding.tag == "Solar Panel" && tileUnderMouse.clickable == true && tileUp1 != null && tileUp1.clickable == true)
            {
                tileUnderMouse.clickable = false;
                tileUp1.clickable = false;

                tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
                tileUp1.GetComponent<MeshRenderer>().material.color = Color.white;

                buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

                buildingData = buildingToPlace.GetComponent<BuildingData> ();

                buildingData.tileUnderMouse = tileUnderMouse;
                buildingData.tileUp1 = tileUp1;

                //Calculate distance from camera and assign a value?
                Vector3 distanceVec=Camera.main.transform.position-buildingToPlace.transform.position;
                //Does this fix it????????????? or do we need to multiply the magnitude and the maxBuildDistance to get rid of errors
                int sortOrder=maxBuildDistance-(int)distanceVec.magnitude;

                Debug.Log ("Distance "+distanceVec.magnitude.ToString());
                buildingToPlace.GetComponent<SpriteRenderer> ().sortingOrder =sortOrder;

                gameData.money -= scienceMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - sciencePollutionCost, pollutionBarWidthHeight.y);
                gameData.pollutionLevel += sciencePollutionCost;
            }
        }
    }

    void DetectBuilding(GameObject ourHitObject)
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(ourHitObject.tag == "Factory" || ourHitObject.tag == "Tower" || ourHitObject.tag == "Science Building" || ourHitObject.tag == "Water Tower" || ourHitObject.tag == "Clean Factory" || ourHitObject.tag == "Wind Turbine" || ourHitObject.tag == "Solar Panel")
            {
				sellButton.onClick.RemoveAllListeners ();
	            sellButton.onClick.AddListener(delegate { SellBuilding(ourHitObject); });

				upgradeButton.onClick.RemoveAllListeners ();
				upgradeButton.onClick.AddListener (delegate {upgradeBuilding (ourHitObject);});

                toggleUI.GetComponent<Canvas>().enabled = true;
                Debug.Log("Click");
            }
        }
    }

	public void upgradeBuilding(GameObject ourHitObject)
	{
		if (ourHitObject != null)
		{
			buildingToUpgrade = ourHitObject.GetComponent<SpriteRenderer> ();
			buildingData = ourHitObject.GetComponent<BuildingData> ();


			if (buildingData.upgraded == false)
			{		
			
				if (ourHitObject.tag == "Factory")
				{
					buildingToUpgrade.sprite = factoryUpgrade.GetComponent<SpriteRenderer> ().sprite;
					buildingToUpgrade.transform.position = new Vector3 (buildingToUpgrade.transform.position.x + 0.50f, buildingToUpgrade.transform.position.y, buildingToUpgrade.transform.position.z + 0.5f);
					buildingData.upgraded = true;
				}
				if (ourHitObject.tag == "Tower")
				{
					buildingToUpgrade.sprite = towerUpgrade.GetComponent<SpriteRenderer> ().sprite;
					buildingToUpgrade.transform.position = new Vector3 (buildingToUpgrade.transform.position.x, buildingToUpgrade.transform.position.y, buildingToUpgrade.transform.position.z);
					buildingData.upgraded = true;
				}
				if (ourHitObject.tag == "Science Building")
				{
					buildingToUpgrade.sprite = scienceBuildingUpgrade.GetComponent<SpriteRenderer> ().sprite;
					buildingToUpgrade.transform.position = new Vector3 (buildingToUpgrade.transform.position.x + 0.25f, buildingToUpgrade.transform.position.y, buildingToUpgrade.transform.position.z + 0.25f);
					buildingData.upgraded = true;
				}
				if (ourHitObject.tag == "Water Tower")
				{
					buildingToUpgrade.sprite = waterPlantUpgrade.GetComponent<SpriteRenderer> ().sprite;
					buildingToUpgrade.transform.position = new Vector3 (buildingToUpgrade.transform.position.x, buildingToUpgrade.transform.position.y, buildingToUpgrade.transform.position.z + 0.5f);
					buildingData.upgraded = true;

					
					if (tileLeft.clickable == true && tileLeftUp1.clickable == true)
					{
						buildingData.tileLeft.clickable = false;
						buildingData.tileLeftUp1.clickable = false;

						buildingData.tileLeft.GetComponent<MeshRenderer> ().material.color = Color.white;
						buildingData.tileLeftUp1.GetComponent<MeshRenderer> ().material.color = Color.white;
					}

					
				}
                if (ourHitObject.tag == "Clean Factory")
                {
                    buildingToUpgrade.sprite = cleanFactoryUpgrade.GetComponent<SpriteRenderer>().sprite;
                    buildingToUpgrade.transform.position = new Vector3 (buildingToUpgrade.transform.position.x + 0.25f, buildingToUpgrade.transform.position.y + 0.5f, buildingToUpgrade.transform.position.z + 0.25f);
                    buildingData.upgraded = true;
                }
			}
		}
	}


    public void SellBuilding(GameObject ourHitObject)
    {
        //Get tile at building or tiles if wide building and change clickable to true.
        toggleUI.GetComponent<Canvas>().enabled = false;


        if (ourHitObject != null)
        {
			buildingData = ourHitObject.GetComponent<BuildingData> ();

            if (ourHitObject.tag == "Factory")
            {
                gameData.money += factoryMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - factoryPollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= factoryPollutionCost;

				buildingData.tileUnderMouse.clickable = true;
				buildingData.tileUp1.clickable = true;

                Destroy(ourHitObject);

            }
            if (ourHitObject.tag == "Tower")
            {
                gameData.money += towerMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - towerPollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= towerPollutionCost;

				buildingData.tileUnderMouse.clickable = true;
                Destroy(ourHitObject);
            }
            if (ourHitObject.tag == "Wind Turbine")
            {
                gameData.money += windTurbineMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - windTurbinePollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= windTurbinePollutionCost;

                buildingData.tileUnderMouse.clickable = true;
                Destroy(ourHitObject);
            }
            if (ourHitObject.tag == "Solar Panel")
            {
                gameData.money += solarPanelMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - solarPanelPollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= solarPanelPollutionCost;


                buildingData.tileUnderMouse.clickable = true;
                buildingData.tileUp1.clickable = true;

                Destroy(ourHitObject);
            }
            if (ourHitObject.tag == "Science Building")
            {
                gameData.money += scienceMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - sciencePollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= sciencePollutionCost;


				buildingData.tileUnderMouse.clickable = true;
				buildingData.tileUp1.clickable = true;

                Destroy(ourHitObject);
            }
            if (ourHitObject.tag == "Water Tower")
            {
                gameData.money += waterMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - waterPollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= waterPollutionCost;

				buildingData.tileUnderMouse.clickable = true;
				buildingData.tileUp1.clickable = true;
				buildingData.tileLeft.clickable = true;
				buildingData.tileLeftUp1.clickable = true;

                Destroy(ourHitObject);
            }
            if (ourHitObject.tag == "Clean Factory")
            {
                gameData.money += waterMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - waterPollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= waterPollutionCost;

                buildingData.tileUnderMouse.clickable = true;
                buildingData.tileUp1.clickable = true;
                buildingData.tileUp2.clickable = true;
                buildingData.tileUp3.clickable = true;
                buildingData.tileUp4.clickable = true;

                buildingData.tileLeft.clickable = true;
                buildingData.tileLeftUp1.clickable = true;
                buildingData.tileLeftUp2.clickable = true;
                buildingData.tileLeftUp3.clickable = true;
                buildingData.tileLeftUp4.clickable = true;

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
