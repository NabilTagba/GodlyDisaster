using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSelected : MonoBehaviour
{
    public GameObject RainButton;
    public GameObject SmiteButton;
    public GameObject GrowthButton;
    public GameObject LoveButton;

    public GameObject LastPressedButton;
    public enum powers
    {
        Rain,
        Smite,
        Growth,
        Love
    };
    public powers currentpower;

    public GameObject RainPower;
    public GameObject SmitePower;
    public GameObject GrowthPower;
    public GameObject LovePower;

    public MousePosition MousePos;

    public GameObject PlanetCenter;

    bool PowersOnCooldown = false;

    GameObject newestPowerSpawned;

    // Start is called before the first frame update
    void Start()
    {
        LastPressedButton = RainButton;
        ButtonSize();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && MousePos.OnPlanet && !PowersOnCooldown)
        {
            
            if(currentpower == powers.Rain)
            {
                newestPowerSpawned = Instantiate(RainPower, MousePos.transform.position , Quaternion.identity);
            }
            else if (currentpower == powers.Smite)
            {
                newestPowerSpawned = Instantiate(SmitePower, MousePos.transform.position, Quaternion.identity);
            }
            else if (currentpower == powers.Growth)
            {
                newestPowerSpawned = Instantiate(GrowthPower, MousePos.transform.position, Quaternion.identity);
            }
            else if (currentpower == powers.Love)
            {
                newestPowerSpawned = Instantiate(LovePower, MousePos.transform.position, Quaternion.identity);
            }
            else
            {
                newestPowerSpawned = null;
            }

            SetPowerPosition();
            

            //Destroy(newestPowerSpawned.gameObject, 5f);
        }

        if(Input.GetMouseButton(0) && newestPowerSpawned != null)
        {
            SetPowerPosition();
        }

        if(Input.GetMouseButtonUp(0) && newestPowerSpawned != null)
        {
            Destroy(newestPowerSpawned.gameObject);
        }
    }

    void SetPowerPosition()
    {
        newestPowerSpawned.transform.position = MousePos.transform.position;

        newestPowerSpawned.transform.LookAt(PlanetCenter.transform.position, transform.up);
        newestPowerSpawned.transform.Rotate(new Vector3(newestPowerSpawned.transform.rotation.x - 90,
            newestPowerSpawned.transform.rotation.y, newestPowerSpawned.transform.rotation.z));

        Vector3 awayDirection = newestPowerSpawned.transform.position - PlanetCenter.transform.position;
        awayDirection.Normalize();

        newestPowerSpawned.transform.position += awayDirection * 5;
    }

    public void SelectRain()
    {
        currentpower = powers.Rain;
        LastPressedButton.GetComponent<Outline>().effectDistance = new Vector2(5, 5);
        LastPressedButton = RainButton;
        ButtonSize();
    }
    public void SelectSmite()
    {
        currentpower = powers.Smite;
        LastPressedButton.GetComponent<Outline>().effectDistance = new Vector2(5, 5);
        LastPressedButton = SmiteButton;
        ButtonSize();
    }
    public void SelectGrowth()
    {
        currentpower = powers.Growth;
        LastPressedButton.GetComponent<Outline>().effectDistance = new Vector2(5, 5);
        LastPressedButton = GrowthButton;
        ButtonSize();
    }
    public void SelectLove()
    {
        currentpower = powers.Love;
        LastPressedButton.GetComponent<Outline>().effectDistance = new Vector2(5, 5);
        LastPressedButton = LoveButton;
        ButtonSize();
    }
    
    void ResetCoolDown()
    {
        PowersOnCooldown = false;
    }

    void ButtonSize()
    {
        LastPressedButton.GetComponent<Outline>().effectDistance = new Vector2(5, 10);
    }
}
