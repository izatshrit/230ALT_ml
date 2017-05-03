using UnityEngine;
using System.Collections;

public class inheritancemenuanimation : MonoBehaviour {

    public GameObject button;
    Vector3 pos;
    float speed = 0.1f;
    public  bool doit = false;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<shiftInhMenu>().t)
        {
            pos = gameObject.transform.localPosition; // get initial value
            doit = true; // set translation motion to true
            if (pos.x >= 2.2) // stop on thise condition
            {
                speed = 0.1f;
                button.GetComponent<shiftInhMenu>().t = false;
                doit = false;
            }
            if (doit) // start animating
            {
                pos = gameObject.transform.localPosition;
                pos.x += speed;
                speed += 0.02f;
                gameObject.transform.localPosition = pos;
            }
        }
    }
}