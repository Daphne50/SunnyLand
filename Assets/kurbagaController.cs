using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kurbagaController : MonoBehaviour
{
    public float harekethizi;
    public Transform solhedef, saghedef;
    bool sagdamý;
    Rigidbody2D rb;
    public SpriteRenderer sr;
    Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    private void Start()
    {
        saghedef.parent = null;
        solhedef.parent = null;
        sagdamý = true;
       
    }
    private void Update()
    {
        
        {
            if (sagdamý)
            {
                rb.velocity = new Vector2(harekethizi, rb.velocity.y);
                sr.flipX = true;
                if (transform.position.x > saghedef.position.x)
                {
                    sagdamý = false;
                }
               

            }
            else
            {
                rb.velocity = new Vector2(-harekethizi, rb.velocity.y);
                sr.flipX = false;
                if (transform.position.x < solhedef.position.x)
                {
                    sagdamý = true;
                }
               
              //  anim.SetBool("hareketediyor", true);
            }
          
            
                }
            }
        }
    




        
    


    

