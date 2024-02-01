using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] int moveSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {

  
    }

    // Update is called once per frame
    void Update()
    {
        float Xmove=  Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float Ymove= Input.GetAxis("Horizontal")*Time.deltaTime * moveSpeed;
        transform.Translate(Ymove, 0, Xmove);
    }
}
