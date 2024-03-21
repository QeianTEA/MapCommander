using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour, IAction
{
    private bool activated;

    private GameObject Player;
    private GameObject pov;
    private GameObject mapCam;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        mapCam = GameObject.FindGameObjectWithTag("MapCamera");
        pov = GameObject.FindGameObjectWithTag("MainCamera");

        mapCam.SetActive(false);
    }



    void Update()
    {
     if (activated)
        {
            mapCam.SetActive(true);
            pov.SetActive(false);

            float step = 10f * Time.deltaTime;
            //the player "sits"
            if(Vector3.Distance(Player.transform.position, new Vector3(-1.06f, 2.29f, -2.606f)) > 0.11f)
                Player.transform.position = Vector3.MoveTowards(Player.transform.position, new Vector3(- 1.06f, 2.29f, -2.606f), step);
            Player.transform.rotation = new Quaternion(0f, -0.707106829f, 0f, 0.707106829f);
            //camera moves
            if (Vector3.Distance(pov.transform.position, new Vector3(-2.55f, 3.55f, -2.6f)) > 0.11f)
                mapCam.transform.position = Vector3.Lerp(mapCam.transform.position, new Vector3(-2.55f, 3.55f, -2.78f), step);
            else
                step = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.lookingAtMap)
        {
            activated = false;

            CheckInteraction.canInteract = true;

            //camera normal position
            pov.SetActive(true);
            mapCam.SetActive(false);

            gameObject.GetComponent<BoxCollider>().enabled = true;
            FirstPerson_Controller.canMove = true;
        }


    }

    public void Activate()
    {
        activated = true;

        mapCam.transform.position = pov.transform.position;

        GameManager.lookingAtMap = true;
        CheckInteraction.canInteract = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FirstPerson_Controller.canMove = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
