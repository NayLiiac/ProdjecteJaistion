using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackBehaviour : VillagerBase
{
    public override Work workClass => Work.Lumberjack;
    // Start is called before the first frame update
    void Start()
    {
        //this.workClass = Work.Lumberjack;
    }

    
}
