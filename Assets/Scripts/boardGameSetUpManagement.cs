using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class boardGameSetUpManagement : MonoBehaviour
{
    private string saveKey;
    private string gameName;
    static public int numOfPlayers;
    public int numOfTeams;
    public GameObject ErrorMsgs;
    public GameObject[] characters;
    public Vector3 startPos;
    // Use this for initialization
    void Start()
    {
        
    }

    public void finishCreate()
    {
        getNumberOfPlayers();
        getNumberOfTeams();
        getGameName();
        getSaveKey();
        if (!gameName.Equals("") && !saveKey.Equals("") && numOfPlayers!=0 && numOfTeams!=0)
        {
            SceneManager.LoadScene("boardGameInputQuestion");
        }
        else
        {
            //string msg = GameObject.Find("errorMsg").GetComponent<Text>().ToString();
            ErrorMsgs.SetActive(true);

        }
        
    }
   
    //public static int sendNumOfPlayers()
    //{
     //   return numOfPlayers;
    //}
    public void getNumberOfTeams()
    {
        numOfTeams = int.Parse(GameObject.Find("noOfTeamsInput").GetComponent<Text>().text);
        Debug.Log("num of teams is: " + numOfTeams);
    }
    public void getNumberOfPlayers()
    {
        numOfPlayers = int.Parse(GameObject.Find("noOfPlayersInput").GetComponent<Text>().text);
        Debug.Log("num of players is: " + numOfPlayers);
    }
    public void MuteToggle()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute = !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute;
    }
    
    public void getGameName()
    {
        gameName = GameObject.Find("gameNameInput").GetComponent<Text>().text;
        Debug.Log("game Name is: " + gameName);
    }
    public void getSaveKey()
    {
        saveKey = GameObject.Find("CreatesaveKeyInput").GetComponent<Text>().text;
        Debug.Log("save Key is: " + saveKey);

    }
    public void goHome()
    {
        SceneManager.LoadScene("WelcomePage");
    }

}


