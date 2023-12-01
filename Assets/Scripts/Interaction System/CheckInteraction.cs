using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : MonoBehaviour
{

    [SerializeField]
    private float minInteractionDistance;
   
    [SerializeField]
    private GameObject rayOrigin;


    private Ray ray;

    private bool canInteract;

    private InteractionReceiver currentReceiver;

    private UI ui;

    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    void Update()
    {
        CheckRaycast();
        if (canInteract)
        {
            /*
             *In this region the character is seeing an object with which he can interact
             *In my case I'll do the E-key reading right here
            */


            if (Input.GetKeyDown(KeyCode.E))
            {
                currentReceiver.Activate();
            }
            
        }

    }

    private void CheckRaycast()
    {
        ray = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           

            if (hit.distance < minInteractionDistance)
            {


                currentReceiver = hit.transform.gameObject.GetComponent<InteractionReceiver>();

                if (currentReceiver != null)
                {
                    //Here you can make something with the interact message

                    ui.showMessage(currentReceiver.GetInteractionMessage());
 
                    canInteract = true;
                   
                }
                else
                {
                    canInteract = false;
                }
            }
        }

      
    }

}
