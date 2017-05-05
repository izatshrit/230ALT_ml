﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;
public class writeInheritance : MonoBehaviour {

    public InputField Input1;
    public InputField Input2;
    public InputField Input3;

    public Button button1;
    public Button button2;
    public Button button3;

    public Toggle virtualCheck1;
    public Toggle virtualCheck2;
    public Toggle virtualCheck3;
    
    FileStream fs;
    StreamReader sr;
    StreamWriter sw;

    string self = "";
    public string other = "";

    public string virt1 = "";
    public string virt2 = "";
    public string virt3 = "";

    public string insertCode = "";
    public string prevInsertCode = "";
    int order = 0;

    [DllImport("C++ Generator")]
    static extern void generator();

    public bool setAgain = false;

    public void EndEdit1()
    {

        self = gameObject.GetComponent<setName_opMenu>().namelabel.text; // class name
        other = Input1.text;
        // Debug.Log("1 " + other);
        string s = button1.GetComponentInChildren<Text>().text;
        string permission;
        if (s == "+") permission = "public";
        else if (s == "-") permission = "private";
        else permission = "protected";

            if (virtualCheck1.isOn)
                virt1 = " virtual";
            insertCode = ": " + permission+" "+ virt1 + " " + other;
            insert();
        
    }
    public void EndEdit2()
    {
        self = gameObject.GetComponent<setName_opMenu>().namelabel.text; // class name
        other = Input2.text;

        string s = button2.GetComponentInChildren<Text>().text;
        string permission;
        if (s == "+") permission = "public";
        else if (s == "-") permission = "private";
        else permission = "protected";

        if (virtualCheck2.isOn)
            virt2 = " virtual";
        
        insertCode = prevInsertCode+  ", " + permission + " "+virt2 + " " + other;
        insert();

    }
    public void EndEdit3()
    {
        self = gameObject.GetComponent<setName_opMenu>().namelabel.text; // class name
        other = Input3.text;

        string s = button2.GetComponentInChildren<Text>().text;
        string permission;
        if (s == "+") permission = "public";
        else if (s == "-") permission = "private";
        else permission = "protected";

        if (virtualCheck3.isOn)
            virt3 = " virtual";

        insertCode = ", " + permission + " " + virt3 + " " + other;
        insert();

    }


    public void insert()
    {
       
    
        if(GameObject.Find(other) == null)
        {     
           
          //  Debug.Log("illegal class name");
        }
        else
        { 
            fs = new FileStream("code.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            string txt = sr.ReadToEnd();
            sr.Close();
            string[] lines = new string[txt.Split('\n').Length];
            lines = txt.Split('\n');

            string toCompare = "class " + self;
            
            for ( int i = 0; i < lines.Length; i++)
            {          
                if (lines[i].Contains(toCompare))
                {
                    
                      lines[i] = toCompare+ insertCode;
                
                }           
            }
            fs.Close();
            fs = new FileStream("code.txt", FileMode.Open, FileAccess.ReadWrite);
            sw =new StreamWriter(fs);

            for (int i = 0; i < lines.Length; i++)
            {
                sw.WriteLine(lines[i]);
            //    Debug.Log(lines[i]);
            }

            
            sw.Close();
            fs.Close();
            fs = new FileStream("code.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            Debug.Log("this is class " + self);
            Debug.Log(sr.ReadToEnd());
            sr.Close();
            fs.Close();
            testColor.writeCode = true;
            prevInsertCode = insertCode;
        }       
    }
    
    public void mysteryBug()
    {
     
        EndEdit1();
        EndEdit2();
        EndEdit3();
    }
}