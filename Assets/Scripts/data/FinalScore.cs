using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("controller").GetComponent<Controller>().gameOver)
        {
            GetComponent<Text>().text = GameObject.Find("detector").GetComponent<DetectorScript>().score.ToString();
        }
        
        if (!GameObject.Find("controller").GetComponent<Controller>().gameOver)
        {
            GetComponent<Text>().text = "";
        }
        
    }
}
