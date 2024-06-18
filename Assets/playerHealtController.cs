using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealtController : MonoBehaviour
{
    public int maxsaglik, gecerlisaglik;
    UIController uicontroller;

    public float yenilmezliksüresi;
    float yenilmezliksayaci;
    SpriteRenderer spriteRenderer;
    playerController playerController;
   [SerializeField]
   GameObject yokolmaefekti;

    private void Awake()
    {
        playerController = FindObjectOfType<playerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        uicontroller = FindObjectOfType<UIController>();
    }

    private void Start()
    {
        gecerlisaglik = maxsaglik;
    }
    private void Update()
    {
        yenilmezliksayaci -= Time.deltaTime;
        if (yenilmezliksayaci<=0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        }

    }

    public void hasarAl()
    {
        if (yenilmezliksayaci <= 0)
        {
            gecerlisaglik--;
            if (gecerlisaglik <= 0)
            {
                gecerlisaglik = 0;
                 gameObject.SetActive(false);
                Instantiate(yokolmaefekti, transform.position, transform.rotation);
                sesController.instance.sesefekticikar(2);
            }
            else
            {

                yenilmezliksayaci = yenilmezliksüresi;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
                playerController.geritepme();
                sesController.instance.sesefekticikar(1);
            }

            uicontroller.saglikdurumu();
        }
       
    }
    public void canarttýr()
    {
        gecerlisaglik++;
        if(gecerlisaglik>=maxsaglik)
        {
            gecerlisaglik = maxsaglik;
        }
        uicontroller.saglikdurumu();
    }

}
