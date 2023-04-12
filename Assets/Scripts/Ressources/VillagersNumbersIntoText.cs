using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VillagersNumbersIntoText : MonoBehaviour
{
    // Singleton to counts all villagers [One Singleton to count them all]
    public static VillagersNumbersIntoText instance;

    public TextMeshProUGUI VillagerNumber;
    public TextMeshProUGUI BuilderNumber;


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
        UpdateVillagerNumber();
    }



    public void UpdateVillagerNumber()
    {
        VillagerNumber.SetText(VillagerManager.instance.GetVillagerCount().ToString());
        BuilderNumber.SetText(VillagerManager.instance.GetBuilderNumber().ToString());
    }

}
