using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision : MonoBehaviour
{
    [SerializeField] float LevelDelaySpawn;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] AudioClip SuccessSound;

    AudioSource audioSource;


    public bool isTransitioning= false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (!isTransitioning)
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
       
       
    }
    void StartSuccessSequence()
    {   
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(SuccessSound);
        GetComponent<TestScript>().enabled = false;
        Invoke("LoadNextLevel", LevelDelaySpawn);
    }
    void StartCrashSequence() 
    {
        isTransitioning= true;
        audioSource.Stop();
        audioSource.PlayOneShot(DeathSound);
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


