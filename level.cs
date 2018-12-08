using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour {

    // parameters
    [SerializeField] int Blocks; // Seralized for debugging purposes

    // cashed reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        Blocks++;      
    }

    public void BlockDestroyed()
    {
        Blocks--;
        if (Blocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
