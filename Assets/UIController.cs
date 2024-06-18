using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image kalp1, kalp2, kalp3;
    [SerializeField]
    Sprite dolukalp, boskalp,yarimkalp;
    playerHealtController playerHealtController;
    [SerializeField]
    TMP_Text mucevhertxt;
    levelManager levelManager;
    public GameObject fadescreeen;


    private void Awake()
    {
        playerHealtController = FindObjectOfType<playerHealtController>();
        levelManager = FindObjectOfType<levelManager>();
    }
    public void saglikdurumu()
    {
        switch(playerHealtController.gecerlisaglik)
        {
            case 6:
                kalp1.sprite = dolukalp;
                kalp2.sprite = dolukalp;
                kalp3.sprite = dolukalp;
                break;
            case 5:
                kalp1.sprite = dolukalp;
                kalp2.sprite = dolukalp;
                kalp3.sprite = yarimkalp;
                break;
            case 4:
                kalp1.sprite = dolukalp;
                kalp2.sprite = dolukalp;
                kalp3.sprite = boskalp;
                break;
            case 3:
                kalp1.sprite = dolukalp;
                kalp2.sprite = yarimkalp;
                kalp3.sprite = boskalp;
                break;
            case 2:
                kalp1.sprite = dolukalp;
                kalp2.sprite = boskalp;
                kalp3.sprite = boskalp;
                break;
            case 1:
                kalp1.sprite = yarimkalp;
                kalp2.sprite = boskalp;
                kalp3.sprite = boskalp;
                break;
            case 0:
                kalp1.sprite = boskalp;
                kalp2.sprite = boskalp;
                kalp3.sprite = boskalp;
                break;
        }
    }
    public void mucevhersayisigüncelle()
    {
        mucevhertxt.text = levelManager.toplananmucevhersayisi.ToString();
    }
    public void fadeekraniac()
    {
        fadescreeen.GetComponent<CanvasGroup>().DOFade(1, 0.4f);

    }

}
