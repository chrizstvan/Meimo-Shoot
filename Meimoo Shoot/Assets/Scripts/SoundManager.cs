using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SoundManager : MonoSingleton<SoundManager>
{
    public override void Init()
    {
        base.Init();

        _audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(_audioSource);
    }

    [SerializeField] AudioClip _shot;
    [SerializeField] AudioClip _enemyHit;
    AudioSource _audioSource;



    public void ShotSoundPlay()
    {
        _audioSource.PlayOneShot(_shot);
    }

    public void EnemyHitSound()
    {
        _audioSource.PlayOneShot(_enemyHit);    
    }
}
