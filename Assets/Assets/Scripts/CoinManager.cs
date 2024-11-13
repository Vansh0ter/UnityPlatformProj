using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI resultsText;
    public float transitionTime;

    void Start()
    {
        resultsText.enabled = false;
        coinText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Star Count: " + coinCount.ToString();
    }
    public void Results() 
    {
        coinText.enabled = false;
        resultsText.enabled = true;
        resultsText.text = "Star Count: " + coinCount.ToString();
        // SaveGame();
        StartCoroutine(Transition());
    }
    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(1);
    }
    /*private void SaveGame()
    {
        SaveData saveData = new SaveData(5);
        saveData.coins[0] = coinCount;
        saveData.levels[1] = 1;

        SaveManager.SaveGameState(saveData);
        Debug.Log("Game Saved");
    }
    private void LoadGame()
    {
        SaveData saveData = SaveManager.LoadGameState();
        if(saveData != null)
        {
            Debug.Log("Game Loaded");
        }
    }*/
}
