using UnityEngine;
using System.Collections;

public class testRotate : MonoBehaviour {

    public GameObject target;

    public GameObject instantiatedline;
    GameObject line;
	// Use this for initialization
	void Start () {

       
        Vector3 current = transform.position;
        Vector3 targetPos = target.transform.position;
        Vector3 midPoint;

        if (Mathf.Abs(current.x) > Mathf.Abs(targetPos.x))

            if (Mathf.Abs(current.y) > Mathf.Abs(targetPos.y))
                midPoint = new Vector3((current.x - targetPos.x) / 2, (current.y - targetPos.y) / 2, 0);
            else
                midPoint = new Vector3((current.x - targetPos.x) / 2, (targetPos.y - current.y) / 2, 0);
        else

            if (Mathf.Abs(current.y) > Mathf.Abs(targetPos.y))
                midPoint = new Vector3((targetPos.x - current.x) / 2, (current.y - targetPos.y) / 2, 0);
            else
                midPoint = new Vector3((targetPos.x - current.x) / 2, (targetPos.y - current.y) / 2, 0);

       

        float length = Mathf.Sqrt(Mathf.Pow(current.x - targetPos.x, 2) + Mathf.Pow(current.y - targetPos.y, 2));
        
        Vector3 AngelPoint;

        //calculate Angel point
        if (Mathf.Abs(current.x) > Mathf.Abs(targetPos.x))
            AngelPoint.x = targetPos.x;      
        else
            AngelPoint.x = current.x;

        if (Mathf.Abs(current.y) > Mathf.Abs(targetPos.y))
            AngelPoint.y = targetPos.y;
        else
            AngelPoint.y = current.y;


        float length2;
        if (AngelPoint.x == current.x)
        {
            length2 =Mathf.Abs( AngelPoint.y - current.y);
        }
        else
            length2 = Mathf.Abs(AngelPoint.y - targetPos.y);



        float sin = length2 / length;
        float finalAngel = Mathf.Asin(sin);

        line = (GameObject) Instantiate(instantiatedline, midPoint, new Quaternion(0, 0, 0, 0));
        line.transform.Rotate(0, 0, finalAngel*180/Mathf.PI);
       
        Debug.Log( finalAngel * 180 / Mathf.PI);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
