using UnityEngine;

public class Collision : MonoBehaviour
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
                  Debug.Log("You have blown up");
                  break;  
       }
    }
}