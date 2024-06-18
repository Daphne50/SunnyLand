using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankacarpıncaController : MonoBehaviour
{
    playerController playerController;
    TankController tankController;
    playerHealtController playerHealtController;
    private void Awake()
    {
        playerController = FindObjectOfType<playerController>();
        tankController = FindObjectOfType<TankController>();
        playerHealtController = FindObjectOfType<playerHealtController>();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            {
            tankController.darbeAlmaFCN();
            playerController.ziplazipla();
            gameObject.SetActive(false);
            playerHealtController.hasarAl();
        }







    }
}
