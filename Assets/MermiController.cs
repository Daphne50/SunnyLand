using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiController : MonoBehaviour
{
    public float mermihizi;

    playerHealtController playerHealtController;
    private void Awake()
    {
        playerHealtController = FindObjectOfType<playerHealtController>();
    }
    private void Update()
    {
       
        transform.position += new Vector3(-mermihizi *transform.localScale.x* Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealtController.hasarAl();
            Destroy(gameObject);
        }
        Destroy(gameObject);

    }
}
