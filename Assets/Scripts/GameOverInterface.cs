using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GameOverInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("controller").GetComponent<Controller>().gameOver)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
        
        if (!GameObject.Find("controller").GetComponent<Controller>().gameOver)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
