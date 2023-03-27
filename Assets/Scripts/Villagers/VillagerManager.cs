using System.Collections.Generic;
using UnityEngine;

public class VillagerManager : MonoBehaviour
{
    //Singleton
    public static VillagerManager instance;

    public int foodquantity = 10;

    public List<VillagerBase> villagerList = new List<VillagerBase>();
    public List<GameObject> houseList = new List<GameObject>();

    public Transform forest;
    public Transform farm;
    public Transform mine;
    public Transform wanderingPlace;


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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddVillager(VillagerBase villager)
    {
        villagerList.Add(villager);
    }

    public void AddHouse(GameObject house)
    {
        houseList.Add(house);
    }

    //public void KillVillager(VillagerBase villager)
    //{
    //    villager.Die();
    //}

    public void DayTime()
    {
        //Wakes Up villagers
        foreach (VillagerBase villager in villagerList)
        {
            villager.WakeUp();

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
        }
    }

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


        //Resets The List
        thoseToRemove = new List<VillagerBase>();
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

        //Stays positive or equal to 0 because of the while just above
        foodquantity -= villagerList.Count;


        int villagerIndex = 0;
        //Have a foreach that checks the buildings that are houses and assign them to a random villager

        foreach (GameObject house in houseList)
        {
            if (villagerIndex < villagerList.Count)
            {
                villagerList[villagerIndex].GoToSleep(house.transform);
                villagerIndex++;
            }
        }

        List<GameObject> availableHouses = houseList;

        foreach (VillagerBase villager in villagerList)
        {
            if (availableHouses.Count > 1)
            {
                GameObject randomHouse = availableHouses[Random.Range(0, availableHouses.Count)];
                villager.GoToSleep(randomHouse.transform);
                availableHouses.Remove(randomHouse);
            }
        }
        //Have the villager sleep in the house


        //if some villagers didn't get houses, they wander


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