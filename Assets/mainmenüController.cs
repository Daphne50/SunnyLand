using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class mainmenüController : MonoBehaviour
{
    public GameObject resimobje;
    public GameObject baslabutonu, cıkısbutonu;
    public string sahneadi;
    public GameObject fadescreen;


    private void Start()
    {
        StartCoroutine(siraylaacroutine());

    }
    IEnumerator siraylaacroutine()
    {
        yield return new WaitForSeconds(.1f);
        resimobje.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(.4f);
        baslabutonu.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        baslabutonu.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.4f);
        cıkısbutonu.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        cıkısbutonu.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);

    }


    public void oyunabasla()
    {
        StartCoroutine(oyunuacroutuni());
    }
    public void oyundancikis()
    {
        Application.Quit();
    }
    IEnumerator oyunuacroutuni()
    {
        yield return new WaitForSeconds(.1f);
        fadescreen.GetComponent<CanvasGroup>().DOFade(1, 1f);

       /* yield return new WaitForSeconds(1f);
        fadescreen.GetComponent<CanvasGroup>().DOFade(0, 1f);*/

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sahneadi);
    }
}
