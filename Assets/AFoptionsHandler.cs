using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AFoptionsHandler : MonoBehaviour {


    // public Button permissionButton; // private - public - protected
    bool m_isStaticA = false;
    bool m_isStaticF = false;

    bool m_isConstA = false;
    bool m_isConstF = false;

    public bool deleteEverything = false;
    //only for Attributes
    string m_defaultValueA;


    //only for funcitons
    bool isVirt = false;
    bool isFr = false;

    public InputField defaultValueInputField;
    string iterator = "+-#";

    

    // const button 
    public void isConstA() // Auto call when button pressed
    {
        if (gameObject.transform.position.z == AFGetOptions.z)
        {
            Debug.Log(gameObject.name);
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());
            string str = GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AFGetOptions>().input.text;

            if (m_isConstA == false)
            {
                str += " ReadOnly";
                m_isConstA = true;
            }
            else
            {          // name          +                  ReadOnly
                str = str.Split(':')[0] + ": " + str.Split(':')[1].Split(' ')[1];
                m_isConstA = false;
            }

            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AFGetOptions>().input.text = str;

            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AF_messageFormer>().isConst = m_isConstA;
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AF_messageFormer>().EndEdit();
        }

    }
    public void isConstF() // Auto call when button pressed
    {
        if (gameObject.transform.position.z == AFGetOptions.z) // dont let the underlaying toggles toggle.. (raycast issue but solved without using raycast)
        {
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());
            string str = GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AFGetOptions>().input.text;

            if (m_isConstF == false)
            {
                str += " ReadOnly";
                m_isConstF = true;
            }
            else
            {

                if (!str.Contains("("))
                {
                    str = str.Split(':')[0] + ": " + str.Split(':')[1].Split(' ')[1];
                }
                else
                    str = str.Split(' ')[0];
                m_isConstF = false;
            }
            //write the string 
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AFGetOptions>().input.text = str;
            // send the message
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().isConst = m_isConstF;

            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().EndEdit();
        }
    }

    public void isStaticA()
    {
        if (gameObject.transform.position.z == AFGetOptions.z)
        {
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());
            //change the text in here later   string str = GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AFGetOptions>().input.text;
            m_isStaticA = !m_isStaticA; // toggle the previous situaiton
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AF_messageFormer>().isStatic = m_isStaticA;

            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AF_messageFormer>().EndEdit();
        }

    }
    public void isStaticF()
    {
        if (gameObject.transform.position.z == AFGetOptions.z)
        {
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());
            //change the text in here later   string str = GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AFGetOptions>().input.text;
            m_isStaticF = !m_isStaticF; // toggle the previous situaiton
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().isStatic = m_isStaticF;

            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().EndEdit();
        }
    }

    public void defaultValue() // on end edit
    {

        if (gameObject.transform.position.z == AFGetOptions.z)
        {
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());
            m_defaultValueA = defaultValueInputField.text;
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AF_messageFormer>().defaultValue = m_defaultValueA;
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AF_messageFormer>().EndEdit();
        }
    }

    public void deleteA()
    {
        if (gameObject.transform.position.z == AFGetOptions.z || deleteEverything )
        {
            
        
            Debug.Log("deleteA");
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());

            
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].transform.position = new Vector3(1000, 1000, 0);
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AF_messageFormer>().defaultValue = "Alt230ML";
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldAttribute[i].GetComponent<AF_messageFormer>().EndEdit();
        }
    }

    public void deleteF()
    {
        if (gameObject.transform.position.z == AFGetOptions.z || deleteEverything)
        {
          
            Debug.Log("deleteF");
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());

            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].transform.position = new Vector3(1000, 1000, 0);
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().defaultValue = "Alt230ML";
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().EndEdit();
        }
    }

    

    public void isVirtal()
    {
        if (gameObject.transform.position.z == AFGetOptions.z)
        {
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());
            //change the text in here later   string str = GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AFGetOptions>().input.text;
            isVirt = !isVirt; // toggle the previous situaiton
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().isVirtual = isVirt;
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().EndEdit();
        }
    }

    public void isFriend()
    {
        if (gameObject.transform.position.z == AFGetOptions.z)
        {
            string className = gameObject.name.Split(' ')[1];
            int i = int.Parse(gameObject.name[0].ToString());
            //change the text in here later   string str = GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AFGetOptions>().input.text;
            isFr = !isFr; // toggle the previous situaiton
            
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().isFriend = isFr;
            GameObject.Find(className).GetComponent<AF_generator>().inputFieldFunction[i].GetComponent<AF_messageFormer>().EndEdit();
        }
    }

    //public void permission()
    //{     
    //    string str = permissionButton.GetComponentInChildren<Text>().text; // get the crrent state
    //    int i = 0;
    //    for(; i < 3; i++)
    //        if (str == iterator[i].ToString()) break; // iterate till it's found

    //    i = (i + 1) % 3; // increment to the next element
    //    permissionButton.GetComponentInChildren<Text>().text = iterator[i].ToString(); // set it to the text of the button
    //}

    //public void defaultValue()// on end edit
    //{

    //}
}
