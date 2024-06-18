using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    float harekethizi;
    [SerializeField]
    float ziplamagucu;
    bool yerdemi;
    public Transform ZeminKontrolNoktasý;
    public LayerMask ZeminLayer;

    bool ikikezzýpla;

    public float geritepmesüresi, geritepmegücü;
    float geritepmesayaci;
    bool saðmi;
    public float ziplaziplagucu;
    public bool hareketetsinmi;
    fareController fareController;

    Rigidbody2D rb;
    Animator anim;

    private void Awake()
    {
        fareController = GetComponent<fareController>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        hareketetsinmi = true;
    }
    private void Update()
    {
        if(hareketetsinmi)
        {
            if (geritepmesayaci <= 0)
            {
                HareketEttir();
                ziplama();
                yonudegistir();
            }
            else
            {
                geritepmesayaci -= Time.deltaTime;
                if (saðmi)
                {
                    rb.velocity = new Vector2(-geritepmegücü, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(+geritepmegücü, rb.velocity.y);

                }
            }

        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetFloat("hiz", Mathf.Abs(rb.velocity.x));
        }
        
        anim.SetFloat("hiz", Mathf.Abs(rb.velocity.x));
        anim.SetBool("yerdemi", yerdemi);
    }  
    void HareketEttir()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * harekethizi;

        rb.velocity = new Vector2(hiz, rb.velocity.y);
    }

    void ziplama()
    {
        yerdemi = Physics2D.OverlapCircle(ZeminKontrolNoktasý.position, .2f, ZeminLayer);
        if(yerdemi)
        {
            ikikezzýpla = true;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if(yerdemi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamagucu);
                sesController.instance.sesefekticikar(3);
            } else
            {
                if(ikikezzýpla)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ziplamagucu);
                    ikikezzýpla = false;
                    sesController.instance.sesefekticikar(3);
                }
            }
            
        }
        
    }

    void yonudegistir()
    {
        Vector2 geciciscale = transform.localScale;
        if(rb.velocity.x>0)
        {
            saðmi = true;
            geciciscale.x = 1f;
        }else if(rb.velocity.x<0)
        {
            saðmi = false;
            geciciscale.x = -1f;
        }
        transform.localScale = geciciscale;
    }
    public void geritepme()
    {
        geritepmesayaci = geritepmesüresi;
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetTrigger("hasar");
    }
    public void ziplazipla()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplaziplagucu);
        sesController.instance.sesefekticikar(3);  

    }
}
