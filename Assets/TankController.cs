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
    bool yonusagm�;
    public GameObject may�nobje;
    public Transform mayinmerkeznoktasi;
    public float mayinbirakmas�resi;
    float mayinbirakmasayac;

    [Header("candurumu")]
    public int candurumu = 5;
    public GameObject patlamaefektii;
    bool yenildimi;
    public float mermis�resiartir, mayinbirakmas�resiartir;


    [Header("atesetme")]
    public GameObject mermi;
    public Transform mermimerkezi;
    public float mermiatmas�resi;
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
               // ates edildi�i zaman oluscak durumlar 
               mermisayac -= Time.deltaTime;
              if(mermisayac<=0)
                {
                    mermisayac = mermiatmas�resi;
                var Yenimermi=Instantiate(mermi, mermimerkezi.position, mermimerkezi.rotation);
                    Yenimermi.transform.localScale =bilmemneobje.localScale;

                }
                break;

            case tankdurumlari.darbealma:
                //tank darbe ald�g�nda olucak durumlar
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
                //tank hareket ett�g�nde olusacak durumlar 
                if (yonusagm�)
                {
                    bilmemneobje.position += new Vector3(harekethizi * Time.deltaTime, 0f, 0f);
                    if(bilmemneobje.position.x>saghedef.position.x)
                    {
                       bilmemneobje.localScale = Vector3.one;
                        yonusagm� = false;
                        hareketidurudrFNC();
                    }

                }
                else
                {
                    bilmemneobje.position -= new Vector3(harekethizi * Time.deltaTime, 0f, 0f);
                    if (bilmemneobje.position.x < solhdef.position.x)
                    {
                      bilmemneobje.localScale =new Vector3(-1, 1, 1);
                        yonusagm� = true;
                        hareketidurudrFNC();
                      
                    }

                }
                mayinbirakmasayac -= Time.deltaTime;
                if(mayinbirakmasayac<=0)
                {
                    mayinbirakmasayac = mayinbirakmas�resi;
                    Instantiate(may�nobje, mayinmerkeznoktasi.position, mayinmerkeznoktasi.rotation);

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

        May�nController[] mayinlar = FindObjectsOfType<May�nController>();
        if(mayinlar.Length>0)
        {
            foreach (May�nController bulunnanmayin in mayinlar)
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
            mermiatmas�resi /= mermis�resiartir;
            mayinbirakmas�resi /= mayinbirakmas�resiartir;
        }
    }
    void hareketidurudrFNC()
    {
        tankezicikutu.SetActive(true);
        gecerlidurum = tankdurumlari.atesetme;
        mermisayac = mermiatmas�resi;
        anim.SetTrigger("hareketidur");

    }

}
