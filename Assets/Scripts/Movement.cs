using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float forward = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem MainThruster;
    [SerializeField] ParticleSystem LeftThruster;
    [SerializeField] ParticleSystem RightThruster;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {
        
        if (Input.GetKey(KeyCode.Space))
        { 
            NewMethod(); 
            
        }
        else
        {
            audioSource.Stop();
            MainThruster.Stop();
        }
        
    }
     
    void NewMethod()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
                
        }
        if(!MainThruster.isPlaying)
        {
            MainThruster.Play();    
        }
    }

    void ProcessRotation()
    {
       if (Input.GetKey(KeyCode.A))
        {
            //RightThruster.Play();
            LeftThruster.Stop();
            ApplyRotation(forward);
            if(!RightThruster.isPlaying)
            {
                RightThruster.Play();    
            }
                
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-forward);
            RightThruster.Stop();
            //LeftThruster.Play();
            if(!LeftThruster.isPlaying)
            {
                LeftThruster.Play();    
            }

        }
        
        else
        {
            RightThruster.Pause();
            LeftThruster.Pause();
        }
        
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
