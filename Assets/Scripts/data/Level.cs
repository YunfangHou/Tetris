using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = GameObject.Find("detector").GetComponent<DetectorScript>().level.ToString();
        if (GameObject.Find("controller").GetComponent<Controller>().gameOver)
        {
            GetComponent<Text>().text = "";
        }
    }
}