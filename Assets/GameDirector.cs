using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    float time = 100.0f;
    GameObject TimeGauge;

    [SerializeField]
    float countTime;

    void Start()
    {
        TimeGauge = GameObject.Find("TimeGauge");
    }

    public void DerceaseHp()
    {
        TimeGauge.GetComponent<Image>().fillAmount -= 0.1f;
        time -= 10.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;
        TimeGauge.GetComponent<Image>().fillAmount -= 1.0f/ countTime * Time.deltaTime;
        Debug.Log(time);

        if(time == 0)
        {
            SceneManager.LoadScene("");
        }
    }
}
