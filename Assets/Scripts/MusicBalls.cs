using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBalls : MonoBehaviour
{
    private AudioSource audioSource; 
    public AudioClip[] attackSounds;
    public AudioClip[] staySound;
    public AudioClip[] flySound;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public void playAttackSound()
    {   
        if(attackSounds.Length != 0)
        {
            audioSource.clip = attackSounds[Random.Range(0,attackSounds.Length)];
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
    public void playflySound()
    {   
        if(flySound.Length != 0)
        {
            audioSource.clip = flySound[Random.Range(0,flySound.Length)];
            audioSource.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        playAttackSound();
    }
}
