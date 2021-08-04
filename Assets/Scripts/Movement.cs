using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    SceneManager SceneManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //SceneManager = GetComponent<SceneManager>();
    }

    // Update is called once per frame
       void LCheat()
    {
        if (Input.GetKey(KeyCode.L))
        { 
            LoadNewLevel(); 
        }
        else
        {
            //particleSystem2
        }
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        LCheat();
    }


    void ProcessThrust()
    {
        
        if (Input.GetKey(KeyCode.Space))
        { 
            StartThrust(); 
            
        }
        else
        {
            StopThrust();
        }
        
    }
     
    void StartThrust()
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

    void StopThrust()
    {
        audioSource.Stop();
        MainThruster.Stop();
    }

    void ProcessRotation()
    {
       if (Input.GetKey(KeyCode.A))
        {
           TurnLeft();
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
        
        else
        {
            StopTurning();
        }
        
    }

    void TurnLeft()
    {
                //RightThruster.Play();
            LeftThruster.Stop();
            ApplyRotation(forward);
            if(!RightThruster.isPlaying)
            {
                RightThruster.Play();    
            }
    }
    
    void TurnRight()
    {
                ApplyRotation(-forward);
            RightThruster.Stop();
            //LeftThruster.Play();
            if(!LeftThruster.isPlaying)
            {
                LeftThruster.Play();    
            }
    }
    void StopTurning()
    {
            RightThruster.Pause();
            LeftThruster.Pause();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
    void LoadNewLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
