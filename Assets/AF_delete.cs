using UnityEngine;
using System.Collections;

public class AF_delete : MonoBehaviour {


    public static string deletedName;
    public static int identity;
    public static bool shift = false;

    public void destroy()
    {
        if (gameObject.transform.position.z == AFGetOptions.z) { 
            
            deletedName = gameObject.name.Split(' ')[0];
            identity = GameObject.Find(gameObject.name.Split(' ')[1]).GetComponent<classidentifier>().i;
            shift = true;
        }
       
    }
}
