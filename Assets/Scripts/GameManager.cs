using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;

    public Text totalSocreTxt;
    public Text timeTxt;

    int totalScore;

    float totalTime = 30.0f;

    private void Awake()
    {
        Instance = this;
        Time.timeScale= 1.0f;
    }

    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);
        MakeRain();
    }

    void Update()
    {
        LimitTime();
    }

    void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int socer)
    {
        totalScore += socer;
        totalSocreTxt.text = totalScore.ToString();
    }

    private void LimitTime()
    {
        if(totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0f;
            endPanel.SetActive(true);
            Time.timeScale= 0f;
        }

        timeTxt.text = totalTime.ToString("N2");
    }
}
