using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public GameObject UpArrow;
    public GameObject DownArrow;

    public GameObject NewestArrow;

    public PlanetStatus PS;

    public List<GameObject> ArrowList;

    Vector3 ArrowPos;


    // Start is called before the first frame update
    void Start()
    {

    }


    void ArrowGeneralSpawning(bool UpDown)
    {
        if (UpDown)
        {
            NewestArrow = Instantiate(UpArrow, ArrowPos, Quaternion.identity);
            NewestArrow.transform.SetParent(this.gameObject.transform);
            NewestArrow.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            NewestArrow = Instantiate(DownArrow, ArrowPos, Quaternion.identity);
            NewestArrow.transform.SetParent(this.gameObject.transform);
            NewestArrow.transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        NewestArrow.transform.localScale = new Vector3(.4f, .4f, .4f);
        ArrowList.Add(NewestArrow);
        Destroy(NewestArrow.gameObject, 2.1f);

   
        
    }

    public void HumanArrow(bool UpDown)
    {
        ArrowPos = new Vector3(PS.HumanSlider.transform.position.x,
            PS.HumanSlider.transform.position.y, PS.HumanSlider.transform.position.z);
        

        ArrowGeneralSpawning(UpDown);
    }

    public void WaterArrow(bool UpDown)
    {
        ArrowPos = new Vector3(PS.WaterSlider.transform.position.x,
            PS.WaterSlider.transform.position.y, PS.WaterSlider.transform.position.z);
        
        ArrowGeneralSpawning(UpDown);
    }
    public void ForestArrow(bool UpDown)
    {
        ArrowPos = new Vector3(PS.ForestSlider.transform.position.x,
            PS.ForestSlider.transform.position.y, PS.ForestSlider.transform.position.z);

        ArrowGeneralSpawning(UpDown);
    }
    public void AnimalArrow(bool UpDown)
    {
        ArrowPos = new Vector3(PS.AnimalSlider.transform.position.x,
            PS.AnimalSlider.transform.position.y, PS.AnimalSlider.transform.position.z);

        ArrowGeneralSpawning(UpDown);
    }
    public void CorruptionArrow(bool UpDown)
    {
        ArrowPos = new Vector3(PS.CorruptionSlider.transform.position.x,
            PS.CorruptionSlider.transform.position.y, PS.CorruptionSlider.transform.position.z);

        ArrowGeneralSpawning(UpDown);
    }

}
