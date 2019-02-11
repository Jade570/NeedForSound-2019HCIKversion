using UnityEngine;

public class collision : MonoBehaviour
{
   // public OSC osc;

    public int collideCheck = 0;
    public AudioSource crash;

    public GameObject object2;

    public GameObject Car;


    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {

      //  float vol = Car.GetComponent<playaudio>().volume;
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "rocks")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Instantiate(object2, transform.position, transform.rotation);
            Destroy(collision.collider.gameObject);
            collideCheck = 1;
           // crash.volume = vol;
            crash.Play();
           // Debug.Log(collideCheck);
        }
        else
        {
            collideCheck = 0;
        }
    }
}