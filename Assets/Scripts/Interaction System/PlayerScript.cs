using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [HideInInspector]
    public static bool handsFull;

    [HideInInspector]
    public GameObject carriedItem;


    void Start()
    {
        handsFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.paused && !GameManager.gameOver)
        {
            if (handsFull && Input.GetKeyDown(KeyCode.G))
            {
                carriedItem.transform.localPosition = new Vector3(0f, 0.3f, 1.5f);

                carriedItem.transform.SetParent(null);
                carriedItem.GetComponent<Rigidbody>().useGravity = true;
                carriedItem.GetComponent<BoxCollider>().enabled = true;
                carriedItem.GetComponent<InteractionReceiver>().enabled = true;
                handsFull = false;
            }
        }
        
    }
}
