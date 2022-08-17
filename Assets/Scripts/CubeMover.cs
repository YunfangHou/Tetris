using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private int holdFrame;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Cube1 = GameObject.Find("Cube_1");
        GameObject Cube2 = GameObject.Find("Cube_2");
        GameObject Cube3 = GameObject.Find("Cube_3");
        GameObject Cube4 = GameObject.Find("Cube_4");


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            holdFrame++;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.DownArrow))
        {
            holdFrame = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow)
            && holdFrame > 25
            && Cube1.GetComponent<CubeScript>().frame % 5 == 3
            && !Cube1.GetComponent<CubeScript>().shouldStop
            && !Cube2.GetComponent<CubeScript>().shouldStop
            && !Cube3.GetComponent<CubeScript>().shouldStop
            && !Cube4.GetComponent<CubeScript>().shouldStop
            && Cube1.transform.position.x > 0.5f
            && Cube2.transform.position.x > 0.5f
            && Cube3.transform.position.x > 0.5f
            && Cube4.transform.position.x > 0.5f
            && !GameObject.Find("Cube_" + (Cube1.transform.position.x - 0.5f) + "_" +
                                (Cube1.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube2.transform.position.x - 0.5f) + "_" +
                                (Cube2.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube3.transform.position.x - 0.5f) + "_" +
                                (Cube3.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube4.transform.position.x - 0.5f) + "_" +
                                (Cube4.transform.position.y + 0.5f)))
        {
            GameObject.Find("Move").GetComponent<PlaySound>().shouldPlay = true;
            Cube1.transform.position = new Vector3(Cube1.transform.position.x - 1, Cube1.transform.position.y,
                Cube1.transform.position.z);
            Cube2.transform.position = new Vector3(Cube2.transform.position.x - 1, Cube2.transform.position.y,
                Cube2.transform.position.z);
            Cube3.transform.position = new Vector3(Cube3.transform.position.x - 1, Cube3.transform.position.y,
                Cube3.transform.position.z);
            Cube4.transform.position = new Vector3(Cube4.transform.position.x - 1, Cube4.transform.position.y,
                Cube4.transform.position.z);
        }

        if (Input.GetKey(KeyCode.RightArrow)
            && holdFrame > 25
            && Cube1.GetComponent<CubeScript>().frame % 5 == 3
            && !Cube1.GetComponent<CubeScript>().shouldStop
            && !Cube2.GetComponent<CubeScript>().shouldStop
            && !Cube3.GetComponent<CubeScript>().shouldStop
            && !Cube4.GetComponent<CubeScript>().shouldStop
            && Cube1.transform.position.x < 9.5f
            && Cube2.transform.position.x < 9.5f
            && Cube3.transform.position.x < 9.5f
            && Cube4.transform.position.x < 9.5f
            && !GameObject.Find("Cube_" + (Cube1.transform.position.x + 1.5f) + "_" +
                                (Cube1.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube2.transform.position.x + 1.5f) + "_" +
                                (Cube2.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube3.transform.position.x + 1.5f) + "_" +
                                (Cube3.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube4.transform.position.x + 1.5f) + "_" +
                                (Cube4.transform.position.y + 0.5f)))
        {
            GameObject.Find("Move").GetComponent<PlaySound>().shouldPlay = true;
            Cube1.transform.position = new Vector3(Cube1.transform.position.x + 1, Cube1.transform.position.y,
                Cube1.transform.position.z);
            Cube2.transform.position = new Vector3(Cube2.transform.position.x + 1, Cube2.transform.position.y,
                Cube2.transform.position.z);
            Cube3.transform.position = new Vector3(Cube3.transform.position.x + 1, Cube3.transform.position.y,
                Cube3.transform.position.z);
            Cube4.transform.position = new Vector3(Cube4.transform.position.x + 1, Cube4.transform.position.y,
                Cube4.transform.position.z);
        }


        if (Input.GetKey(KeyCode.DownArrow)
            && holdFrame > 25
            && Cube1.GetComponent<CubeScript>().frame % 5 == 3
            && !Cube1.GetComponent<CubeScript>().shouldStop
            && !Cube2.GetComponent<CubeScript>().shouldStop
            && !Cube3.GetComponent<CubeScript>().shouldStop
            && !Cube4.GetComponent<CubeScript>().shouldStop
            && Cube1.transform.position.y > 0.5f
            && Cube2.transform.position.y > 0.5f
            && Cube3.transform.position.y > 0.5f
            && Cube4.transform.position.y > 0.5f
            && !GameObject.Find("Cube_" + Cube1.transform.position.x + "_" + (Cube1.transform.position.y - 1))
            && !GameObject.Find("Cube_" + Cube2.transform.position.x + "_" + (Cube2.transform.position.y - 1))
            && !GameObject.Find("Cube_" + Cube3.transform.position.x + "_" + (Cube3.transform.position.y - 1))
            && !GameObject.Find("Cube_" + Cube4.transform.position.x + "_" + (Cube4.transform.position.y - 1))
            && !GameObject.Find("Cube_" + (Cube1.transform.position.x + 0.5f) + "_" +
                                (Cube1.transform.position.y - 0.5f))
            && !GameObject.Find("Cube_" + (Cube2.transform.position.x + 0.5f) + "_" +
                                (Cube2.transform.position.y - 0.5f))
            && !GameObject.Find("Cube_" + (Cube3.transform.position.x + 0.5f) + "_" +
                                (Cube3.transform.position.y - 0.5f))
            && !GameObject.Find("Cube_" + (Cube4.transform.position.x + 0.5f) + "_" +
                                (Cube4.transform.position.y - 0.5f)))
        {
            Cube1.transform.position = new Vector3(Cube1.transform.position.x, Cube1.transform.position.y - 1,
                Cube1.transform.position.z);
            Cube2.transform.position = new Vector3(Cube2.transform.position.x, Cube2.transform.position.y - 1,
                Cube2.transform.position.z);
            Cube3.transform.position = new Vector3(Cube3.transform.position.x, Cube3.transform.position.y - 1,
                Cube3.transform.position.z);
            Cube4.transform.position = new Vector3(Cube4.transform.position.x, Cube4.transform.position.y - 1,
                Cube4.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)
            && !Cube1.GetComponent<CubeScript>().shouldStop
            && !Cube2.GetComponent<CubeScript>().shouldStop
            && !Cube3.GetComponent<CubeScript>().shouldStop
            && !Cube4.GetComponent<CubeScript>().shouldStop
            && Cube1.transform.position.x > 0.5f
            && Cube2.transform.position.x > 0.5f
            && Cube3.transform.position.x > 0.5f
            && Cube4.transform.position.x > 0.5f
            && !GameObject.Find("Cube_" + (Cube1.transform.position.x - 0.5f) + "_" +
                                (Cube1.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube2.transform.position.x - 0.5f) + "_" +
                                (Cube2.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube3.transform.position.x - 0.5f) + "_" +
                                (Cube3.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube4.transform.position.x - 0.5f) + "_" +
                                (Cube4.transform.position.y + 0.5f)))
        {
            GameObject.Find("Move").GetComponent<PlaySound>().shouldPlay = true;
            Cube1.transform.position = new Vector3(Cube1.transform.position.x - 1, Cube1.transform.position.y,
                Cube1.transform.position.z);
            Cube2.transform.position = new Vector3(Cube2.transform.position.x - 1, Cube2.transform.position.y,
                Cube2.transform.position.z);
            Cube3.transform.position = new Vector3(Cube3.transform.position.x - 1, Cube3.transform.position.y,
                Cube3.transform.position.z);
            Cube4.transform.position = new Vector3(Cube4.transform.position.x - 1, Cube4.transform.position.y,
                Cube4.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)
            && !Cube1.GetComponent<CubeScript>().shouldStop
            && !Cube2.GetComponent<CubeScript>().shouldStop
            && !Cube3.GetComponent<CubeScript>().shouldStop
            && !Cube4.GetComponent<CubeScript>().shouldStop
            && Cube1.transform.position.x < 9.5f
            && Cube2.transform.position.x < 9.5f
            && Cube3.transform.position.x < 9.5f
            && Cube4.transform.position.x < 9.5f
            && !GameObject.Find("Cube_" + (Cube1.transform.position.x + 1.5f) + "_" +
                                (Cube1.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube2.transform.position.x + 1.5f) + "_" +
                                (Cube2.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube3.transform.position.x + 1.5f) + "_" +
                                (Cube3.transform.position.y + 0.5f))
            && !GameObject.Find("Cube_" + (Cube4.transform.position.x + 1.5f) + "_" +
                                (Cube4.transform.position.y + 0.5f)))
        {
            GameObject.Find("Move").GetComponent<PlaySound>().shouldPlay = true;
            Cube1.transform.position = new Vector3(Cube1.transform.position.x + 1, Cube1.transform.position.y,
                Cube1.transform.position.z);
            Cube2.transform.position = new Vector3(Cube2.transform.position.x + 1, Cube2.transform.position.y,
                Cube2.transform.position.z);
            Cube3.transform.position = new Vector3(Cube3.transform.position.x + 1, Cube3.transform.position.y,
                Cube3.transform.position.z);
            Cube4.transform.position = new Vector3(Cube4.transform.position.x + 1, Cube4.transform.position.y,
                Cube4.transform.position.z);
        }


        if (Input.GetKeyDown(KeyCode.DownArrow)
            && !Cube1.GetComponent<CubeScript>().shouldStop
            && !Cube2.GetComponent<CubeScript>().shouldStop
            && !Cube3.GetComponent<CubeScript>().shouldStop
            && !Cube4.GetComponent<CubeScript>().shouldStop
            && Cube1.transform.position.y > 0.5f
            && Cube2.transform.position.y > 0.5f
            && Cube3.transform.position.y > 0.5f
            && Cube4.transform.position.y > 0.5f
            && !GameObject.Find("Cube_" + Cube1.transform.position.x + "_" + (Cube1.transform.position.y - 1))
            && !GameObject.Find("Cube_" + Cube2.transform.position.x + "_" + (Cube2.transform.position.y - 1))
            && !GameObject.Find("Cube_" + Cube3.transform.position.x + "_" + (Cube3.transform.position.y - 1))
            && !GameObject.Find("Cube_" + Cube4.transform.position.x + "_" + (Cube4.transform.position.y - 1))
            && !GameObject.Find("Cube_" + (Cube1.transform.position.x + 0.5f) + "_" +
                                (Cube1.transform.position.y - 0.5f))
            && !GameObject.Find("Cube_" + (Cube2.transform.position.x + 0.5f) + "_" +
                                (Cube2.transform.position.y - 0.5f))
            && !GameObject.Find("Cube_" + (Cube3.transform.position.x + 0.5f) + "_" +
                                (Cube3.transform.position.y - 0.5f))
            && !GameObject.Find("Cube_" + (Cube4.transform.position.x + 0.5f) + "_" +
                                (Cube4.transform.position.y - 0.5f)))
        {
            Cube1.transform.position = new Vector3(Cube1.transform.position.x, Cube1.transform.position.y - 1,
                Cube1.transform.position.z);
            Cube2.transform.position = new Vector3(Cube2.transform.position.x, Cube2.transform.position.y - 1,
                Cube2.transform.position.z);
            Cube3.transform.position = new Vector3(Cube3.transform.position.x, Cube3.transform.position.y - 1,
                Cube3.transform.position.z);
            Cube4.transform.position = new Vector3(Cube4.transform.position.x, Cube4.transform.position.y - 1,
                Cube4.transform.position.z);
        }
    }
}