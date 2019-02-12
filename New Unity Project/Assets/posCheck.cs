using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posCheck : MonoBehaviour
{
    private WheelDrive driver;

    public GameObject car;
    public OSC osc;


    Vector3 lastPos;
    Vector3 currentPos;
    int _time = 0; //일정 시간마다 위치변화 체크
    float slope; 

    void Start()
    {
        lastPos = car.transform.position;

        driver = FindObjectOfType<WheelDrive>().gameObject.GetComponent<WheelDrive>();
        driver.enabled = true;
    }

    void Update()
    { 
        currentPos = car.transform.position;
        _time += 1;

        if (_time % 10 == 0)
        {
            //액셀밟았는지 체크
            //슬로프 체크
            //포지션 업데이트

  
                if ((currentPos.y - lastPos.y) < -0.2) //하향중
                {
                  //  Debug.Log("하향중");
                    slope = 2;
                }

                else if ((currentPos.y - lastPos.y) > 0.2 ) //상향중
                {
                  //  Debug.Log("상향중");
                    slope = 0;

                }
                else //평지
                {
                  //  Debug.Log("평지");
                    slope = 1;
                }
               // Debug.Log(currentPos.y - lastPos.y);
                lastPos = currentPos;
                
        }
 


        
        OscMessage message3 = new OscMessage();
        message3.address = "/upDown";
        message3.values.Add(slope);
        osc.Send(message3);        


    }
    
}