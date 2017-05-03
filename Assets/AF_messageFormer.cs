using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.InteropServices;
public class AF_messageFormer : MonoBehaviour {

    FileStream fs;
    StreamWriter sw;
    StreamReader sr;
    public int classIdentifier;
    public string className;
    public string permission= "+";
    public string nameOfInputField;
    public int numOfEdits=0; // to get the final edit
    public string textInputField;
    public string type;

    public bool isConst = false;
    public bool isStatic = false;
    public string defaultValue;


    public bool isVirtual = false;
    public bool isFriend = false;

    public Button permissionButton;
    public InputField input;
    string iterator = "+-#";

    string text;
    string[] lines;

  
    [DllImport("Final Sorter")]
    static extern void filter();
    [DllImport("C++ Generator")]
    static extern void generator();

    public void EndEdit()
    {
        if(!isConst)
            gameObject.GetComponent<AF_refineInput>().refine(); // in case of const the refine will put ReadOnly instead of the type becuase of my stupid refining methods.
    
       


        classIdentifier = gameObject.transform.parent.GetComponent<classidentifier>().i; // class identifier
        className = gameObject.name.Split(' ')[1]; // class name
        nameOfInputField = gameObject.name.Split(' ')[0]; // name of inputfield 0a,1a,3f...
        textInputField = input.text.Split(':')[0] ; // text inside inputfield
        type = input.text.Split(':')[input.text.Split(':').Length - 1];


        if (type.Contains("ReadOnly"))
        {
            if(nameOfInputField[1]=='f')
            type = type.Split(' ')[0];
            else // attriute
                type = type.Split(' ')[1];
        }
     


        else if (type[0] == ' ')
        {
            Debug.Log("S");
            string b = "";
            for (int i = 1; i < type.Length; i++) b += type[i];
            type = b;
        }
       // Debug.Log("after " + type);
        numOfEdits++;

        if (nameOfInputField[1] == 'f')
        {
        
            Debug.Log(input.text.Split('(')[1]);
            if (input.text.Split('(')[1][0] != ')')
            {
                string str = "";
                string st = "";
                string n;
                n = input.text.Split(')')[0];  // name of function foo()
                string temp = n.Split('(')[1];
                string c = n.Split('(')[0];

                for (int k = 0; k < temp.Split(',').Length; k++)
                {
                    string t = temp.Split(',')[k];
                    string f = "";
                    //    Debug.Log(t);
                    if (k != 0)
                        f += ",;";

                    f += t.Split(':')[1] + ";" + t.Split(':')[0];
                    st += f;
                }

                string final = c + "(;" + st + ")";
                Debug.Log("THIS IS FINAL " + final);
                textInputField = final;
            }
        }

        string  message = classIdentifier + " " + className + " " + permission + " " + nameOfInputField + " " + numOfEdits
               + " " + textInputField + " " + type + " " + isConst + " " + isStatic + " " + defaultValue +" "+isVirtual +" "+isFriend;

        Debug.Log("this is in message "+ message);

        fs = new FileStream("text.txt", FileMode.Append); // write into text
        sw = new StreamWriter(fs);
        sw.WriteLine(message);
        sw.Close();
        fs.Close();
        

        fs = new FileStream("text.txt", FileMode.Open, FileAccess.Read);// read from the same text after writing
        sr = new StreamReader(fs);

        text = sr.ReadToEnd(); // read all of the text at once
        sr.Close();
        fs.Close();

        lines = new string[text.Split('\n').Length]; // get the lines
        lines = text.Split('\n');


        for (int i = 0; i < lines.Length - 1 - 1; i++) //sort 
        {
            for (int k = 0; k < lines.Length - i - 1 - 1; k++)
            {
                if (String.Compare(lines[k].Split(' ')[0] + lines[k].Split(' ')[3][1]+lines[k].Split(' ')[3][0] + lines[k].Split(' ')[4],
                                    lines[k + 1].Split(' ')[0] + lines[k+1].Split(' ')[3][1] + lines[k+1].Split(' ')[3][0] + lines[k + 1].Split(' ')[4]) > 0)
                {
                   
                    string temp = lines[k];
                    lines[k] = lines[k + 1];
                    lines[k + 1] = temp;
                }
            }
        }
        File.Delete(@"textSorted.txt");
        File.Delete(@"finalSorted.txt");

        FileStream fs1 = new FileStream("textSorted.txt", FileMode.Create, FileAccess.Write); // write the sorted lines into text
         StreamWriter sw1 = new StreamWriter(fs1);
        foreach (string line in lines) //actual writing
            sw1.WriteLine(line);
        sw1.Close();
        fs1.Close();

        filter(); // final sort stage - dll 
        generator(); // generate the code - dll
        int z = CreateClass.num_of_Classes;
        for(int i = 0; i <z; i++)
        {
            CreateClass.opmenu[i].GetComponent<writeInheritance>().mysteryBug();
        }
        testColor.writeCode = true; //at this line the code is generated, 
        //activate writeCode to write it into the text with colors
    }


    public void Permission()
    {
        string str = permissionButton.GetComponentInChildren<Text>().text; // get the crrent state
        int i = 0;
        for (; i < 3; i++)
            if (str == iterator[i].ToString()) break; // iterate till it's found

        i = (i + 1) % 3; // increment to the next element
        permissionButton.GetComponentInChildren<Text>().text = iterator[i].ToString(); // set it to the text of the button
        permission = iterator[i].ToString();
        EndEdit();
    }
}