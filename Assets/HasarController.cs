using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarController : MonoBehaviour
{
    playerHealtController playerHealtController;
    effectsManager effectsManager;
    playerController playerController;

    private void Awake()
    {
        playerHealtController = FindObjectOfType<playerHealtController>();
        effectsManager = FindObjectOfType<effectsManager>();
        playerController = FindObjectOfType<playerController>();

    }


    private void OnTriggerEnter2D(Collider2D  other)
    {
        if (other.tag=="Player")
        {
            playerHealtController.hasarAl();
        }
        
    }



}
