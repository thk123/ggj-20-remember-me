using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public List<AudioClip> soundEffects;
    AudioSource MyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()    {
        
    }

    public void playAudio()
    {
        if(!MyAudioSource.isPlaying)
        {
            int randomClip = Random.Range(0, soundEffects.Count);

            MyAudioSource.clip = soundEffects[randomClip];
            MyAudioSource.Play();
        }
    }

    public void stopAudio()
    {
        if (MyAudioSource.isPlaying)
        {
            MyAudioSource.Stop();
        }
    }
}
