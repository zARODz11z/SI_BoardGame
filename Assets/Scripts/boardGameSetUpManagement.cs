using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using UnityEngine;

public class boardGameSetUpManagement : MonoBehaviour
{
    private string gameName = "";
    static public int numOfPlayers = 0;
    public GameObject[] characters;
    public Vector3 startPos;
    public string[] gameArray = DBManager.gameContent;


    public void finishCreate()
    {
        gameName = getGameName();
        numOfPlayers = getNumberOfPlayers();
        DBManager.gameName = gameName;
        DBManager.numOfPlayers = numOfPlayers;

        if (DBManager.gameName.Length > 0 &&  DBManager.numOfPlayers!=0)
        {
            StartCoroutine(createFile());
            
            Debug.Log(DBManager.username);
            SceneManager.LoadScene("boardGameInputQuestion");
        }
        else
        {
            //string msg = GameObject.Find("errorMsg").GetComponent<Text>().ToString();
            //ErrorMsgs.SetActive(true);
            Debug.Log("game length not long enough or num of players = 0");

        }
        
    }
   
    IEnumerator createFile()
    {
        Debug.Log("REACHED THE CREATE FILE COURUTINE");
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("gameName", gameName);
        form.AddField("numOfPlayers", numOfPlayers.ToString());
        

        WWW www = new WWW("https://www.andrewthedev.com/UnityGames/SI_BoardGame/fromUnity.php", form);
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Successfully made file");
        }
        else
           Debug.Log(www.text);


    }


    public int getNumberOfPlayers()
    {
        numOfPlayers = int.Parse(GameObject.Find("noOfPlayersInput").GetComponent<Text>().text);
        Debug.Log("num of players is: " + numOfPlayers);
        return numOfPlayers;

    }
    public void MuteToggle()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute = !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute;
    }
    
    public string getGameName()
    {
        gameName = GameObject.Find("gameNameInput").GetComponent<Text>().text;
        Debug.Log("game Name is: " + gameName);
        return gameName;
    }
    
    public void goHome()
    {
        SceneManager.LoadScene("WelcomePage");
    }

}


