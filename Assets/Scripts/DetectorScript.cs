using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DetectorScript : MonoBehaviour
{
    private Rigidbody rd;
    public int justDestroyedRow = 21;
    public bool justDestroyOneRow;
    public int score;

    public int amountOfDestroyedRows;


    public int lines;

    public int level;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        amountOfDestroyedRows = 0;
    }

    // Update is called once per frame
    void Update()
    {
        level = lines / 10;
        for (int index = 1; index < 5; index++)
        {
            if (GameObject.Find("Cube_" + index))
            {
                GameObject.Find("Cube_" + index).GetComponent<CubeScript>().speed = Math.Max(2f, (float) level);
            }
        }

        for (int i = 1; i < 20; i++)
        {
            if (!GameObject.Find("Cube_1")
                && !GameObject.Find("Cube_2")
                && !GameObject.Find("Cube_3")
                && !GameObject.Find("Cube_4"))
            {
                checkOneRow(i);
                GameObject.Find("controller").GetComponent<Controller>().canCreateNewBlock = true;
            }
        }


        for (int y = justDestroyedRow + 1; y < 21; y++)
        {
            for (int x = 1; x < 11; x++)
            {
                if (GameObject.Find("Cube_" + x + "_" + y) && justDestroyOneRow)
                {
                    GameObject go1 = GameObject.Find("Cube_" + x + "_" + y);
                    go1.transform.position = new Vector3(x - 0.5f, y - amountOfDestroyedRows - 0.5f, 0.5f);
                    go1.name = "Cube_" + x + "_" + (y - amountOfDestroyedRows);
                }
            }
        }

        score += 1000 * (int) Math.Pow(2, amountOfDestroyedRows - 1);
        amountOfDestroyedRows = 0;
        justDestroyOneRow = false;
    }

    // destroy all the cubes in one row if the row is full of cubes
    void checkOneRow(int y)
    {
        GameObject[] goArr = new GameObject[10];
        for (int x = 1; x < 11; x++)
        {
            string goName = "Cube_" + x + "_" + y;
            goArr[x - 1] = GameObject.Find(goName);
        }

        bool shouldDestroy = true;

        for (int i = 0; i < 10; i++)
        {
            shouldDestroy = shouldDestroy && (bool)goArr[i];
        }

        if (shouldDestroy)
        {
            for (int x = 0; x < 10; x++)
            {
                Destroy(goArr[x]);
            }

            justDestroyedRow = y;
            justDestroyOneRow = true;
            amountOfDestroyedRows++;
            lines++;
            
            if (amountOfDestroyedRows<4)
            {
                GameObject.Find("123Row").GetComponent<PlaySound>().shouldPlay = true;
            }
            else
            {
                GameObject.Find("4Row").GetComponent<PlaySound>().shouldPlay = true;
            }
        }
    }
}