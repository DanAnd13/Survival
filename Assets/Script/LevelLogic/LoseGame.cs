using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public TextMeshProUGUI killCountUI;
    public TextMeshProUGUI lifeTimeUI;
    public GameObject loseUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoseValues()
    {
        killCountUI.text = Stopwatch.kills.ToString();
        lifeTimeUI.text = Stopwatch.stopwatchValue;
        CrossHair.StandartCursor();
        loseUI.SetActive(true);
    }
}
