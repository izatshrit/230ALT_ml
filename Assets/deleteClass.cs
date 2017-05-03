using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class deleteClass : MonoBehaviour {

    public bool t = false;
    public Text text;
    public InputField input1;
    public InputField input2;
    public InputField input3;

	public void delete()
    {
        t = true;
        int i = GameObject.Find(text.text).GetComponent<classidentifier>().i;
        int ai = CreateClass.myclasses[i].GetComponent<AF_generator>().ai;
        int fi = CreateClass.myclasses[i].GetComponent<AF_generator>().fi;

        for (int k = 0; k < ai; k++)
        {
            CreateClass.myclasses[i].GetComponent<AF_generator>().attributeOptions[k].GetComponent<AFoptionsHandler>().deleteEverything = true;
            CreateClass.myclasses[i].GetComponent<AF_generator>().attributeOptions[k].GetComponent<AFoptionsHandler>().deleteA();
        }

        for (int k = 0; k < fi; k++)
        {
            CreateClass.myclasses[i].GetComponent<AF_generator>().attributeOptions[k].GetComponent<AFoptionsHandler>().deleteEverything = true;
            CreateClass.myclasses[i].GetComponent<AF_generator>().functionOptions[k].GetComponent<AFoptionsHandler>().deleteF();
        }
        Vector3 pos = new Vector3(1000, 1000, 1000);
        GameObject.Find(text.text).transform.position = pos;
        GameObject.Find(text.text + "Options").transform.position = pos;

        input1.text = "";
        input2.text = "";
        input3.text = "";

        input1.GetComponent<drawline>().setZero();
        input2.GetComponent<drawline>().setZero();
        input3.GetComponent<drawline>().setZero();

    }
}
