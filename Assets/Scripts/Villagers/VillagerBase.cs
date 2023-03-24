using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public abstract class VillagerBase : MonoBehaviour
{
    public int age = 0;
    public int deathAge = 10;
    public bool tired = false;

    //public Work workClass = Work.Nothing;
    public virtual Work workClass => Work.Nothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Has the villager go to the location of its work
    public void GoToWork(Vector2 WorkPosition)
    {

    }

    //Has the villager go to a house to sleep in
    public void GoToSleep(Vector2 HousePosition)
    {


        this.tired = false;

        Sleep();
    }

    //Has the villager wander in the village
    public void Wander()
    {

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
