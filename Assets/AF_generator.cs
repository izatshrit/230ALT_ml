using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AF_generator : MonoBehaviour {

    public GameObject[] inputFieldAttribute = new GameObject[8]; // attribute arrayt up to 8 elements at most
    public GameObject[] inputFieldFunction  = new GameObject[8];
    public GameObject ClassLayout;
    public GameObject ClassName;
    public GameObject inputfieldBar;

    public GameObject[] attributeOptions = new GameObject[8];
    public GameObject[] functionOptions = new GameObject[8];

    public GameObject attOp;
    public GameObject funcOp;

    public string focusedField;

    float y = 0.45f; // fixed rate don't change it
    int v = 0;
    public int ai = 0;
    public int fi = 0;
    int countA = 0, countF = 0;

    bool pushFunctions = false;
    bool shift = false;

    Quaternion useless = new Quaternion(0, 0, 0, 0);

    public void generateAttribute() //Auto calling when button clicked
    {
        if (v++ != 0) y = 0.45f; // fixed rate don't change it - design bullshit.
        inputFieldAttribute[ai] = (GameObject)Instantiate(inputfieldBar, // instantiate the field
            new Vector3(ClassName.transform.position.x, // x
            ClassName.transform.position.y - (y * (ai + 1- countA)), // y
            ClassName.transform.position.z), // z
            useless); //bullshit

        inputFieldAttribute[ai].transform.SetParent(ClassLayout.transform); // set parent
        inputFieldAttribute[ai].name = ai.ToString() + "a "+gameObject.name; // set name

        attributeOptions[ai] = (GameObject)Instantiate(attOp, new Vector3(1000, 1000, 0),useless);
        attributeOptions[ai].name = ai + "a " + gameObject.name +" Options";
        ai++; // Attribute iterator
        pushFunctions = true;
    }
    public void generateFunction() //Auto calling when button clicked
    {
        if (v++ != 0) y = 0.45f; // fixed rate don't change it - design bullshit.
        inputFieldFunction[fi] = (GameObject)Instantiate(inputfieldBar, // instantiate the field
            new Vector3(ClassName.transform.position.x, // x
            ClassName.transform.position.y - (y * (fi + ai + 1 - countA - countF)), // y
            ClassName.transform.position.z), // z
            new Quaternion(0, 0, 0, 0)); //bullshit, again.

        inputFieldFunction[fi].transform.SetParent(ClassLayout.transform); //set parent
        inputFieldFunction[fi].name = fi.ToString() + "f "+gameObject.name; //set name

        functionOptions[fi] = (GameObject)Instantiate(funcOp, new Vector3(1000, 1000, 0), useless);
        functionOptions[fi].name = fi + "f " +gameObject.name+ " Options";
        fi++;
    }   

    void Update()
    {
        if (pushFunctions) //pushing funcitons down when attribute is instantiated in case functions found
        {    
            for (int i = 0 ; i < fi; i++)
            {    
                Vector3 pos = inputFieldFunction[i].transform.position;
                pos.y -= y;
                inputFieldFunction[i].transform.position = pos;
            }
            pushFunctions = false;
        }

        if (AF_delete.shift)
        {  
            if (AF_delete.identity == gameObject.GetComponent<classidentifier>().i)
            {
                int index = int.Parse(AF_delete.deletedName[0].ToString());
                char type = AF_delete.deletedName[1];
                Debug.Log("INDEXX" + index);
                ///////////////////////////////////////////////////////////////
                //DELETE 
                if (type == 'a') // delete attribute
                {
                    Vector3 pos = inputFieldAttribute[index].transform.position;
                    pos.x = pos.y = 1000;
                    inputFieldAttribute[index].transform.position = pos;
                    countA++;
                }
                else if (type == 'f')
                {
                    Vector3 pos = inputFieldFunction[index].transform.position;
                    pos.x = pos.y = 1000;
                    inputFieldFunction[index].transform.position = pos;
                    countF++;
                }
                ///////////////////////////////////////////////////////////////
                //SHIFT
                int i = index + 1;
                if (type == 'a') // shifting attributes and funcitons
                {                    
                    for (; i < ai; i++)
                    {
                        Vector3 pos = inputFieldAttribute[i].transform.position;
                        pos.y += y;
                        inputFieldAttribute[i].transform.position = pos;
                    }
                    i = 0; // make functions start shifting from 0 because reasons
                }

                for (; i < fi ; i++) // shifting funcitons;
                {
                    Vector3 pos = inputFieldFunction[i].transform.position;
                    pos.y += y;
                    inputFieldFunction[i].transform.position = pos;
                }
                AF_delete.shift = false;
            }
        }      
    }

}