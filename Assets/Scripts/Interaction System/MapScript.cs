using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour, IAction
{
    private bool activated;

    private GameObject Player;
    private GameObject pov;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        pov = GameObject.FindGameObjectWithTag("MainCamera");
    }


    void Update()
    {
     if (activated)
        {
            //the player "sits"
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, new Vector3(-1.06f, 2.29f, -2.606f), 0.001f);
            //camera moves
            pov.transform.position = Vector3.MoveTowards(pov.transform.position, new Vector3(0, 0.62f, 0.954f), 0.01f);
            pov.transform.rotation = Quaternion.RotateTowards(new Quaternion(pov.transform.rotation.x, pov.transform.rotation.y, pov.transform.rotation.z, pov.transform.rotation.w), new Quaternion(64.816f, 0f, 0f, pov.transform.rotation.w), 0.01f);
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.lookingAtMap)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            activated = false;
            FirstPerson_Controller.canMove = true;
        }


    }

    public void Activate()
    {
        activated = true;

        GameManager.lookingAtMap = true;
        FirstPerson_Controller.canMove = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;


    }
}
