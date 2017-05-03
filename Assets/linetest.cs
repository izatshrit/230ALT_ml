using UnityEngine;
using System.Collections;

public class linetest : MonoBehaviour {

    Vector3[] pos= new Vector3[2];

	// Use this for initialization
	void Start () {
        GetComponent<LineRenderer>().SetPosition(0,new Vector3(0, 0, 0));
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(2, 2, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
