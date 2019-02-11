using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modes : MonoBehaviour {
    private WheelDrive driver;
    public Light lt1, lt2;



	// Use this for initialization
	void Start () {

        driver = FindObjectOfType<WheelDrive>().gameObject.GetComponent<WheelDrive>();
        driver.enabled = true;



	}
	
	// Update is called once per frame
	void Update () {
		
        if (driver.mode == 1)
        {
            lt1.color = new Color32(244, 220, 66, 255);
            lt2.color = new Color32(244, 220, 66, 255);

        }
        else if (driver.mode == 2)
        {
            lt1.color = new Color32(244, 133, 65, 255);
            lt2.color = new Color32(244, 133, 65, 255);
        }
        else if (driver.mode == 3)
        {
            lt1.color = new Color32(244, 79, 65, 255);
            lt2.color = new Color32(244, 79, 65, 255);
        }
        else if (driver.mode == 4)
        {
            lt1.color = new Color32(214, 51, 127, 255);
            lt2.color = new Color32(214, 51, 127, 255);
        }
        else if (driver.mode == 5)
        {
            lt1.color = new Color32(37, 178, 63, 255);
            lt2.color = new Color32(37, 178, 63, 255);
        }
        else if (driver.mode == 6)
        {
            lt1.color = new Color32(37, 178, 171, 255);
            lt2.color = new Color32(37, 178, 171, 255);
        }
        else if (driver.mode == 7)
        {
            lt1.color = new Color32(36, 112, 178, 255);
            lt2.color = new Color32(36, 112, 178, 255);
        }

    }
}