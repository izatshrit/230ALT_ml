using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class inhPermission : MonoBehaviour {



    string iterator = "+-#";
  
    public void Permission()
    {
        string str = gameObject.GetComponentInChildren<Text>().text; // get the crrent state
        int i = 0;
        for (; i < 3; i++)
            if (str == iterator[i].ToString()) break; // iterate till it's found

        i = (i + 1) % 3; // increment to the next element
        gameObject.GetComponentInChildren<Text>().text = iterator[i].ToString(); // set it to the text of the button
        gameObject.transform.parent.parent.parent.parent.parent.GetComponent<writeInheritance>().mysteryBug();
    }
}

