using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EzicikutuController : MonoBehaviour
{
    [SerializeField]
    GameObject yokolmaefekti;
    playerController playerController;
    public float kirazincikmasansý;
    public GameObject kirazobje;

    private void Awake()
    {
        playerController = FindObjectOfType<playerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("kurbaga"))
        {
            other.transform.gameObject.SetActive(false);
            Instantiate(yokolmaefekti, transform.position, transform.rotation);
            playerController.ziplazipla();
            float cikmaraligi = Random.Range(0f,100f);
            sesController.instance.sesefekticikar(0);
            if(cikmaraligi<=kirazincikmasansý)
            {
                Instantiate(kirazobje, other.transform.position, other.transform.rotation);
            }

        }
        
    }
}
