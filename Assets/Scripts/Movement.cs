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
        
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
                
            }
            MainThruster.Play();
            
        }
        else
        {
            audioSource.Stop();
            MainThruster.Pause();
        }
        
    }
    void ProcessRotation()
    {
       if (Input.GetKey(KeyCode.A))
        {
            RightThruster.Play();
            LeftThruster.Pause();
            ApplyRotation(forward);
        }
                
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-forward);
            RightThruster.Pause();
            LeftThruster.Play();
            
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
