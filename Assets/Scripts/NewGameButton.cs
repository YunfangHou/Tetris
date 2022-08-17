using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        if (GameObject.Find("controller").GetComponent<Controller>().gameStart)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }


        if (GameObject.Find("controller").GetComponent<Controller>().gameOver)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
    }

    private void OnClick()
    {
        if (GameObject.Find("controller").GetComponent<Controller>().gameOver)
        {
            SceneManager.LoadScene(0);
        }

        GameObject.Find("Start").GetComponent<PlaySound>().shouldPlay = true;
        GameObject.Find("controller").GetComponent<Controller>().gameStart = true;
        GameObject.Find("controller").GetComponent<Controller>().gameOver = false;
    }
}