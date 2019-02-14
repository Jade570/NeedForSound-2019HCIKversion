using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chordManager : MonoBehaviour {
    public AudioClip[] audio_chord_1;
    public AudioClip[] audio_chord_2;
    public AudioClip[] audio_chord_3;
    public AudioClip[] audio_chord_4;

    private AudioSource my_audio;

    public float start_time = 0f;
    //public float timer = 1f;

    // Use this for initialization
    void Start()
    {
        my_audio = this.gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        */
    }

    void changeChord(Vector3 packet)
    {
        Debug.Log(packet);

        
        int chord = (int)packet.x-1; // 1~4
        int mode = (int)packet.y-1; // 1~7

        my_audio = this.gameObject.GetComponent<AudioSource>();
        
        switch (chord)
        {
            case 0:
                my_audio.clip = audio_chord_1[mode];
                break;

            case 1:
                my_audio.clip = audio_chord_2[mode];
                break;

            case 2:
                my_audio.clip = audio_chord_3[mode];
                break;

            case 3:
                my_audio.clip = audio_chord_4[mode];
                break;
        }

        start_time = (int)packet.z;
        my_audio.time = start_time;
        my_audio.Play();

    }
}
