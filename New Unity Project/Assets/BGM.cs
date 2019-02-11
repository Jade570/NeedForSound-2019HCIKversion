using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

    private WheelDrive driver;

    IEnumerator Wait()
    {
        
        yield return new WaitForSecondsRealtime(1);

    }

    void Start () {
        driver = FindObjectOfType<WheelDrive>().gameObject.GetComponent<WheelDrive>();
        driver.enabled = true;
    }
	
	
	void Update () {
		
	}
}
