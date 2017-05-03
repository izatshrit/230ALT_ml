using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class writeTips : MonoBehaviour {

    public Text tips;
    public bool fade = false;
    float time = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (fade)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                fade = false;
                time = 5;
                tips.text = "";
            }
        }

    }
}
