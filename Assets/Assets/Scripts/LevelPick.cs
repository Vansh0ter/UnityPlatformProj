using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPick : MonoBehaviour
{
    public void Lev1()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Lev2()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Lev3()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Lev4()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void Lev5()
    {
        SceneManager.LoadSceneAsync(5);
    }
}
