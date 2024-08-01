using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactableobject : MonoBehaviour
{
    private Player _player;

    [SerializeField] private float _speedx;
    [SerializeField] private float _speedy;
    [SerializeField] private float _speedz;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.RB.velocity = new Vector3(_speedx, _speedy, _speedz);
        }
    }
}