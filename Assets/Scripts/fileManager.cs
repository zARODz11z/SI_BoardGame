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
        if(path != null)
        {
            string [] fileContent = File.ReadAllLines(path);
            DBManager.gameContent = fileContent;
            //foreach(string line in fileContent)
            //{
            //    Debug.Log(line);
            //}
            consoleText.text = "Successfully uploaded " + fileContent[0];
            //UpdateGameFile();
        }
    }

   // void UpdateGameFile()
    //{
    //    WWW www = new WWW("file:///" + path);
     //   Debug.Log(www.);
   // }
}
