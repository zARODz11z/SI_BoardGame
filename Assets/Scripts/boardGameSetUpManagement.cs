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
    //public string[] gameArray = DBManager.gameContent;
    public Text consoleText;
    readonly string getURL = "https://www.andrewthedev.com/UnityGames/SI_BoardGame/download.php";
    public Dictionary<int, string[]>[] List_of_games;
    public void Start()
    {
        consoleText.text = "Downloading your saved games...";
        StartCoroutine(download());
    }

    public void finishCreate()
    {
        gameName = getGameName();
        numOfPlayers = getNumberOfPlayers();
        DBManager.gameName = gameName;
        DBManager.numOfPlayers = numOfPlayers;

        if (DBManager.gameName.Length > 0 &&  DBManager.numOfPlayers!=0)
        {
            
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
   
    IEnumerator download()
    {
        Debug.Log("REACHED THE download COURUTINE");
        UnityWebRequest www = UnityWebRequest.Get(getURL);
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            consoleText.text = www.downloadHandler.text;
        }

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


