using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AFGetOptions : MonoBehaviour {

    //attached to input bar
    Vector3 pos;
    public InputField input;
    static public float z = 0;

    void OnMouseDown() // get the wanted option menu
    {
        int i = int.Parse(gameObject.name[0].ToString());
        char type = gameObject.name[1]; // f a 
        z -= 0.01f;
        pos.z = z;
        pos.x = 2.586f; pos.y = -4.048f;

        if (type == 'a')
            gameObject.transform.parent.GetComponent<AF_generator>().attributeOptions[i].transform.position = pos;

        else // function
            gameObject.transform.parent.GetComponent<AF_generator>().functionOptions[i].transform.position = pos;
        
    }

    public void valueChanged() // set the text in the input field to the text on it's option menu
    {
        int i = int.Parse(gameObject.name[0].ToString());
        char type = gameObject.name[1];
        string str;

        if (input.text.Split(':').Length == 1) // no type defined
        {
            if (input.text.Contains("("))
            {
                str = input.text.Split('(')[0];
            }
            else if (input.text.Split(' ').Length == 1) // only one word is inside the text
                str = input.text;
            
            else
                str = input.text.Split(' ')[0]; // in case of readonly
        }
        else // type has been defined name: int
        {
            str = input.text.Split(':')[0];
        }

        if (type == 'f')
            gameObject.transform.parent.GetComponent<AF_generator>().functionOptions[i].GetComponent<AFOP_UpdateName>().text.text = str;
        
        else
            gameObject.transform.parent.GetComponent<AF_generator>().attributeOptions[i].GetComponent<AFOP_UpdateName>().text.text = str;
    }
}