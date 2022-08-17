using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuitGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
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
       Application.Quit();
    }
}
