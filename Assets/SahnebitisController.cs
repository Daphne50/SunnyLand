using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SahnebitisController : MonoBehaviour
{
    levelManager levelManager;
    private void Awake()
    {
        levelManager = FindObjectOfType<levelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            levelManager.instance.sahneyibitir();

        }
    }
}
