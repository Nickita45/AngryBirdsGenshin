using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyElementsSound : MonoBehaviour
{
    private AudioSource audioSource; 
    public AudioClip[] destroySounds;
    public AudioClip[] deathSound;
    public AudioClip[] staySound;
    private float randomTimeSound = 3f;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public void playDestroySound()
    {   
        if(destroySounds.Length != 0)
        {
            audioSource.clip = destroySounds[Random.Range(0,destroySounds.Length)];
            audioSource.Play();
        }
    }
    public void playDeathSound()
    {   
        if(deathSound.Length != 0)
        {
            audioSource.clip = deathSound[Random.Range(0,deathSound.Length)];
            audioSource.Play();
        }
    }
    public void playStaySound()
    {   
        if(staySound.Length != 0)
        {
            audioSource.clip = staySound[Random.Range(0,staySound.Length)];
            audioSource.Play();
        }
    }
     private void Update()
    {
        if (randomTimeSound < 0f)
        {
                playStaySound();
                randomTimeSound = Random.Range(1f, 7f);
        }
        else
        {
                randomTimeSound -= Time.deltaTime;
        }

    }
}
