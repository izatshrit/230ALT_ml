using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class optionsHandler : MonoBehaviour {

    public InputField input; // to get the text from it and another scripts
    public Button permissionButton; // private - public - protected
    
    string iterator = "+-#";
    // const button 
	public void isConst() // Auto call when button pressed
    {
        input.text += " ReadOnly"; // set it to read only -> const
        input.GetComponent<tesedit>().doit(); // call onEndEdit to send the modified text
    }

    public void permission()
    {     
        string str = permissionButton.GetComponentInChildren<Text>().text; // get the crrent state
        int i = 0;
        for(; i < 3; i++)
            if (str == iterator[i].ToString()) break; // iterate till it's found
        
        i = (i + 1) % 3; // increment to the next element
        permissionButton.GetComponentInChildren<Text>().text = iterator[i].ToString(); // set it to the text of the button
    }

    public void defaultValue()// on end edit
    {
        input.GetComponent<tesedit>().doit2();
    }
}
