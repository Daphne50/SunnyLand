using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayınController : MonoBehaviour
{
    public GameObject patlamaefekti;
    playerHealtController playerHealtController;

    private void Awake()
    {
        playerHealtController = FindObjectOfType<playerHealtController>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            patlamaefektiNFC();
            
            playerHealtController.hasarAl();
        }
        
    }
    public void patlamaefektiNFC()
    {
        Destroy(this.gameObject);
        Instantiate(patlamaefekti, transform.position, transform.rotation);

    }
    
}
