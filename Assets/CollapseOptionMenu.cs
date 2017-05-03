using UnityEngine;
using System.Collections;

public class CollapseOptionMenu : MonoBehaviour {

    public GameObject panel;
	public void collapse()
    {
        Vector3 pos = panel.transform.position;
        pos.x = pos.y = 1000;
        panel.transform.position = pos;
    }
}
