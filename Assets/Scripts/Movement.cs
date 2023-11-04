using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   [SerializeField] float mainThrust=300f;
    [SerializeField] float rotationThrust=200f;
    [SerializeField] ParticleSystem MainEngine;

    AudioSource audioSource;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
            audioSource.Play();
            }
            MainEngine.Play();
           
        }
        else if(Input.GetKey(KeyCode.S))
        {
           rb.AddRelativeForce(Vector3.down * mainThrust * Time.deltaTime);
        }
         else
            {
                audioSource.Stop();
                 MainEngine.Stop();
            }
    }
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {   
            ApplyRotation(rotationThrust);
            
        }
        else if(Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotationThrust);
        }

    }
    void ApplyRotation(float rotationThisFrame)
    {   
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
