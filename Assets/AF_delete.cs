using UnityEngine;
using System.Collections;

public class AF_delete : MonoBehaviour {

    // this script does the animation on the input fields when delete button is pressed
    public static string deletedName;
    public static int identity;
    public static bool shift = false;

    public void destroy()// this function is automatically activated when button is pressed
    {
        if (gameObject.transform.position.z == AFGetOptions.z) { 
            
            deletedName = gameObject.name.Split(' ')[0];
            identity = GameObject.Find(gameObject.name.Split(' ')[1]).GetComponent<classidentifier>().i;
            shift = true;
        }
    }
}
