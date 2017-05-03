using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class setName_opMenu : MonoBehaviour {

    public Text namelabel;
    public int i = 0;


    // editor access                        
    // this namelabel will be set whenever something is being written inside the class name's input field
                        
    // see class identifier script
                           
    // class identifier will set namelabel and the option menu's name inside the editor                     
    // by this line; CreateClass.opmenu[i].GetComponent<setName_opMenu>().name = gameObject.name + "Options"
    // in other words by having access to the menu from CreateClass script (since we store them in an array..)
}