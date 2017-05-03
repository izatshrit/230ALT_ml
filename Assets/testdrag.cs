using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class testdrag : MonoBehaviour
{
    Vector3 temp; // current
    Vector3 error; // self explanatory
    Vector3 t0, t1 ,t2,t3; // line 
    bool t;

    void OnMouseDown() // get the options menu when on the header
    {
        t = true; // take new error for drag

        int index = gameObject.GetComponent<classidentifier>().i; // get the accociated options menu

        Vector3 pos;
        for (int i = 0; i < CreateClass.num_of_Classes; i++) // set all of them to 1000,1000 
        {
            pos = CreateClass.opmenu[i].transform.position;
            pos.x = pos.y = 1000;
            CreateClass.opmenu[i].transform.position = pos;
        }

        pos = CreateClass.opmenu[index].transform.position; // get the wanted one to place
        pos.x = -7.632f; pos.y = -3.282f;
        CreateClass.opmenu[index].transform.position = pos;
    }

    void OnMouseDrag()
    {       
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse pos in world unit
        if (t) // true OnMouseDown
        {
            temp = transform.position;
            error.x = Mathf.Abs(mousepos.x - temp.x); 
            error.y = Mathf.Abs(mousepos.y - temp.y); // calculate the error once

            if (mousepos.x > transform.position.x) error.x *= -1; // take care of positions and signs
            if (mousepos.y > transform.position.y) error.y *= -1;
            t = false; // once
        }
        temp.x = mousepos.x + error.x; // set the current position to the mouse + error
        temp.y = mousepos.y + error.y; // same
        transform.position = temp; 
    }
}