using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private GameObject player;
    private GameObject connectedGameObject1;
    private GameObject connectedGameObject2;
    private GameObject connectedGameObject3;
    private GameObject connectedGameObject4;

    private GameObject controller;

    private Rigidbody rd;

    public bool shouldStop = false;
    public bool roundEnd = false;
    public bool shouldFall;

    private float positionX, positionY, positionZ;

    public float frame;
    public float speed = 4f;

    private int delayFrame;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();

        player = gameObject;

        connectedGameObject1 = GameObject.Find("Cube_1");
        connectedGameObject2 = GameObject.Find("Cube_2");
        connectedGameObject3 = GameObject.Find("Cube_3");
        connectedGameObject4 = GameObject.Find("Cube_4");
    }

    // Update is called once per frame
    void Update()
    {
        positionX = rd.transform.position.x;
        positionY = rd.transform.position.y;
        positionZ = rd.transform.position.z;

        float fps = GameObject.Find("controller").GetComponent<Controller>().fps;
        shouldFall = frame % (int) (fps / speed) == 0;


        if (!shouldStop && shouldFall
                        && (gameObject.name == "Cube_1" || gameObject.name == "Cube_2" || gameObject.name == "Cube_3" ||
                            gameObject.name == "Cube_4"))
        {
            rd.transform.position = new Vector3(positionX, positionY - 1, positionZ);
        }

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)
            && rd.transform.position.y - hit.collider.transform.position.y <= 1
            && hit.collider.name != "Cube_1"
            && hit.collider.name != "Cube_2"
            && hit.collider.name != "Cube_3"
            && hit.collider.name != "Cube_4")
        {
            shouldStop = true;
        }

        shouldStop = connectedGameObject1.GetComponent<CubeScript>().shouldStop
                     || connectedGameObject2.GetComponent<CubeScript>().shouldStop
                     || connectedGameObject3.GetComponent<CubeScript>().shouldStop
                     || connectedGameObject4.GetComponent<CubeScript>().shouldStop;


        if (shouldStop && (gameObject.name == "Cube_1" || gameObject.name == "Cube_2" || gameObject.name == "Cube_3" ||
                           gameObject.name == "Cube_4"))
        {
            rd.transform.name = "Cube_"
                                + (rd.transform.position.x + 0.5f)
                                + "_"
                                + (rd.transform.position.y + 0.5f);
            player.tag = "stoppedCube";
            roundEnd = true;
            GameObject.Find("Stop").GetComponent<PlaySound>().shouldPlay = true;
        }


        frame++;
    }
}