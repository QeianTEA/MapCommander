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
            //camera normal position
            pov.transform.position = Vector3.MoveTowards(pov.transform.position, new Vector3(0, 0.62f, 0f), 0.01f);
            pov.transform.rotation = Quaternion.RotateTowards(new Quaternion(pov.transform.rotation.x, pov.transform.rotation.y, pov.transform.rotation.z, pov.transform.rotation.w), new Quaternion(43f, 0f, 0f, pov.transform.rotation.w), 1f);

            lookingAtMap = false;
        }
    }
}
