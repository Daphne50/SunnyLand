using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesController : MonoBehaviour
{
    public static sesController instance;
    public AudioSource[] sesefektleri;
    private void Awake()
    {
        instance = this;
    }

    public void sesefekticikar(int hangises)
    {
        sesefektleri[hangises].Stop();
        sesefektleri[hangises].Play();
    }
    public void karisiksesefekticikar(int hangises)
    {
        sesefektleri[hangises].Stop();
        sesefektleri[hangises].pitch = Random.Range(0.8f,1.3f);
        sesefektleri[hangises].Play();
    }
}
