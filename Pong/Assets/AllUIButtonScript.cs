using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllUIButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int levelNum){
        Debug.Log("Created by Bhaswara Arizon - 149251970101-175");
        SceneManager.LoadSceneAsync(levelNum);
    }

    public void Quit(){
        SceneManager.LoadSceneAsync("Main Menu");
    }
}

