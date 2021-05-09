using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    public Transform target;// need on koordinaadid, mida kaamera jälgib
    public Transform farBG;// need on far BG koordinaadid
    public Transform midBG;// need on middle BG koordinaadid
    private float lastposY;
    //public float minHeight, maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        lastposY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        float amontToMoveY = transform.position.y - lastposY;
         farBG.position += new Vector3( 0f, amontToMoveY, 0f);
        lastposY = transform.position.y;
        midBG.position += new Vector3( 0f, amontToMoveY * 0.90f, 0f);
    }
}
