using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;
public class writeInheritance : MonoBehaviour {

    public InputField Input1;
    public InputField Input2;
    public InputField Input3;

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
    int order = 0;

    [DllImport("C++ Generator")]
    static extern void generator();

    public bool setAgain = false;

    public void EndEdit1()
    {

        self = gameObject.GetComponent<setName_opMenu>().namelabel.text; // class name
        other = Input1.text;
       // Debug.Log("1 " + other);
            if (virtualCheck1.isOn)
                virt1 = " virtual";
            insertCode = ": " + virt1 + " " + other;
            insert();
        
    }
    public void EndEdit2()
    {
        self = gameObject.GetComponent<setName_opMenu>().namelabel.text; // class name
        other = Input2.text;
        //  Debug.Log("2 " + other);
        if (virtualCheck2.isOn)
            virt2 = " virtual";
        insertCode = ", " + virt2 + " " + other;
        insert();

    }
    public void EndEdit3()
    {
        self = gameObject.GetComponent<setName_opMenu>().namelabel.text; // class name
        other = Input3.text;
        //  Debug.Log("3 " + other);
        if (virtualCheck3.isOn)
            virt3 = " virtual";
        insertCode = ", " + virt3 + " " + other;
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
                 //   Debug.Log("fat");
                      lines[i] += insertCode;
                //    Debug.Log("insert code" + insertCode);
                 //   Debug.Log(lines[i]);
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
        }       
    }
    
    public void mysteryBug()
    {
     
        EndEdit1();
        EndEdit2();
        EndEdit3();
    }
}