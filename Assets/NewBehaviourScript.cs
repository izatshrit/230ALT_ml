using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    public InputField input;
    public static bool edited = false;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
      
        if (input.caretPosition < input.text.Length)
        {
            if (input.text[input.caretPosition] == '\n')
            {
                string s = "";
                for (int i = 0; i < input.text.Length; i++)
                {
                    if (i == input.caretPosition && input.text[i - 1] == '\n')
                    {
                        i++;
                        edited = true;
                    }
                    s += input.text[i];
                }
                input.text = s;   
            }
        }

	}
}

