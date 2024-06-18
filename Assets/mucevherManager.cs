using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mucevherManager : MonoBehaviour
{

    [SerializeField]
    bool mucevhermi,kirazmi;
    bool toplandimi;
    [SerializeField]
    GameObject toplamaefekti;
    levelManager levelManager;
    UIController uIController;
    playerHealtController playerHealtController;

    private void Awake()
    {
        levelManager =FindObjectOfType<levelManager>();
        uIController = FindObjectOfType<UIController>();
        playerHealtController = FindObjectOfType<playerHealtController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !toplandimi)
        {
            if(mucevhermi)
            {
                levelManager.toplananmucevhersayisi++;
                toplandimi = true;
                Destroy(gameObject);
                uIController.mucevhersayisigüncelle();
                Instantiate(toplamaefekti, transform.position, transform.rotation);
                sesController.instance.karisiksesefekticikar(7);
            }
            if (kirazmi)
            {
                if(playerHealtController.gecerlisaglik!=playerHealtController.maxsaglik)
                {
              
                    toplandimi = true;
                    Destroy(gameObject);
                    playerHealtController.canarttýr();
                    Instantiate(toplamaefekti, transform.position, transform.rotation);
                    sesController.instance.sesefekticikar(4);
                   
                }

            }
           

        }
    }
}
