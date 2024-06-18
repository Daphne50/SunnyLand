using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectsManager : MonoBehaviour
{
    [SerializeField]
    float yasamasüresi;
    private void Start()
    {
        Destroy(gameObject, yasamasüresi);

    }
}
