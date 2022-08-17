using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine.EventSystems;
using Random = System.Random;

public class Controller : MonoBehaviour
{
    private int indexOfCube = 1;

    private float createHeight = 18.5f;
    private float createX = 4.5f;

    public char blockType;
    public int nextBlock;
    public int firstBlock;
    public int blockState;

    public int fps = 50;
    private Color blockColor = Color.blue;
    private int color = 1;

    public bool canCreateNewBlock;
    public bool gameStart;
    public bool gameOver;
    
    private int gameOverSoundPlayTimes;
    

    private void Start()
    {
        Random random = new Random();
        firstBlock = random.Next(1, 8);
    }

    void Update()
    {
        Application.targetFrameRate = fps;
        

        if (GameObject.Find("Cube_5_18"))
        {
            gameOver = true;
            if (gameOverSoundPlayTimes == 0)
            {
                GameObject.Find("GameOver").GetComponent<PlaySound>().shouldPlay = true;
                gameOverSoundPlayTimes++;
            }
        }

        

        if (!GameObject.Find("Cube_1")
            && !GameObject.Find("Cube_2")
            && !GameObject.Find("Cube_3")
            && !GameObject.Find("Cube_4")
            && canCreateNewBlock
            && gameStart
            && !gameOver)
        {
            canCreateNewBlock = false;
            Random random = new Random();
            nextBlock = random.Next(1, 8);
            switch (firstBlock)
            {
                case 1:
                    createI();
                    blockType = 'I';
                    blockState = 1;
                    GameObject.Find("IStatistics").GetComponent<IStatistics>().amount++;
                    break;
                case 2:
                    createJ();
                    blockType = 'J';
                    blockState = 1;
                    GameObject.Find("JStatistics").GetComponent<JStatistics>().amount++;
                    break;
                case 3:
                    createL();
                    blockType = 'L';
                    blockState = 1;
                    GameObject.Find("LStatistics").GetComponent<LStatistics>().amount++;
                    break;
                case 4:
                    createS();
                    blockType = 'S';
                    blockState = 1;
                    GameObject.Find("SStatistics").GetComponent<SStatistics>().amount++;
                    break;
                case 5:
                    createZ();
                    blockType = 'Z';
                    blockState = 1;
                    GameObject.Find("ZStatistics").GetComponent<ZStatistics>().amount++;
                    break;
                case 6:
                    createT();
                    blockType = 'T';
                    blockState = 1;
                    GameObject.Find("TStatistics").GetComponent<TStatistics>().amount++;
                    break;
                case 7:
                    createO();
                    blockType = 'O';
                    blockState = 1;
                    GameObject.Find("OStatistics").GetComponent<OStatistics>().amount++;
                    break;
            }

            firstBlock = nextBlock;

            color++;
            if (color == 7)
            {
                color = 1;
            }

            switch (color)
            {
                case 1:
                    blockColor = Color.blue;
                    break;
                case 2:
                    blockColor = Color.green;
                    break;
                case 3:
                    blockColor = Color.red;
                    break;
                case 4:
                    blockColor = Color.cyan;
                    break;
                case 5:
                    blockColor = Color.magenta;
                    break;
                case 6:
                    blockColor = Color.yellow;
                    break;
            }

            Destroy(GameObject.Find("Cube_5"));
            Destroy(GameObject.Find("Cube_6"));
            Destroy(GameObject.Find("Cube_7"));
            Destroy(GameObject.Find("Cube_8"));

            createHeight = 8.5f;
            createX = 13.5f;
            
            switch (nextBlock)
            {
                case 1:
                    createI();
                    blockState = 1;
                    break;
                case 2:
                    createJ();
                    blockState = 1;
                    break;
                case 3:
                    createL();
                    blockState = 1;
                    break;
                case 4:
                    createS();
                    blockState = 1;
                    break;
                case 5:
                    createZ();
                    blockState = 1;
                    break;
                case 6:
                    createT();
                    blockState = 1;
                    break;
                case 7:
                    createO();
                    blockState = 1;
                    break;
            }

            createHeight = 18.5f;
            createX = 4.5f;
        }

        // for test
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     createI();
        //     blockType = 'I';
        //     blockState = 1;
        // }
        //
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     createL();
        //     blockType = 'L';
        //     blockState = 1;
        // }
        //
        // if (Input.GetKeyDown(KeyCode.J))
        // {
        //     createJ();
        //     blockType = 'J';
        //     blockState = 1;
        // }
        //
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     createS();
        //     blockType = 'S';
        //     blockState = 1;
        // }
        //
        // if (Input.GetKeyDown(KeyCode.Z))
        // {
        //     createZ();
        //     blockType = 'Z';
        //     blockState = 1;
        // }
        //
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     createT();
        //     blockType = 'T';
        //     blockState = 1;
        // }
        //
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     createO();
        //     blockType = 'O';
        //     blockState = 1;
        // }

        float frame = GameObject.Find("Cube_1").GetComponent<CubeScript>().frame;
        float speed = GameObject.Find("Cube_1").GetComponent<CubeScript>().speed;
        bool testBool = frame % 50 != 0;
        if (Input.GetKeyUp(KeyCode.A)
            && (blockType == 'T' || blockType == 'L' || blockType == 'J') && testBool)
        {
            GameObject.Find("Rotate").GetComponent<PlaySound>().shouldPlay = true;
            if (blockType == 'T')
            {
                if (blockState == 1)
                {
                    TToState2();
                }

                if (blockState == 2)
                {
                    TToState3();
                }

                if (blockState == 3)
                {
                    TToState4();
                }

                if (blockState == 4)
                {
                    TToState1();
                }
            }

            if (blockType == 'L')
            {
                if (blockState == 1)
                {
                    LToState2();
                }

                if (blockState == 2)
                {
                    LToState3();
                }

                if (blockState == 3)
                {
                    LToState4();
                }

                if (blockState == 4)
                {
                    LToState1();
                }
            }

            if (blockType == 'J')
            {
                if (blockState == 1)
                {
                    JToState2();
                }

                if (blockState == 2)
                {
                    JToState3();
                }

                if (blockState == 3)
                {
                    JToState4();
                }

                if (blockState == 4)
                {
                    JToState1();
                }
            }

            blockState++;
            if (blockState == 5)
            {
                blockState = 1;
            }
        }

        if (Input.GetKeyUp(KeyCode.A)
            && (blockType == 'S' || blockType == 'Z' || blockType == 'I') && testBool)
        {
            GameObject.Find("Rotate").GetComponent<PlaySound>().shouldPlay = true;
            if (blockType == 'S')
            {
                if (blockState == 1)
                {
                    SToState2();
                }

                if (blockState == 2)
                {
                    SToState1();
                }
            }

            if (blockType == 'Z')
            {
                if (blockState == 1)
                {
                    ZToState2();
                }

                if (blockState == 2)
                {
                    ZToState1();
                }
            }

            if (blockType == 'I')
            {
                if (blockState == 1)
                {
                    IToState2();
                }

                if (blockState == 2)
                {
                    IToState1();
                }
            }

            blockState++;
            if (blockState == 3)
            {
                blockState = 1;
            }
        }

        if (Input.GetKeyUp(KeyCode.D)
            && (blockType == 'T' || blockType == 'L' || blockType == 'J') && testBool)
        {
            GameObject.Find("Rotate").GetComponent<PlaySound>().shouldPlay = true;
            if (blockType == 'T')
            {
                if (blockState == 1)
                {
                    TToState4();
                }

                if (blockState == 2)
                {
                    TToState1();
                }

                if (blockState == 3)
                {
                    TToState2();
                }

                if (blockState == 4)
                {
                    TToState3();
                }
            }

            if (blockType == 'L')
            {
                if (blockState == 1)
                {
                    LToState4();
                }

                if (blockState == 2)
                {
                    LToState1();
                }

                if (blockState == 3)
                {
                    LToState2();
                }

                if (blockState == 4)
                {
                    LToState3();
                }
            }

            if (blockType == 'J')
            {
                if (blockState == 1)
                {
                    JToState4();
                }

                if (blockState == 2)
                {
                    JToState1();
                }

                if (blockState == 3)
                {
                    JToState2();
                }

                if (blockState == 4)
                {
                    JToState3();
                }
            }

            blockState--;
            if (blockState == 0)
            {
                blockState = 4;
            }
        }

        if (Input.GetKeyUp(KeyCode.D)
            && (blockType == 'S' || blockType == 'Z' || blockType == 'I') && testBool)
        {
            GameObject.Find("Rotate").GetComponent<PlaySound>().shouldPlay = true;
            if (blockType == 'S')
            {
                if (blockState == 1)
                {
                    SToState2();
                }

                if (blockState == 2)
                {
                    SToState1();
                }
            }

            if (blockType == 'Z')
            {
                if (blockState == 1)
                {
                    ZToState2();
                }

                if (blockState == 2)
                {
                    ZToState1();
                }
            }

            if (blockType == 'I')
            {
                if (blockState == 1)
                {
                    IToState2();
                }

                if (blockState == 2)
                {
                    IToState1();
                }
            }

            blockState--;
            if (blockState == 0)
            {
                blockState = 2;
            }
        }

        indexOfCube = 1;
    }

    void createCube(float x, float y)
    {
        GameObject m_cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // set name of cube by index
        m_cube.name = "Cube_" + indexOfCube;
        indexOfCube++;
        m_cube.AddComponent<CubeScript>();
        m_cube.AddComponent<Rigidbody>();
        m_cube.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        m_cube.GetComponent<Rigidbody>().useGravity = false;
        m_cube.GetComponent<Rigidbody>().isKinematic = true;
        m_cube.GetComponent<Renderer>().material.color = blockColor;
        m_cube.transform.position = new Vector3(x, y, 0.5f);
    }

    void createI()
    {
        createCube(createX, createHeight);
        createCube(createX + 1, createHeight);
        createCube(createX + 2, createHeight);
        createCube(createX + 3, createHeight);
    }

    void createL()
    {
        createCube(createX, createHeight);
        createCube(createX - 1, createHeight);
        createCube(createX + 1, createHeight);
        createCube(createX - 1, createHeight - 1);
    }

    void createJ()
    {
        createCube(createX, createHeight);
        createCube(createX - 1, createHeight);
        createCube(createX + 1, createHeight);
        createCube(createX + 1, createHeight - 1);
    }

    void createS()
    {
        createCube(createX, createHeight);
        createCube(createX + 1, createHeight + 1);
        createCube(createX, createHeight + 1);
        createCube(createX - 1, createHeight);
    }

    void createZ()
    {
        createCube(createX, createHeight);
        createCube(createX - 1, createHeight + 1);
        createCube(createX, createHeight + 1);
        createCube(createX + 1, createHeight);
    }

    void createT()
    {
        createCube(createX, createHeight);
        createCube(createX - 1, createHeight);
        createCube(createX + 1, createHeight);
        createCube(createX, createHeight - 1);
    }

    void createO()
    {
        createCube(createX, createHeight);
        createCube(createX + 1, createHeight);
        createCube(createX, createHeight - 1);
        createCube(createX + 1, createHeight - 1);
    }

    void TToState1()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
    }

    void TToState2()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
    }

    void TToState3()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
    }

    void TToState4()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
    }


    void LToState1()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x - 1, cube1P.y - 1, cube1P.z);
    }

    void LToState2()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x - 1, cube1P.y + 1, cube1P.z);
    }

    void LToState3()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x + 1, cube1P.y + 1, cube1P.z);
    }

    void LToState4()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x + 1, cube1P.y - 1, cube1P.z);
    }

    void JToState1()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x + 1, cube1P.y - 1, cube1P.z);
    }

    void JToState2()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x - 1, cube1P.y - 1, cube1P.z);
    }

    void JToState3()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x - 1, cube1P.y + 1, cube1P.z);
    }

    void JToState4()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x + 1, cube1P.y + 1, cube1P.z);
    }


    void SToState1()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x + 1, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
    }

    void SToState2()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x + 1, cube1P.y - 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
    }

    void ZToState1()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x - 1, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
    }

    void ZToState2()
    {
        Vector3 cube1P = GameObject.Find("Cube_1").transform.position;
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x + 1, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_3").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
    }


    void IToState1()
    {
        Vector3 cube1P = GameObject.Find("Cube_3").transform.position;
        GameObject.Find("Cube_1").transform.position = new Vector3(cube1P.x - 2, cube1P.y, cube1P.z);
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x - 1, cube1P.y, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x + 1, cube1P.y, cube1P.z);
    }

    void IToState2()
    {
        Vector3 cube1P = GameObject.Find("Cube_3").transform.position;
        GameObject.Find("Cube_1").transform.position = new Vector3(cube1P.x, cube1P.y + 2, cube1P.z);
        GameObject.Find("Cube_2").transform.position = new Vector3(cube1P.x, cube1P.y + 1, cube1P.z);
        GameObject.Find("Cube_4").transform.position = new Vector3(cube1P.x, cube1P.y - 1, cube1P.z);
    }
}