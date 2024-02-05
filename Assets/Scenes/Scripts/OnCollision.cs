using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision : MonoBehaviour
{
    [SerializeField] float LevelDelaySpawn;

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            case "default":
                StartCrashSequence();
                
                break;


        }
       
    }
    void StartSuccessSequence()
    {
        GetComponent<TestScript>().enabled = false;
        Invoke("LoadNextLevel", LevelDelaySpawn);
    }
    void StartCrashSequence() 
    {   
        GetComponent<TestScript>().enabled = false;
        Invoke("ReloadLevel", LevelDelaySpawn);

    }
    void ReloadLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
     

        SceneManager.LoadScene(currenSceneIndex);
    }
    void LoadNextLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currenSceneIndex + 1;
        if (currenSceneIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            nextSceneIndex = 0;
        }
       
       
        Debug.Log(currenSceneIndex);
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene(nextSceneIndex);
    }
}


