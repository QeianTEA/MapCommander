using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static bool paused;
    [HideInInspector]
    public static bool gameOver;
    [HideInInspector]
    public static bool lookingAtMap;

    private GameObject Player;
    private GameObject pov;
    public GameObject mapCam;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        pov = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        InputChecker();
    }

    void InputChecker()
    {
        if (lookingAtMap && Input.GetKeyDown(KeyCode.R))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            lookingAtMap = false;
        }
    }
}
