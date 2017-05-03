using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inputfieldOption : MonoBehaviour {
    
    public GameObject panel;
    public GameObject inputfield;

	public void getPanel()
    {
        Vector3 pos = inputfield.transform.position;
        pos.x += 2.25f;
        pos.y -= 0.4f;
        panel.transform.position = pos;
    }
}