using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Camera MapCam;
    private Vector3 mOffset;
    float mZCoord;

    private void Awake()
    {
        MapCam = GameObject.FindGameObjectWithTag("MapCamera").GetComponent<Camera>();
    }

    private void OnMouseDown()
    {
        mZCoord = MapCam.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        //cordiantes (x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordiante of game object on screen
        mousePoint.z = mZCoord;

        return MapCam.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset + new Vector3(0f, 0.5f, 0f);
    }
}
