using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Star Count: " + coinCount.ToString();
    }
}
