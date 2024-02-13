using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision : MonoBehaviour
{
    [SerializeField] float LevelDelaySpawn;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] AudioClip SuccessSound;

    [SerializeField] ParticleSystem SuccessParticle;
    [SerializeField] ParticleSystem DeathParticle;

    AudioSource audioSource;


    public bool isTransitioning= false;
    public bool collisionDisabled=false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        ResponDebugKeys();
    }
    void ResponDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
       else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (isTransitioning || collisionDisabled) { return; }
        
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
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(SuccessSound);
        SuccessParticle.Play();
        GetComponent<TestScript>().enabled = false;
        Invoke("LoadNextLevel", LevelDelaySpawn);
       
    }
    void StartCrashSequence() 
    {
        isTransitioning= true;
        audioSource.Stop();
        audioSource.PlayOneShot(DeathSound);
        DeathParticle.Play();
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


