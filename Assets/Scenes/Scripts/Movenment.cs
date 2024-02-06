using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestScript : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audiosource;
    [SerializeField] float RocketSpeed = 1;
    [SerializeField] float RotationThrust;
    [SerializeField] AudioClip MainEngineSound;
 



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();

        


    }

    // Update is called once per frame
    void Update()
    {

      
        RocketMovenment();
     
    }
    private void RocketMovenment()
    {   
        if (Input.GetKey(KeyCode.Space))
        {
           
            rb.AddRelativeForce(0,RocketSpeed*Time.deltaTime,0);
            if (!audiosource.isPlaying )
            {
                audiosource.PlayOneShot(MainEngineSound);
            }
          
            
        }
        else
        {
            audiosource.Stop();
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true;
            transform.Rotate(0, 0, RotationThrust*Time.deltaTime);
            rb.freezeRotation = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true;
            transform.Rotate(0, 0, -RotationThrust*Time.deltaTime);
            rb.freezeRotation = false;
        }
    }

    
}
