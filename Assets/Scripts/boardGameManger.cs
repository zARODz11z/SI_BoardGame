using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;

public class boardGameManger : MonoBehaviour
     
{
    public GameObject dice;
    public GameObject question;
    public GameObject editQuestions;
    public Button displayQuestion, inputQuestion;
    public TMP_InputField InputQuestion;
    public TMP_InputField InputAnswer;
    public Text consoleText;



    [DllImport("__Internal")]
    private static extern void SaveFile(string []fileData, string fileName);


    public void Save()
    {
        SaveFile(DBManager.gameContent, DBManager.gameName);
        
    }

    public void EditQuestions()
    {
        editQuestions.SetActive(true);
        string button_name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(int.Parse(button_name) + 2);
        //displayQuestion.interactable = false;
        //inputQuestion.interactable = true;
        //dice.SetActive(false);

    }

    // Start is called before the first frame update
    public void changeToQuestion()
    {
        dice.SetActive(false);
        question.SetActive(true);
    }
    public void changeToDice()
    {
        Debug.Log("changedToDice");
        dice.SetActive(true);
        question.SetActive(false);
    }
}
