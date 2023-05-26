using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    int hit = 0;
    float score;
    float time = 100.0f;
    GameObject TimeGauge;
    GameObject Km;

    [SerializeField]
    float countTime;

    void Start()
    {
        Km = GameObject.Find("Km");
        TimeGauge = GameObject.Find("TimeGauge");
    }

    public void DerceaseHp()
    {
        TimeGauge.GetComponent<Image>().fillAmount -= 0.1f;
        time -= 10.0f;
    }

    void Update()
    {
        score += Time.deltaTime;
        Km.GetComponent<Text>().text = score.ToString("F2") + "Km";


        time -= Time.deltaTime;
        TimeGauge.GetComponent<Image>().fillAmount -= 1.0f/ countTime * Time.deltaTime;
        //Debug.Log(time);

        //if(time <= 0)
        //{
        //    SceneManager.LoadScene("TitleScene");
        //}

        if (hit >= 5)
        {
            Debug.Log("hit");
            SceneManager.LoadScene("GameOverScene");
        }

    }
    public void HitCounter()
    {
        hit++;
    }
   
    
}
