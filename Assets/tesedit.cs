using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class tesedit : MonoBehaviour {

    public InputField inputField; // to get the text 
    public InputField defaultValue_InputField;
    int identifier;
    string className;
    string inputFieldName;
    string prevText = "";
    int defaultValue;





    // on end edit
    public void doit() // Auto calling on end edit of input field, detected when clicked out of it or enter is pressed
    {
        if (inputField.text != prevText) // for not sending the text if value not changed when entering and leaving it
        {
            identifier = gameObject.transform.parent.parent.GetComponentInParent<classidentifier>().i; //the indentifier 3 layers up
            className = gameObject.transform.parent.parent.parent.name; // class name 3 layers up
            inputFieldName = gameObject.transform.parent.parent.name; // input field name 2 layers up

            Debug.Log(identifier + " " + className + " " + inputFieldName + " " + inputField.text );    //debug
            prevText = inputField.text;


        }
    }

    public void doit2()
    {
        defaultValue = int.Parse(defaultValue_InputField.text);
        Debug.Log(identifier + " " + className + " " + inputFieldName + " " + inputField.text + " " + defaultValue);

    }
}





