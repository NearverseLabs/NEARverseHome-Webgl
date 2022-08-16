using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //Vector3 clickPos = hit.point;
        //bool clicked = false;
        //Ray ray = Camera.main.ScreenPointToRay(clickPos);
        //if (Physics.Raycast(ray, out hit) && clicked)
        //{
        //    Debug.Log("Clicked on gameobject: " + hit.collider.name);
        //}
    }
    void OnMouseDown()
    {
        Debug.Log("Clicked on gameobject: ");
    }
}
