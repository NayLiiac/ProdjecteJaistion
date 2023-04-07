using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light sun;
    public TimeController time;
    
    /*On modifie la position du la lumière représentant le soleil avec un mouvement de rotation, comme le mouvement
     normal du soleil autour de la terre (de point de vue terrestre, je sais que c'est la terre qui tourne autour du soleil mais
    dans notre projet gestion c'est l'inverse. C'est plus simple) en fonction de l'heure de la journée (le temps défini)*/
    private void Update()
    {
        time.UpdateTime();
        SunRotation(time.timeOfDay / time.cycleLength);
    }

    private void SunRotation(float timePercent)
    {
        sun.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
    }
}
