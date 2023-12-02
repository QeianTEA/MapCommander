using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour , IAction
{
    private bool activated;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Activate()
    {
        activated = !activated;

        if (activated)
        {
            if (!PlayerScript.handsFull)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<InteractionReceiver>().enabled = false;
                PlayerScript.handsFull = true;

                transform.parent = Player.transform;   //Player becomes items parent
                transform.localPosition = new Vector3(0.23f, 0.1f, 0.7f);
                transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            }
        }
        else
        {

        }
    }
}
