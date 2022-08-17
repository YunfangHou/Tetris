using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OStatistics : MonoBehaviour
{
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("controller").GetComponent<Controller>().gameStart)
        {
            GetComponent<Text>().enabled = false;
        }

        if (GameObject.Find("controller").GetComponent<Controller>().gameStart)
        {
            GetComponent<Text>().enabled = true;
        }
        GetComponent<Text>().text = amount.ToString();
        if (GameObject.Find("controller").GetComponent<Controller>().gameOver)
        {
            GetComponent<Text>().enabled = false;
        }
    }
}