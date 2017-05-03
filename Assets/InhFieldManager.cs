using UnityEngine;
using System.Collections;

public class InhFieldManager : MonoBehaviour {


    public GameObject parent;
    public GameObject[] fields = new GameObject[2];
    int i = 0;
    bool t = true;
   public bool doit = false;
    public void add() // add additional inheritance field 
    {
        if (t)
        {
            Vector3 pos = parent.transform.position;
            pos.y -= (i + 1);
            fields[i].transform.position = pos;
            fields[i].name = (i + 1).ToString();
            i++;
            if (i > 1) t = false; // dont add anything in case of more than 2 additional fields
        }
    }

    public void collapse() //collapse inheritance menu
    {
        parent.transform.localPosition = new Vector3(0, parent.transform.localPosition.y, parent.transform.localPosition.z); 
    }


}
