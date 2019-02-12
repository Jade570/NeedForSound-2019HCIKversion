using UnityEngine;
using System;
using System.Collections;

[Serializable]
public enum DriveType
{
	RearWheelDrive,
	FrontWheelDrive,
	AllWheelDrive
}

[RequireComponent(typeof(AudioSource))]

public class WheelDrive : MonoBehaviour
{
 //   public float xpos, ypos, zrot;
    public float volume;
    public int mode;
    public int CurrentGear;
    public GameObject[,] ChordsAdress = new GameObject[5,8];
    public AudioSource[,] chords = new AudioSource[5,8];
    AudioSource sample;
    public float torque;
    public float handBrake;

    bool timecheck;
    public bool LB, RB;

    public OSC osc;




    [Tooltip("Maximum steering angle of the wheels")]
    public float maxAngle = 30f;
    [Tooltip("Maximum torque applied to the driving wheels")]
    public float maxTorque = 300f;
    [Tooltip("Maximum brake torque applied to the driving wheels")]
    public float brakeTorque = 30000f;
    [Tooltip("If you need the visual wheels to be attached automatically, drag the wheel shape here.")]
    public GameObject wheelShape;

    [Tooltip("The vehicle's speed when the physics engine can use different amount of sub-steps (in m/s).")]
    public float criticalSpeed = 5f;
    [Tooltip("Simulation sub-steps when the speed is above critical.")]
    public int stepsBelow = 5;
    [Tooltip("Simulation sub-steps when the speed is below critical.")]
    public int stepsAbove = 1;

    [Tooltip("The vehicle's drive type: rear-wheels drive, front-wheels drive or all-wheels drive.")]
    public DriveType driveType;

    private WheelCollider[] m_Wheels;

    // Find all the WheelColliders down in the hierarchy.
    void Start()
    {

        OscMessage message0 = new OscMessage();
        message0.address = "/toggle";
        int toggle = 1;
        message0.values.Add(toggle);
        osc.Send(message0);




        timecheck = true; 
        m_Wheels = GetComponentsInChildren<WheelCollider>();

        for (int i = 0; i < m_Wheels.Length; ++i)
        {
            var wheel = m_Wheels[i];

            // Create wheel shapes only when needed.
            if (wheelShape != null)
            {
                var ws = Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }
        }

        CurrentGear = 1;
      
    }

    // This is a really simple approach to updating wheels.
    // We simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero.
    // This helps us to figure our which wheels are front ones and which are rear.
    void Update()
    {
        //조이스틱 키 설정
      
        LB = Input.GetKeyDown(KeyCode.JoystickButton0);
        RB = Input.GetKeyDown(KeyCode.JoystickButton1);

        bool[] gear = new bool[4];
        gear[0] = Input.GetKeyDown(KeyCode.JoystickButton2);
        gear[1] = Input.GetKeyDown(KeyCode.JoystickButton3);
        gear[2] = Input.GetKeyDown(KeyCode.JoystickButton4);
        gear[3] = Input.GetKeyDown(KeyCode.JoystickButton5);

        for (int i = 0; i < 4; i++)
        {
            if (gear[i] == true) CurrentGear = i + 1;

        }


        m_Wheels[0].ConfigureVehicleSubsteps(criticalSpeed, stepsBelow, stepsAbove);

        float angle = maxAngle * Input.GetAxis("Horizontal");
       
        // Debug.Log(angle);
        if (angle == -15) mode = 7;
        else if (angle < -12) mode = 6;
        else if (angle < -4) mode = 5;
        else if (angle < 1.5) mode = 1;
        else if (angle < 8) mode = 2;
        else if (angle < 15) mode = 3;
        else mode = 4;

        // 로 프 에 아 리 믹 도 순서로 소리 배치
         torque = -1 * Input.GetAxis("Vertical") * maxTorque + maxTorque;

        volume = torque / maxTorque / 2;
         handBrake = /* Input.GetKey(KeyCode.X) ? brakeTorque : 0 */ -1 * Input.GetAxis("Brake") * brakeTorque + brakeTorque;


        //         Debug.Log(angle + " "  + torque + " " + handBrake );


        //코드 소리 재생 부분
        for (int i = 1; i <= 4; i++) {
            for (int j = 1; j <= 7; j++) {
                ChordsAdress[i, j] = GameObject.Find(i + "-" + j);
                chords[i, j] = ChordsAdress[i, j].GetComponent<AudioSource>();
            }
        }




        for (int i = 1; i <= 4; i++)
        {
            for (int j = 1; j <= 7; j++)
            {

                // Debug.Log(chords[i, j]);
                //Debug.Log(angle + "&" + mode);


                            if (i==CurrentGear && j == mode) {
                    sample = chords[i, j];

                            if (sample.time >= 3.95 || sample.time <= 0)
                            {
                               // Debug.Log(CurrentGear + " & " + mode);
                                sample.Stop();
                                sample = chords[i, j];
                                timecheck = false;

                                sample.time = 0.01f;
                                sample.Play();

                                timecheck = true;
                                // Debug.Log(sample.time);
                            }
                            else if (sample.time >= 0.95 && sample.time <= 1)
                            {
                               // Debug.Log(CurrentGear + " & " + mode);
                        sample.Stop();
                        sample = chords[i, j];
                                
                                timecheck = false;

                                sample.time = 1.01f;
                                sample.Play();
                                timecheck = true;
                                // Debug.Log(sample.time);
                            }
                            else if (sample.time >= 1.95 && sample.time <= 2)
                            {
                               // Debug.Log(CurrentGear + " & " + mode);
                        sample.Stop();
                        sample = chords[i, j];
                               
                                timecheck = false;

                                sample.time = 2.01f;
                                sample.Play();
                                timecheck = true;
                                //   Debug.Log(sample.time);
                            }
                            else if (sample.time >= 2.95 && sample.time <= 3)
                            {
                               // Debug.Log(CurrentGear + " & " + mode);
                        sample.Stop();
                        sample = chords[i, j];
                               
                                timecheck = false;

                                sample.time = 3.01f;
                                sample.Play();
                                timecheck = true;
                                // Debug.Log(sample.time);
                            }
                        }


                        }

                    }
  
    
        //  Debug.Log(sample.time);



        foreach (WheelCollider wheel in m_Wheels)
        {
            // A simple car where front wheels steer while rear ones drive.
            if (wheel.transform.localPosition.z > 0)
                wheel.steerAngle = angle;

            if (wheel.transform.localPosition.z < 0)
            {
                wheel.brakeTorque = handBrake;
            }

            if (wheel.transform.localPosition.z < 0 && driveType != DriveType.FrontWheelDrive)
            {
                wheel.motorTorque = torque;
            }

            if (wheel.transform.localPosition.z >= 0 && driveType != DriveType.RearWheelDrive)
            {
                wheel.motorTorque = torque;
            }

            // Update visual wheels if any.
            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                // Assume that the only child of the wheelcollider is the wheel shape.
                Transform shapeTransform = wheel.transform.GetChild(0);
                shapeTransform.position = p;
                shapeTransform.rotation = q;
            }
        }



        //OSC senders

        OscMessage message = new OscMessage();
        message.address = "/mode";
        message.values.Add(mode);
        osc.Send(message);

        OscMessage message2 = new OscMessage();
        message.address = "/vol";
        message.values.Add(volume);
        osc.Send(message2);

    }
  


}
    
