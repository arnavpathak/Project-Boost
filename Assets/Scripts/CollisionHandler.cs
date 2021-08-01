using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
       //Debug.Log("The game object is:" + other.gameObject.name);
       switch (other.gameObject.tag)
       {
           case "Friendly":
               Debug.Log("This object is friendly");
               break;
            case "Finish":
                Debug.Log("Congrats, you have finished the level");
                LoadNewLevel();
                break;
            default:
                ReloadLevel();
                break;
       }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNewLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
}