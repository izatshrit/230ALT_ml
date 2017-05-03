using UnityEngine;
using System.Collections;
using System.IO;
public class OpenFile : MonoBehaviour
{

    void Start()
    {
        if (File.Exists(@"text.txt"))
        {
            File.Delete(@"text.txt");
        }

    }
}
