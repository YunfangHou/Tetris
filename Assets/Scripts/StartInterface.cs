using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartInterface : MonoBehaviour
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
            gameObject.SetActive(false);
        }
    }

    private void OnClick()
    {
        GameObject.Find("controller").GetComponent<Controller>().gameStart = true;
    }
}