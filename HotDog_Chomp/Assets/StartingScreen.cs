using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreen : MonoBehaviour
{
    public string levelToLoad; 
    void Start()
    {
        
    }

    
    void Update()
    {
        float mouse = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(mouse) > 0.2f) {
            SceneManager.LoadScene(levelToLoad);
        }

    }
}
