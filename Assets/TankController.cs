using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField]
    Transform bilmemneobje;
    [SerializeField]
    Transform tankobje;
    public enum tankdurumlari {atesetme,darbealma,hareketetme ,sonaerdi};
    public tankdurumlari gecerlidurum;
    [Header("hareket")]
    public Animator anim;
    public float harekethizi;
    public Transform saghedef, solhdef;
    bool yonusagmý;
    public GameObject mayýnobje;
    public Transform mayinmerkeznoktasi;
    public float mayinbirakmasüresi;
    float mayinbirakmasayac;

    [Header("candurumu")]
    public int candurumu = 5;
    public GameObject patlamaefektii;
    bool yenildimi;
    public float mermisüresiartir, mayinbirakmasüresiartir;


    [Header("atesetme")]
    public GameObject mermi;
    public Transform mermimerkezi;
    public float mermiatmasüresi;
    float mermisayac;


    [Header("hasaralma")]
    public float darbesuresi;
    float darbesayaci;
    [SerializeField]
    GameObject tankezicikutu;

    private void Start()
    {
        gecerlidurum = tankdurumlari.atesetme;

    }
    private void Update()
    {
        switch (gecerlidurum)
        {
            case tankdurumlari.atesetme:
               // ates edildiði zaman oluscak durumlar 
               mermisayac -= Time.deltaTime;
              if(mermisayac<=0)
                {
                    mermisayac = mermiatmasüresi;
                var Yenimermi=Instantiate(mermi, mermimerkezi.position, mermimerkezi.rotation);
                    Yenimermi.transform.localScale =bilmemneobje.localScale;

                }
                break;

            case tankdurumlari.darbealma:
                //tank darbe aldýgýnda olucak durumlar
                if (darbesayaci > 0)
                {
                    darbesayaci -= Time.deltaTime;

                    if (darbesayaci <= 0)
                    {
                        
                        gecerlidurum = tankdurumlari.hareketetme;
                        mayinbirakmasayac = 0;
                        if(yenildimi)
                        {
                            tankobje.gameObject.SetActive(false);
                            Instantiate(patlamaefektii, transform.position, transform.rotation);
                            gecerlidurum = tankdurumlari.sonaerdi;
                        }
                    }
                }
                break;
            case tankdurumlari.hareketetme:
                //tank hareket ettýgýnde olusacak durumlar 
                if (yonusagmý)
                {
                    bilmemneobje.position += new Vector3(harekethizi * Time.deltaTime, 0f, 0f);
                    if(bilmemneobje.position.x>saghedef.position.x)
                    {
                       bilmemneobje.localScale = Vector3.one;
                        yonusagmý = false;
                        hareketidurudrFNC();
                    }

                }
                else
                {
                    bilmemneobje.position -= new Vector3(harekethizi * Time.deltaTime, 0f, 0f);
                    if (bilmemneobje.position.x < solhdef.position.x)
                    {
                      bilmemneobje.localScale =new Vector3(-1, 1, 1);
                        yonusagmý = true;
                        hareketidurudrFNC();
                      
                    }

                }
                mayinbirakmasayac -= Time.deltaTime;
                if(mayinbirakmasayac<=0)
                {
                    mayinbirakmasayac = mayinbirakmasüresi;
                    Instantiate(mayýnobje, mayinmerkeznoktasi.position, mayinmerkeznoktasi.rotation);

                }
                break;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            darbeAlmaFCN();
        }
    }

    public void darbeAlmaFCN()
    {
      
        gecerlidurum = tankdurumlari.darbealma;
        darbesayaci = darbesuresi;
        anim.SetTrigger("vur");

        MayýnController[] mayinlar = FindObjectsOfType<MayýnController>();
        if(mayinlar.Length>0)
        {
            foreach (MayýnController bulunnanmayin in mayinlar)
            {
                bulunnanmayin.patlamaefektiNFC();
            }     
        }
        candurumu--;
        if(candurumu<=0)
        {
            yenildimi = true;

        }
        else
        {
            mermiatmasüresi /= mermisüresiartir;
            mayinbirakmasüresi /= mayinbirakmasüresiartir;
        }
    }
    void hareketidurudrFNC()
    {
        tankezicikutu.SetActive(true);
        gecerlidurum = tankdurumlari.atesetme;
        mermisayac = mermiatmasüresi;
        anim.SetTrigger("hareketidur");

    }

}
