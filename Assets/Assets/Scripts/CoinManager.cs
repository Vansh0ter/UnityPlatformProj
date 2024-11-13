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
        StartCoroutine(Transition());
    }
    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(1);
    }
}
