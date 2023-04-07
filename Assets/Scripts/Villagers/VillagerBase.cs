using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AI;

public abstract class VillagerBase : MonoBehaviour
{
    public int age = 0;
    public int deathAge = 10;
    public bool tired = false; 

    public NavMeshAgent agent;

    //public Work workClass = Work.Nothing;
    public virtual Work workClass => Work.Nothing;

    // Start is called before the first frame update

    void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Has the villager go to the location of its work
    public void GoToWork(Transform WorkPosition)
    {
        if (agent != null)
        {
            agent.destination = WorkPosition.position;
        }
        else
        {
            Debug.LogError("ERROR : VillagerBase : GoToWork : agent is null");
        }
    }

    //Has the villager go to a house to sleep in
    public void GoToSleep(Transform HousePosition)
    {
        if (agent != null)
        {
            agent.destination = HousePosition.position;
        }
        else
        {
            Debug.LogError("ERROR : VillagerBase : GoToSleep : agent is null");
        }

        this.tired = false;
        Debug.Log($"villager now not tired {tired}");

        //Sleep();
    }

    public void GoToSchool(Transform SchoolPosition, Work newWork)
    {
        if (agent != null)
        {
            agent.destination = SchoolPosition.position;
            Debug.Log($"{workClass} is now a {newWork}");
        }
        else
        {
            Debug.LogError("ERROR : VillagerBase : GoToShool : agent is null");
        }
    }

    //Has the villager wander in the village
    public void Wander(Transform VillagePosition)
    {
        if (agent != null)
        {
            agent.destination = VillagePosition.position;
        }
        else
        {
            Debug.LogError("ERROR : VillagerBase : Wander : agent is null");
        }

        Debug.Log($"villager now still tired {tired}");
    }

    //Deactivates the villager upon entering a house
    public void Sleep()
    {
        this.gameObject.SetActive(false);
    }

    //Reactivates the villager upon entering a house
    public void WakeUp()
    {
        this.gameObject.SetActive(true);
    }

    //Ages the villager
    public void Age()
    {
        this.age += 1;
    }

    //Kill the villager (you monster)
    public void Die()
    {
        Destroy(this.gameObject);
    }

    public enum Work
    {
        Wanderer,
        Lumberjack,
        Miner,
        Farmer,
        Builder,
        Nothing
    }
}
