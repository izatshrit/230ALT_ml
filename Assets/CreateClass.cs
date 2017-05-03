using UnityEngine;
using System.Collections;

public class CreateClass : MonoBehaviour {

    public GameObject classLayout;  // prefab
    static public GameObject[] myclasses = new GameObject[10];

    public GameObject optionsMenu; // prefab
    static public GameObject[] opmenu = new  GameObject[10]; // arbitrary 10 stores the menus
    static public int num_of_Classes = 0; // how many menus do I have

    Quaternion useless = new Quaternion(0, 0, 0, 0); // but important

    public static int i = 0; // identifier
    public static float z = 0; // setting layers

	public void create()
    {
        //create class layout
        classLayout.tag = i.ToString();
        myclasses[i] = (GameObject) Instantiate(classLayout, new Vector3(0, 0, z), useless);
        myclasses[i].GetComponent<classidentifier>().i=i;
        myclasses[i].name = "class" + i;

        // create options menu
        opmenu[i] = (GameObject)Instantiate(optionsMenu, new Vector3(1000, 1000, z), useless);
        opmenu[i].GetComponent<setName_opMenu>().namelabel.text = myclasses[i].name; // set text label on optoins menu
        opmenu[i].GetComponent<setName_opMenu>().i = i; // set identifier
        opmenu[i].name = myclasses[i].name + "Options"; // set name
        num_of_Classes++; 
        i++;
        z -= 0.1f; // to make classes overlay each other
    }
}