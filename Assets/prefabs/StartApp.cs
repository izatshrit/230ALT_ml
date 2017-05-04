using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartApp : MonoBehaviour {

    public GameObject[] f = new GameObject[8];
    Vector3 pos;
	public void goaway()
    {
        
        pos.x = pos.y =  1000;
        pos.z = 1;
        for( int i = 0; i < 8; i++)
        {
            Debug.Log("S");
            f[i].transform.position = pos;
        }
        gameObject.transform.position = pos;
    }
}
