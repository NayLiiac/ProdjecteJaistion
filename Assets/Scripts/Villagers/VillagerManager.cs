using System.Collections.Generic;
using UnityEngine;

public class VillagerManager : MonoBehaviour
{
    //Singleton
    public static VillagerManager instance;

    public int foodquantity = 10;

    public List<VillagerBase> villagerList = new List<VillagerBase>();
    //Building Manager here


    // Start is called before the first frame update

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


        //Asks building manager for a list of houses
        //Have a foreach that checks the buildings that are houses and assign them to a random villager
        //Assign houses to villagers
        //Have the villager sleep in the house


        //if some villagers didn't get houses, they wander


    }
}