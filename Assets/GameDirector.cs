using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public int KillCount;
    int hit = 0;
    public float score;

    
    GameObject TimeGauge;
    GameObject Km;
    GameObject EnemyCountor;

    [SerializeField]  float countTime;
    [SerializeField]  float time;

    void Start()
    {
        EnemyCountor = GameObject.Find("EnemyCountor");
        Km = GameObject.Find("Km");
        TimeGauge = GameObject.Find("TimeGauge");
    }

    public void DerceaseHp()
    {
        TimeGauge.GetComponent<Image>().fillAmount -= 0.1f;
        time -= 1.0f / countTime;
    }

    void Update()
    {
        EnemyCountor.GetComponent<Text>().text =KillCount.ToString("000") + "Kill";

        score += Time.deltaTime;
        Km.GetComponent<Text>().text = score.ToString("F2") + "Km";


        time -= 1.0f / countTime * Time.deltaTime;
        TimeGauge.GetComponent<Image>().fillAmount -= 1.0f/ countTime * Time.deltaTime;
        //Debug.Log(time);

        if (time < 0)
        {
            ScoerController.Kill = KillCount;
            ScoerController.resultscore = score;
            SceneManager.LoadScene("ClearScene");
        }

        if (hit >= 2)
        {
            ScoerController.Kill = KillCount;
            ScoerController.resultscore = score;
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public void HitCounter()
    {
       hit++;
    }
   public void KillCounter()
    {
       KillCount++;
    }
    
}
