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

	public int maxBuildDistance =40;

	public GameObject towerUpgrade;
	public GameObject waterPlantUpgrade;
	public GameObject scienceBuildingUpgrade;
	public GameObject factoryUpgrade;

	public GameObject buildingToPlace;

	public BuildingData buildingData;

	TileColorChange tileUnderMouse;
	TileColorChange tileAbove;
	TileColorChange tileLeft;
	TileColorChange tileAboveLeft;

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
			tileAbove = tileUnderMouse.tileAbove.GetComponent<TileColorChange> ();
			tileLeft = tileUnderMouse.tileLeft.GetComponent<TileColorChange> ();
			tileAboveLeft = tileUnderMouse.tileAboveLeft.GetComponent<TileColorChange> ();

			if(bm.selectedBuilding.tag == "Factory" && tileUnderMouse.tileAbove != null && tileUnderMouse.clickable == true && tileAbove.clickable == true)
            {
                tileUnderMouse.clickable = false;
				tileAbove.clickable = false;

                tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
				tileAbove.GetComponent<MeshRenderer>().material.color = Color.white;


				buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

				buildingData = buildingToPlace.GetComponent<BuildingData> ();

				buildingData.tileUnderMouse = tileUnderMouse;
				buildingData.tileAbove = tileAbove;


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

			if (bm.selectedBuilding.tag == "Water Tower" && tileUnderMouse.tileAbove != null && tileUnderMouse.clickable == true && tileAbove.clickable == true) 
			{
				tileUnderMouse.clickable = false;
				tileAbove.clickable = false;

				tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
				tileAbove.GetComponent<MeshRenderer>().material.color = Color.white;

				buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

				buildingData = buildingToPlace.GetComponent<BuildingData> ();

				buildingData.tileUnderMouse = tileUnderMouse;
				buildingData.tileAbove = tileAbove;
				buildingData.tileLeft = tileLeft;
				buildingData.tileAboveLeft = tileAboveLeft;

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

			if (bm.selectedBuilding.tag == "Science Building" && tileUnderMouse.tileAbove != null && tileUnderMouse.clickable == true && tileAbove.clickable == true) 
			{
				tileUnderMouse.clickable = false;
				tileAbove.clickable = false;

				tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
				tileAbove.GetComponent<MeshRenderer>().material.color = Color.white;

				buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

				buildingData = buildingToPlace.GetComponent<BuildingData> ();

				buildingData.tileUnderMouse = tileUnderMouse;
				buildingData.tileAbove = tileAbove;

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

            if (bm.selectedBuilding.tag == "Church" && tileUnderMouse != null && tileUnderMouse.clickable == true && tileAbove.clickable == true && tileAbove.tileAbove.GetComponent<TileColorChange>().clickable == true && tileAbove.tileAbove.GetComponent<TileColorChange>().tileAbove.GetComponent<TileColorChange>().clickable == true && tileAbove.tileAbove.GetComponent<TileColorChange>().tileAbove.GetComponent<TileColorChange>().tileAbove.GetComponent<TileColorChange>().clickable == true)
            {
                tileUnderMouse.clickable = false;
                tileAbove.clickable = false;
                tileAbove.tileAbove.GetComponent<TileColorChange>().clickable = false;
                tileAbove.tileAbove.GetComponent<TileColorChange>().tileAbove.GetComponent<TileColorChange>().clickable = false;
                tileAbove.tileAbove.GetComponent<TileColorChange>().tileAbove.GetComponent<TileColorChange>().tileAbove.GetComponent<TileColorChange>().clickable = false;


                tileUnderMouse.GetComponent<MeshRenderer>().material.color = Color.white;
                tileAbove.GetComponent<MeshRenderer>().material.color = Color.white;


                buildingToPlace=(GameObject)Instantiate(bm.selectedBuilding, new Vector3(ourHitObject.transform.position.x + bm.selectedBuilding.transform.position.x, ourHitObject.transform.position.y + bm.selectedBuilding.transform.position.y, ourHitObject.transform.position.z + bm.selectedBuilding.transform.position.z), bm.selectedBuilding.transform.rotation);

                buildingData = buildingToPlace.GetComponent<BuildingData> ();

                buildingData.tileUnderMouse = tileUnderMouse;
                buildingData.tileAbove = tileAbove;

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
            if(ourHitObject.tag == "Factory" || ourHitObject.tag == "Tower" || ourHitObject.tag == "Science Building" || ourHitObject.tag == "Water Tower" || ourHitObject.tag == "Church")
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

					if (buildingData.upgraded == true)
					{
						if (tileLeft.clickable == true && tileAboveLeft.clickable == true)
						{
							buildingData.tileLeft.clickable = false;
							buildingData.tileAboveLeft.clickable = false;

							buildingData.tileLeft.GetComponent<MeshRenderer> ().material.color = Color.white;
							buildingData.tileAboveLeft.GetComponent<MeshRenderer> ().material.color = Color.white;
						}

					}
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
				buildingData.tileAbove.clickable = true;

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
            if (ourHitObject.tag == "Science Building")
            {
                gameData.money += scienceMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - sciencePollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= sciencePollutionCost;


				buildingData.tileUnderMouse.clickable = true;
				buildingData.tileAbove.clickable = true;

                Destroy(ourHitObject);
            }
            if (ourHitObject.tag == "Water Tower")
            {
                gameData.money += waterMoneyCost;
                pollutionBar.sizeDelta = new Vector2(pollutionBarWidthHeight.x - waterPollutionCost, pollutionBarWidthHeight.y);

                gameData.pollutionLevel -= waterPollutionCost;


				buildingData.tileUnderMouse.clickable = true;
				buildingData.tileAbove.clickable = true;
				buildingData.tileLeft.clickable = true;
				buildingData.tileAboveLeft.clickable = true;

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
