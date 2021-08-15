using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        QuitGame();
    }
    void QuitGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("You have quit the game");
            Application.Quit();
        }
        else
        {
            //jhjhn
        }
    }
}
