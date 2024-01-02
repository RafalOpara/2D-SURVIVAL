using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip shoot;
    public AudioClip enemyTakeDmg;
    public AudioClip killEnemy;

    public AudioClip getShield;
    public AudioClip getDmg;
    public AudioClip collectExp;

    private void Start()
    {
        musicSource.clip=background;
        musicSource.Play();
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
