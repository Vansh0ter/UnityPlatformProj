using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public Button exitButton;


    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame(){
        Debug.Log("The end");
        Application.Quit();
    }
}