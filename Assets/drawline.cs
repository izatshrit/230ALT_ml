using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.InteropServices;
public class drawline : MonoBehaviour {

    [DllImport("C++ Generator")]
    static extern void generator();

    // this script is attached to options menu's inheritance inputfield

    public GameObject optionsMenu; // t0
    public InputField input; // t1
    Vector3 t0, t1;
    int i = 0;
    void Update()
    {
        
        i = optionsMenu.GetComponent<setName_opMenu>().i; // get the index
        t0 = CreateClass.myclasses[i].transform.position; // get the position 

        if (input.text.Length > 0) // only if there is text inside the inputfield
        {
            int k = 0;
            for (; k < CreateClass.num_of_Classes; k++)
                if (input.text == CreateClass.myclasses[k].name) break;

            if (k >= CreateClass.num_of_Classes) // if not found set it to zero 
                t1 = t0 = Vector3.zero;          
            else
                t1 = CreateClass.myclasses[k].transform.position;

            t0.z = t1.z = 1; // underlay the line
            gameObject.GetComponent<LineRenderer>().SetPosition(0, t0);
            gameObject.GetComponent<LineRenderer>().SetPosition(1, t1);
        }      
    }
    public void setZero()
    {
        if (input.text.Length <= 0)
        {
            t1 = t0 = Vector3.zero;
            gameObject.GetComponent<LineRenderer>().SetPosition(0, t0);
            gameObject.GetComponent<LineRenderer>().SetPosition(1, t1);
            generator();
            testColor.writeCode = true;
        }
    }
}
