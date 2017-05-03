using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class classidentifier : MonoBehaviour {
    public int i;

    public InputField className;

    void Update()
    {
        gameObject.name = className.text;
        CreateClass.opmenu[i].GetComponent<setName_opMenu>().namelabel.text = gameObject.name; // setting the options menu text to the name of the calss
        CreateClass.opmenu[i].GetComponent<setName_opMenu>().name = gameObject.name + "Options"; // setting the options menu name in the editor to the name of the class
        // ^^ get access to option menu and change it's name when class name is changed
    }
}