using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{ 
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip Finish;
    [SerializeField] AudioClip Fail;
    AudioSource audioSource;

    void OnCollisionEnter(Collision other)
    {
        audioSource = GetComponent<AudioSource>();
       //Debug.Log("The game object is:" + other.gameObject.name);
       switch (other.gameObject.tag)
       {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                audioSource.PlayOneShot(Finish);
                break;
            default:
                StartCrashSequence();
                audioSource.PlayOneShot(Fail);
                break;
       }
    }

    void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNewLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
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