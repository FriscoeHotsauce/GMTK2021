using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneLoader : MonoBehaviour
{
      

    public void loadStartScene(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void loadPlayScene(){
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void loadCredits(){
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void exitGame(){
        Application.Quit();
    }
}
