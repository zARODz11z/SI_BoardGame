using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class fileManager : MonoBehaviour
{
    // Start is called before the first frame update
    string path;
    public Text consoleText;

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with game txt file", "", "txt");
        GetGameFile();
    }

    void GetGameFile()
    {
       
    }

   // void UpdateGameFile()
    //{
    //    WWW www = new WWW("file:///" + path);
     //   Debug.Log(www.);
   // }
}
