using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public PlanetStatus PS;
    public ArrowManager AM;
    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
        AM = GameObject.Find("Arrows").GetComponent<ArrowManager>();
        StartCoroutine(PlaceArrow());
    }

    private void FixedUpdate()
    {
        PS.WaterCounter += .1f;
        if (PS.WaterCounter > 100)
        {
            PS.WaterCounter = 100;
        }
    }

    IEnumerator PlaceArrow()
    {
        while (true)
        {
            AM.WaterArrow(true);
            yield return new WaitForSeconds(2f);
        }
    }
}
