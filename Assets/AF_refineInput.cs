using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AF_refineInput : MonoBehaviour {

    public InputField input;
    
	public void refine()
    {
        string text = input.text;
        
        // split function will return length of 1 when the parametere not detected inside the text
        if (text.Split(':').Length == 1) //auto should be set
        {
            GameObject.Find("tips").GetComponent<writeTips>().fade = true;
            GameObject.Find("tips").GetComponent<writeTips>().tips.text = " You might have forgotten to designate the type, so we have get it done for you";
            if (text.Split(' ').Length == 1) // only one word, no : no spaces, piece of cake
            {
                if (gameObject.name[1] == 'a')
                    text += ": auto";
                else
                {
                    text = text.Split('(')[0];
                    int i;
                    for (i = 0; i < CreateClass.num_of_Classes; i++)
                        if (text == CreateClass.myclasses[i].name) break;
                    if (i >= CreateClass.num_of_Classes)
                        
                        text += "():void";
                    else
                        text += "():constructor";
                }

                
            }
            //done
            else // spaces detected, illegal
            {
                GameObject.Find("tips").GetComponent<writeTips>().fade = true;
                GameObject.Find("tips").GetComponent<writeTips>().tips.text = " No spaces is allowed. We have put an underscore instead";

                string str = "";
                for(int k=0;k<text.Split(' ').Length; k++) // remove the spaces and place _ instead
                { 
                    if (text.Split(' ')[k] != "") // in case of x   c (3 spaces) it will be like [x,"","","",c]
                    {
                        str += text.Split(' ')[k];
                        if (k < text.Split(' ').Length - 1) str += "_"; // in case of "x c" it will be x_c
                        
                    }
                }                           
                if (str[str.Length - 1] == '_')
                {
                    string st = "";
                    for (int k = 0; k < str.Length - 1; k++)
                        st += str[k];
                    text = st + ": auto";
                }else
                 text = str + ": auto";
                
            }
            input.text = text;
        }



        else // : has been taken from inputfield
        {
            if (input.text.Split('(').Length == 1)
            {
                string str2, str3;
                str2 = text.Split(':')[1];
                str3 = str2.Split(' ')[str2.Split(' ').Length - 1]; // whitespace after the type will result in a bug

                string str1 = text.Split(':')[0]; // the same as the above, only str1 instead of text.

                string str = "";
                for (int k = 0; k < str1.Split(' ').Length; k++) // remove the spaces and place _ instead
                {
                    if (str1.Split(' ')[k] != "") // in case of x   c (3 spaces) it will be like [x,"","","",c]
                    {
                        str += str1.Split(' ')[k];
                        if (k < str1.Split(' ').Length - 1) str += "_"; // in case of "x c" it will be x_c

                    }
                }
                //  Debug.Log(str);
                if (str[str.Length - 1] == '_')
                {
                   GameObject.Find("tips").GetComponent<writeTips>().fade = true;
                    GameObject.Find("tips").GetComponent<writeTips>().tips.text = " No spaces is allowed. We have put an underscore instead";
                    string st = "";
                    for (int k = 0; k < str.Length - 1; k++)
                        st += str[k];
                    text = st + ": " + str3;
                }
                else
                    text = str + ": " + str3;

                input.text = text;
            }
            else // in case funciton with parameters and whitespaces
            {
                string h = ""; 
                for(int i = 0; i < input.text.Length; i++)
                {
                    if (input.text[i] != ' ') h += input.text[i];
                }
                if (h[h.Length - 1] == ')') {
                    int i;
                    for (i = 0; i < CreateClass.num_of_Classes; i++)
                        if (text == CreateClass.myclasses[i].name) break;
                    if (i >= CreateClass.num_of_Classes)
                        h += ":void";
                    else
                        h += ":constructor";
                    
                    GameObject.Find("tips").GetComponent<writeTips>().fade = true;
                    GameObject.Find("tips").GetComponent<writeTips>().tips.text = " ! You might have forgotten to designate the type, so we have get it done for you";

                }
                input.text = h;
                
            }
        }
    }
}