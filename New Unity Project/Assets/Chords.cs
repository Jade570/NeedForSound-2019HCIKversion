using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chords : MonoBehaviour {

    private WheelDrive driver;

    public GameObject reset;
    public GameObject car;

    public GameObject Wsmoke;
    public GameObject Rsmoke;
    public GameObject Gsmoke;
    public GameObject Bsmoke;


    public Material[] sky = new Material[4];

    IEnumerator Wait()
    {
        Vector3 stop = car.GetComponent<Rigidbody>().velocity;
        stop = Vector3.zero;
      
        driver.torque = 0f;
        driver.handBrake = 3000000f;
      //  Debug.Log("enumerate");
        yield return new WaitForSecondsRealtime(5);
       
    }


    // Use this for initialization
    void Start () {

        driver = FindObjectOfType<WheelDrive>().gameObject.GetComponent<WheelDrive>();
        driver.enabled = true;


        Wsmoke.SetActive(true);
        Rsmoke.SetActive(false);
        Gsmoke.SetActive(false);
        Bsmoke.SetActive(false);
      //  Debug.Log("hi");
        RenderSettings.skybox = sky[0];
    }
	
	// Update is called once per frame
	void Update () {
		if (driver.LB == true || driver.RB == true)
        {

        //    Debug.Log("****");
            car.transform.position = new Vector3(-0.24f, -4.4f, -0.14f);
            car.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
   

           StartCoroutine( Wait());
            


        }

        else if (driver.CurrentGear == 1)
        {
            RenderSettings.skybox = sky[0];

            Wsmoke.SetActive(true);
            Rsmoke.SetActive(false);
            Gsmoke.SetActive(false);
            Bsmoke.SetActive(false);


           // Debug.Log("white");

        }
        else if (driver.CurrentGear == 2)
        {
            RenderSettings.skybox = sky[1];

            Wsmoke.SetActive(false);
            Rsmoke.SetActive(true);
            Gsmoke.SetActive(false);
            Bsmoke.SetActive(false);


          //  Debug.Log("red");

        }
        else if (driver.CurrentGear == 3)
        {
            RenderSettings.skybox = sky[2];

            Wsmoke.SetActive(false);
            Rsmoke.SetActive(false);
            Gsmoke.SetActive(true);
            Bsmoke.SetActive(false);

          //  Debug.Log("green");
        }
        else if (driver.CurrentGear == 4)
        {
            RenderSettings.skybox = sky[3];

            Wsmoke.SetActive(false);
            Rsmoke.SetActive(false);
            Gsmoke.SetActive(false);
            Bsmoke.SetActive(true);

         //   Debug.Log("blue");
        }

        else
        {

            RenderSettings.skybox = sky[0];
            Wsmoke.SetActive(true);
            Rsmoke.SetActive(false);
            Gsmoke.SetActive(false);
            Bsmoke.SetActive(false);

           // Debug.Log("always");
        }













    }
}
