using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankeziciController : MonoBehaviour
{
    playerController playerController;
    TankController tankController;
    private void Awake()
    {
        playerController = FindObjectOfType<playerController>();
        tankController = FindObjectOfType<TankController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& playerController.transform.position.y>transform.position.y)
        {
            tankController.darbeAlmaFCN();
            playerController.ziplazipla();
            gameObject.SetActive(false);

        }
        
    }
}
