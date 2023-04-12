using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public abstract class VillagerBase : MonoBehaviour
{
    public int age = 0;
    public int deathAge = 15;

    public NavMeshAgent agent;

    public bool getsTired = false;
    public bool tired = false;
    public bool goesToHouse = false;
    public bool goesToSchool = false;

    
    private const double destinationReachedTreshold = 1.8;
    private Vector3 agentTarget;
    private float distanceToTarget;

    public bool isLearning = false;
    private Work futurework = Work.Nothing;

    public virtual Work workClass => Work.Nothing;

    // Start is called before the first frame update

    void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, agentTarget);
        //Debug.Log($"treshold : {destinationReachedTreshold}, distance : {distanceToTarget}");
        if (distanceToTarget < destinationReachedTreshold)
        {
            if (goesToHouse)
            {
                Sleep();
                this.tired = false;
                goesToHouse = false;

                // Debug.Log($"villager now not tired {tired}");
            }
            if (goesToSchool)
            {
                goesToSchool = false;
                // Debug.Log($"villager is learning");
                LearnNewJob();
            }
        }
    }

    //Has the villager go to the location of its work
    public void GoToWork(Transform WorkPosition)
    {
        if (agent != null)
        {
            // Debug.Log("IGoToWork");
            agentTarget = WorkPosition.position;
            agent.destination = agentTarget;
        }
        else
        {
            // Debug.LogError("ERROR : VillagerBase : GoToWork : agent is null");
        }
    }

    //Has the villager go to a house to sleep in
    public void GoToSleep(Transform HousePosition)
    {
        if (agent != null)
        {
            // Debug.Log("IGoToSleep");
            agentTarget = HousePosition.position;
            agent.destination = agentTarget;
            goesToHouse = true;
        }
        else
        {
            // Debug.LogError("ERROR : VillagerBase : GoToSleep : agent is null");
        }
    }

    public void GoToSchool(Transform SchoolPosition, Work newWork)
    {
        if (agent != null)
        {
            agentTarget = SchoolPosition.position;
            agent.destination = agentTarget;
            goesToSchool = true;

            futurework = newWork;
            // Debug.Log($"{workClass} is now a {newWork}");
        }
        else
        {
            // Debug.LogError("ERROR : VillagerBase : GoToShool : agent is null");
        }
    }

    //Has the villager "wander" in the village
    public void Wander(Transform VillagePosition)
    {
        if (agent != null)
        {
            agent.destination = VillagePosition.position;
        }
        else
        {
            // Debug.LogError("ERROR : VillagerBase : Wander : agent is null");
        }

        //Debug.Log($"villager now still tired {tired}");
    }

    //Makes the villager learn (they learn by sleeping don't question it)
    public void LearnNewJob()
    {
        isLearning = true;
        Sleep();
    }

    //Creates a new villager to replace the old one based on futurework
    public void FinishLearning()
    {
        if (futurework != Work.Nothing)
        {
            GameObject newWorker;

            switch (futurework)
            {
                case Work.Lumberjack:
                    newWorker = Instantiate(VillagerManager.instance.lumberjackPrefab, this.transform.position, this.transform.rotation);
                    newWorker.GetComponent<LumberjackBehaviour>().age = this.age;
                    newWorker.GetComponent<LumberjackBehaviour>().getsTired = true;

                    VillagerManager.instance.AddVillager(newWorker.GetComponent<LumberjackBehaviour>());
                    break;

                case Work.Farmer:
                    newWorker = Instantiate(VillagerManager.instance.farmerPrefab, this.transform.position, this.transform.rotation);
                    newWorker.GetComponent<FarmerBehaviour>().age = this.age;
                    newWorker.GetComponent<FarmerBehaviour>().getsTired = true;

                    VillagerManager.instance.AddVillager(newWorker.GetComponent<FarmerBehaviour>());
                    break;

                case Work.Miner:
                    newWorker = Instantiate(VillagerManager.instance.minerPrefab, this.transform.position, this.transform.rotation);
                    newWorker.GetComponent<MinerBehaviour>().age = this.age;
                    newWorker.GetComponent<MinerBehaviour>().getsTired = true;

                    VillagerManager.instance.AddVillager(newWorker.GetComponent<MinerBehaviour>());
                    break;

                case Work.Builder:
                    newWorker = Instantiate(VillagerManager.instance.builderPrefab, this.transform.position, this.transform.rotation);
                    newWorker.GetComponent<BuilderBehaviour>().age = this.age;
                    newWorker.GetComponent<BuilderBehaviour>().getsTired = true;

                    VillagerManager.instance.AddVillager(newWorker.GetComponent<BuilderBehaviour>());
                    break;
            }

            VillagerManager.instance.KillVillager(this);
        }
    }

    //Deactivates the villager upon entering a house
    public void Sleep()
    {
        this.gameObject.SetActive(false);
    }

    //Reactivates the villager upon leaving a house
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
