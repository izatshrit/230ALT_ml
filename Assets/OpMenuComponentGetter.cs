using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OpMenuComponentGetter : MonoBehaviour {
    //this class will contain each options menu's component
    //to access children of this particular menu that would be done by accessing this script first, then the definded component/child
    //accessing an arbitray child from an outsider class/code/funciton would be impossible without this class
    //.. Well it's not impossible, but this one is more organized method to do it.

    public Text nameOfMenu;
    public InputField inheritance;

}
