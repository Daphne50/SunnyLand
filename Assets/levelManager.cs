using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public static levelManager instance;
    playerController playerController;
    UIController uIController;

    public string sahneadi;


    public int toplananmucevhersayisi;
    mucevherManager mucevherManager;

    private void Awake()
    {
        playerController = FindObjectOfType<playerController>();
        instance = this;
        mucevherManager = FindObjectOfType<mucevherManager>();
        uIController = FindObjectOfType<UIController>();

    }

    public void sahneyibitir()
    {
        StartCoroutine(sahneyibitrrutine());

    }
    IEnumerator sahneyibitrrutine()
    {
        yield return new WaitForSeconds(.1f);

        playerController.hareketetsinmi = false;
        yield return new WaitForSeconds(1f);
        uIController.fadeekraniac();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sahneadi);
    }
}
