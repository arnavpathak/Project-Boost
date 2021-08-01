using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
       switch (other.gameObject.tag)
       {
           case "Friendly":
               Debug.Log("This object is friendly");
               break;
            case "Finish":
                Debug.Log("Congrats, you have finished the level");
                break;
            case "Untagged":
                ReloadLevel();
                break;  
       }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}