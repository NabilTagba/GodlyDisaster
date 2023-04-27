using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : MonoBehaviour
{
    public PlanetStatus PS;
    public ArrowManager AM;
    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
        AM = GameObject.Find("Arrows").GetComponent<ArrowManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Destroy Plant
        if (collision.gameObject.tag == "Tree")
        {
            AM.ForestArrow(false);
            AM.CorruptionArrow(true);
            ChangeCorruption(1.5f);
            Destroy(collision.gameObject);
        }
        //Destroy Human
        if (collision.gameObject.tag == "Human")
        {
            AM.HumanArrow(false);
            AM.CorruptionArrow(true);
            ChangeCorruption(1.5f);
            Destroy(collision.gameObject);
        }
        //Destroy Animal
        if (collision.gameObject.tag == "Lion" || collision.gameObject.tag == "Chicken" || collision.gameObject.tag == "Wolf")
        {
            AM.AnimalArrow(false);
            AM.CorruptionArrow(true);
            ChangeCorruption(1.5f);
            Destroy(collision.gameObject);
        }
    }

    void ChangeCorruption(float i)
    {
        
        PS.CorruptionCounter += i;
        if (PS.CorruptionCounter > 100)
        {
            PS.CorruptionCounter = 100;
        }
    }
}
