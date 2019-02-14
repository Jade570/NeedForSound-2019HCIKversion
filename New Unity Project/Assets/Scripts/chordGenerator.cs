using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chordGenerator : MonoBehaviour {

    //public GameObject prefab_chord;
    //public bool isMakingChord = false;

    public GameObject obj_chord;

    public int mode = 6;
    public int chord = 4;
    float start_time = 0;

    float timer = 1f;
    float TIME_INTERVAL = 1f;

	// Use this for initialization
	void Start () {
        timer = TIME_INTERVAL;


    }

	
	// Update is called once per frame
	void FixedUpdate () {

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else {

            timer = TIME_INTERVAL;

           // GameObject chord_obj = Instantiate(prefab_chord);
            obj_chord.SendMessage("changeChord", new Vector3(chord, mode, start_time));
            changeStartTime();
        }

        //Debug.Log(chord + ":" + mode + ":" + start_time);

	}

    void changeStartTime()
    {

        if (start_time < 3f)
        {
            start_time += 1f;
        }
        else
        {
            start_time = 0f;
        }
    }

    void changeMode(Vector2 packet)
    {
        mode = (int)packet.x;
        chord = (int)packet.y;
    }
}
