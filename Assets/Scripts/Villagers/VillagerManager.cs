using System.Collections.Generic;
using UnityEngine;

public class VillagerManager : MonoBehaviour
{
    //Singleton
    public static VillagerManager instance;

    public int foodquantity = 10;
    public Canvas villagerViewer;

    public List<VillagerBase> villagerList = new List<VillagerBase>();
    public List<GameObject> houseList = new List<GameObject>();

    //The different locations to go to
    public Transform forest;
    public Transform farm;
    public Transform mine;
    public Transform wanderingPlace;
    public Transform school;

    //The prefabs
    public GameObject lumberjackPrefab;
    public GameObject farmerPrefab;
    public GameObject minerPrefab;
    public GameObject builderPrefab;

    [SerializeField]
    private VillagerBase selectedVillager;

    Ray ray; 
    RaycastHit hit;

    //Makes a single instance
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        villagerViewer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "Villager")
                {
                    selectedVillager = hit.transform.gameObject.GetComponent<VillagerBase>();
                    villagerViewer.enabled = true;
                    Debug.Log(hit.transform.gameObject.tag);
                }
                else
                {
                    selectedVillager = null;
                    villagerViewer.enabled = false;
                }
            }
        }
    }

    //Adds a villager to the list
    public void AddVillager(VillagerBase villager)
    {
        villagerList.Add(villager);
    }

    //Adds a house to the list
    public void AddHouse(GameObject house)
    {
        houseList.Add(house);
    }

    //
    public void ReformVillager(int workNumber)
    {
        if (selectedVillager != null)
        {
            if (selectedVillager.tired == false)
            {
                selectedVillager.GoToSchool(school, (VillagerBase.Work)workNumber);
            }
            else
            {
                Debug.Log("VillagerTooTiredToLearn");
            }
            villagerViewer.enabled = false;
        }
        else
        {
            Debug.LogError("ERROR : VillagerManager : ReformVillager : selected villager is null");
        }
    }

    //Manages Villager Behaviour when days come
    public void DayTime()
    {
        //Wakes Up villagers
        foreach (VillagerBase villager in villagerList)
        {
            villager.WakeUp();

            if (villager.tired == false)        //If villager isn't tired
            {
                if (villager.workClass == VillagerBase.Work.Lumberjack)
                {
                    //Debug.Log("Lumberjack goes to work");
                    villager.GoToWork(this.forest);
                }
                else if (villager.workClass == VillagerBase.Work.Farmer)
                {
                    //Debug.Log("Farmer goes to work");
                    villager.GoToWork(this.farm);
                }
                else if (villager.workClass == VillagerBase.Work.Miner)
                {
                    //Debug.Log("Miner goes to work");
                    villager.GoToWork(this.mine);
                }

                villager.getsTired = true;
            }
            else
            {
                Debug.Log("VillagerTooTiredToWork");
            }
        }
    }

    //Manages Villager Behaviour when night come
    public void NightTime()
    {
        //List of villager to remove once the while is over
        List<VillagerBase> thoseToRemove = new List<VillagerBase>();

        //Age the villagers and kills them if they're too old
        foreach (VillagerBase villager in villagerList)
        {
            villager.Age();

            if (villager.age > villager.deathAge)
            {
                villager.Die();
                thoseToRemove.Add(villager);
            }
        }

        //Removes the killed villagers from the list
        foreach (VillagerBase villager in thoseToRemove)
        {
            villagerList.Remove(villager);
        }


        //Resets The List (there are other villagers to kill)
        thoseToRemove = new List<VillagerBase>();

        //Infinite Loop Security
        int whileBreaker = 0;

        //Kills villagers if there isn't enough food
        while ((foodquantity < (villagerList.Count - thoseToRemove.Count)) && whileBreaker < 666)
        {
            VillagerBase villagerToDie = villagerList[(int)Random.Range(0, villagerList.Count)];
            villagerToDie.Die();
            thoseToRemove.Add(villagerToDie);
            Debug.Log("InWhile");
            whileBreaker++;
        }
        Debug.Log("OutWhile. whileBreaker = " + whileBreaker);

        //Removes the killed villagers from the list
        foreach (VillagerBase villager in thoseToRemove)
        {
            villagerList.Remove(villager);
        }

        //Stays positive or equal to 0 because of the while just above (will be modified later down the line)
        foodquantity -= villagerList.Count;

        
        //Additionnal lists that can be modified while going through all the houses and villagers
        List<GameObject> availableHouses = new();   //Not making a direct reference here
        availableHouses.AddRange(houseList);

        List<VillagerBase> tmpVillagerList = new();
        tmpVillagerList.AddRange(villagerList);

        //Tires the villagers if they worked and gives random houses to random tired villagers
        for (int i = 0; i < villagerList.Count; i++)
        {
            VillagerBase tmpVillager = tmpVillagerList[Random.Range(0, tmpVillagerList.Count)];     //Choose a random villager from tmp list

            if (tmpVillager.getsTired == true)
            {
                tmpVillager.tired = true;
                tmpVillager.getsTired = false;
            }

            if (tmpVillager.tired == true)
            {
                if (availableHouses.Count > 0)                                                          //If there's an available house
                {
                    GameObject randomHouse = availableHouses[Random.Range(0, availableHouses.Count)];   //Choose a random house
                    tmpVillager.GoToSleep(randomHouse.transform);                                       //Have the villager sleep in the house
                    availableHouses.Remove(randomHouse);                                                //Make the house unavailable
                }
                else                                                                                    //If there isn't an available house  (No House? *Megamind Stare*)
                {
                    tmpVillager.Wander(wanderingPlace);                                                 //Have the villager wander
                }                              
            }
            tmpVillagerList.Remove(tmpVillager);                                                        //Removes villager from tmp list (to not have it again)
        }
    }

    public void KillVillager(VillagerBase villager)
    {
        villagerList.Remove(villager);
        villager.Die();
    }


    public int GetBuilderNumber()
    {
        int builderNumber = 0;

        foreach (VillagerBase villager in villagerList)
        {
            if (villager.workClass == VillagerBase.Work.Builder)
            {
                builderNumber++;
            }
        }

        return builderNumber;
    }

    public int GetTiredNumber()
    {
        int tiredNumber = 0;

        foreach (VillagerBase villager in villagerList)
        {
            if (villager.tired == true)
            {
                tiredNumber++;
            }
        }

        return tiredNumber;
    }

}