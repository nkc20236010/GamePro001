using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoerController : MonoBehaviour
{
    float score;

    void Start()
    {
        GetComponent<Text>().text = score.ToString("F2") + "Km";
        //Km = GameObject.Find("Km");
    }

    void Update()
    {
        
    }
}
