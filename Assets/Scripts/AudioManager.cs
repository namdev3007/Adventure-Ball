using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("--------- Audio ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------ Audio Clip ------")]
    public AudioClip background;
    public AudioClip coinCollect;
    public AudioClip Enemy;
    public AudioClip EnemyCollect;
    public AudioClip nextScene;
    public AudioClip dead;
    public AudioClip jump;
    //public AudioClip backGround;
    //public AudioClip backGround;
    //public AudioClip backGround;

    private void Start()
    {
        musicSource.clip = background;
        SFXSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
