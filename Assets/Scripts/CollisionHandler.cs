using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{ 
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip Finish;
    [SerializeField] AudioClip Fail;

    [SerializeField] ParticleSystem FinishParticles;
    [SerializeField] ParticleSystem FailParticles;

    AudioSource audioSource;
    ParticleSystem particleSystem2;
    bool isTransitioning = false;

    void Start()
    {
    audioSource = GetComponent<AudioSource>();
    //particleSystem = GetComponent<ParticleSystem>();
    }
 
    
    void OnCollisionEnter(Collision other)
    {
       if (isTransitioning) { return; }

       switch (other.gameObject.tag)
       {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                audioSource.PlayOneShot(Finish);
                //GetComponent<ParticleSystem>().Play();
                FinishParticles.Play();
                break;
            default:
                StartCrashSequence();
                audioSource.PlayOneShot(Fail);
                //GetComponent<ParticleSystem>().Play();
                FailParticles.Play();
                break;
       }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNewLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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