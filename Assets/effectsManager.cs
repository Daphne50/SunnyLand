using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectsManager : MonoBehaviour
{
    [SerializeField]
    float yasamas�resi;
    private void Start()
    {
        Destroy(gameObject, yasamas�resi);

    }
}
