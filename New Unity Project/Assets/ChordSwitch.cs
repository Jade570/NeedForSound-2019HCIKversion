using UnityEngine;
using System.Collections;

public class chordSwitch : MonoBehaviour
{
    public WheelDrive driver;
   // private WheelCollider[] m_Wheels;


    public GameObject reset;
    public GameObject car;

    public GameObject Wsmoke;
    public GameObject Rsmoke;
    public GameObject Bsmoke;
    public GameObject Gsmoke;


   // ParticleSystem smoking;

    //   public OSC osc;
    public GameObject spot;
    public Material[] sky = new Material[4];
  //  Color green = new Color(0f, 0.6f, 0f, 1f);


    void Start()
    {
       // driver = FindObjectOfType<WheelDrive>().gameObject.GetComponent<WheelDrive>();
        driver.enabled = true;
        //   m_Wheels = GetComponentsInChildren<WheelCollider>();


        Wsmoke.SetActive(true);
        Rsmoke.SetActive(false);
        Bsmoke.SetActive(false);
        Gsmoke.SetActive(false);
        RenderSettings.skybox = sky[0];


        // Material particleMaterial = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
    }



    void Update()
    {


        if (driver.LB == true || driver.RB == true /* || car.transform.position.y <= -30*/ )
        {

            car.transform.position = reset.transform.position;
            car.transform.rotation = reset.transform.rotation;

           // Vector3 stop = car.GetComponent<Rigidbody>().velocity;
          //  stop = Vector3.zero;

        }

        else if (driver.CurrentGear == 1)
        {


            RenderSettings.skybox = sky[0];

            Wsmoke.SetActive(true);
            Rsmoke.SetActive(false);
            Bsmoke.SetActive(false);
            Gsmoke.SetActive(false);


        }

        else if (driver.CurrentGear == 2)
        {



            RenderSettings.skybox = sky[1];

            Wsmoke.SetActive(false);
            Rsmoke.SetActive(true);
            Bsmoke.SetActive(false);
            Gsmoke.SetActive(false);


        }
        else if (driver.CurrentGear == 3)
        {


            RenderSettings.skybox = sky[2];
            Wsmoke.SetActive(false);
            Rsmoke.SetActive(false);
            Bsmoke.SetActive(true);
            Gsmoke.SetActive(false);

        }
        else if (driver.CurrentGear == 4)
        {



            RenderSettings.skybox = sky[3];
            Wsmoke.SetActive(false);
            Rsmoke.SetActive(false);
            Bsmoke.SetActive(false);
            Gsmoke.SetActive(true);




        }
        else
        {



            RenderSettings.skybox = sky[0];
            Wsmoke.SetActive(true);
            Rsmoke.SetActive(false);
            Bsmoke.SetActive(false);
            Gsmoke.SetActive(false);

        }
    }

   /* IEnumerator Reset()
    {

        yield return new WaitForSeconds(3);
    }
*/

}
