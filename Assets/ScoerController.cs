using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoerController : MonoBehaviour
{
    public static float resultscore;

    void Start()
    {

        GetComponent<Text>().text = resultscore.ToString("F2") + "Km";
        //Km = GameObject.Find("Km");
    }

    void Update()
    {
        
    }
}
