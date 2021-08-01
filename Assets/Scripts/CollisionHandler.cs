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
            case "Fuel":
                 Debug.Log("You have picked up fuel");
                 break;
            default:
                  ReloadLevel();
                  break;  
       }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}