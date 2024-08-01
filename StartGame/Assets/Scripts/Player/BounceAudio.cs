using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioSource _bigSound;
    [SerializeField] private float _collisionSensitivity;
    [SerializeField] private float _bigSoundToleranceMultipler;

    private void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude > _collisionSensitivity)
        {
            if (other.relativeVelocity.magnitude > _collisionSensitivity * _bigSoundToleranceMultipler)
            {
                _bigSound.Play();
                return;
            }
            _sound.Play();
        }
    }
}
