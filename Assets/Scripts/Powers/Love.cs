using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love : MonoBehaviour
{
    public PlanetStatus PS;
    public ArrowManager AM;
    int createdEntities = 0;

    bool loveActive = true;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
        AM = GameObject.Find("Arrows").GetComponent<ArrowManager>();
        StartCoroutine(LoveCooldown());
    }

    private void OnTriggerStay(Collider collision)
    {
        if((collision.gameObject.tag == "Human") 
            && createdEntities < 2 && loveActive)
        {
            AM.HumanArrow(true);
            AM.CorruptionArrow(false);
            DuplicateEntity(collision.gameObject);
        }
        else if((collision.gameObject.tag == "Lion" || collision.gameObject.tag == "Chicken" || collision.gameObject.tag == "Wolf")
            && createdEntities < 2 && loveActive)
        {
            AM.AnimalArrow(true);
            AM.CorruptionArrow(false);
            DuplicateEntity(collision.gameObject);
        }
    }

    void DuplicateEntity(GameObject dupe)
    {
        loveActive = false;
        Instantiate(dupe.gameObject, dupe.transform.position, Quaternion.identity);

        createdEntities++;

        PS.CorruptionCounter -= 2;
        if (PS.CorruptionCounter < 0)
        {
            PS.CorruptionCounter = 0;
        }
    }

    IEnumerator LoveCooldown()
    {
        while (true)
        {
            createdEntities = 0;
            loveActive = true;
            yield return new WaitForSeconds(.95f);
        }
    }
}
