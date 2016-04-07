using UnityEngine;
using System.Collections;

public class MainMenuAudio : MonoBehaviour 
{
    public AudioClip startClip, exitClip, optionsClip;
    public AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void PlayStart()
    {
        audioSource.clip = startClip;
        audioSource.Play();
    }

    public void PlayOptions()
    {
        audioSource.clip = optionsClip;
        audioSource.Play();
    }

    public void PlayExit()
    {
        audioSource.clip = exitClip;
        audioSource.Play();
    }

}
