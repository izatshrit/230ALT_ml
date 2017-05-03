using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
public class testColor : MonoBehaviour
{

    public Text text;
    static public bool writeCode = false;
    FileStream fs;
    StreamReader sr;
    string code;
    string[] lines;

    string[] blue = new string[17];
    string cyan = "string";

    // Use this for initialization
    void Start()
    {


        blue[0] = "int";
        blue[1] = "float";
        blue[2] = "double";
        blue[3] = "char";
        blue[4] = "bool";
        blue[10] = "auto";
        blue[11] = "long";
        blue[12] = "short";
        blue[13] = "void";
        blue[14] = "class";
        blue[15] = "virtual";
        blue[16] = "friend";
        blue[5] = "const";
        blue[6] = "static";

        blue[7] = "public:";
        blue[8] = "protected:";
        blue[9] = "private:";
    }

    void Update()
    {
        
        if (writeCode)
        {
            text.text = "";
            fs = new FileStream("code.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            code = sr.ReadToEnd();
            
            
            lines = new string[code.Split('\n').Length];
            lines = code.Split('\n');

            for (int k = 0; k < lines.Length; k++)
            {
                string str = "";
                string[] words = new string[lines[k].Split(' ').Length];
                words = lines[k].Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];
                    // Debug.Log("line " + k + "word i " + i + " " + word + " " + word.Length + " f ");

                    int l = 0;
                    for (; l < blue.Length; l++)
                        if (word == blue[l]) break;

                    if (l < blue.Length)
                    {
                        str = "<color=#3d8dd6>" + word + "</color>";
                        if (word == "class")
                        {
                            i++;
                            word = words[i];
                            str += " " + "<color=#4ec9b0>" + word + "</color>";
                        }
                    }
                    else if (word == "string")
                    {
                        
                        str = "<color=#4ec9b0>" + word + "</color>";
                    }
                    else if (word.Contains("\'") || word.Contains("\""))
                    {                   
                        str = "<color=#d6966a>" + word + "</color>";
                    }
                    else
                        str = "<color=#c8c8c8>" + word + "</color>";
                    
                    text.text += str + " ";
                }
                text.text += '\n';
            }
            
          
            writeCode = false;
            sr.Close();
            fs.Close();
        }
    }

}

