using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform hedefplayer;
    [SerializeField]
    float MinY, MaxY;

    Vector2 sonPos;
    [SerializeField]
    Transform altZemin, ortaZemin;
    private void Start()
    {
        sonPos = transform.position;
    }
    private void Update()
    {
        KamerayiSinirla();
        zeminhareketi();
    }

    void KamerayiSinirla()
    {
        transform.position = new Vector3(hedefplayer.position.x, Mathf.Clamp(hedefplayer.position.y, MinY, MaxY), transform.position.z);
    }
    void zeminhareketi()
    {
        Vector2 aradakiMiktar = new Vector2(transform.position.x - sonPos.x, transform.position.y - sonPos.y);
        altZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f);
        ortaZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f)*.5f;

        sonPos = transform.position;
    }
}
