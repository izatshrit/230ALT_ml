using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setAssociation : MonoBehaviour {

    public InputField input;
    string self, other;
    bool set = false;
    Vector3 t0, t1;

    public void Set()
    {
        set = false;
        self = gameObject.name.Split(' ')[1];
        other = input.text.Split(':')[1].Split(' ')[1];

        int i;
        for (i = 0; i < CreateClass.num_of_Classes; i++)
            if (other == CreateClass.myclasses[i].name)
                set = true;        
    }
    void Update()
    {
        if (set)
        {
            t0 = GameObject.Find(self).transform.position;
            t1 = GameObject.Find(other).transform.position;
            t0.z = t1.z = 1;
        }
        else
        {
            t0 = t1 = Vector3.zero;
        }
        gameObject.GetComponent<LineRenderer>().SetPosition(0, t0);
        gameObject.GetComponent<LineRenderer>().SetPosition(1, t1);
    }
}
