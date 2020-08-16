using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;
using System;

public class boardGameManger : MonoBehaviour
     
{
    public GameObject dice;
    //public string question;
   // public string answer;
    public GameObject editQuestions;
    public Button displayQuestion, inputQuestion;
    public InputField InputQuestion;
    public InputField InputAnswer;
    public Text consoleText;
    public int current_question;
    public Text current_question_text;
    
    public Dictionary<int, string[]> game_data = new Dictionary<int, string[]>();

    public void Start()
    {
        consoleText.text = "Successfully created " + DBManager.gameName + " Dont forget to save!";
    }


    [DllImport("__Internal")]
    private static extern void SaveFile(string []fileData, string fileName);


    public void Save()
    {
        SaveFile(DBManager.gameContent, DBManager.gameName);
        
    }

    public void EditQuestions()
    {
        consoleText.text = "";
        string button_name = EventSystem.current.currentSelectedGameObject.name;
        current_question = int.Parse(button_name);
        editQuestions.SetActive(true); //LEFT OFF HERE on 8/15
        current_question_text.text = "Editing: " + current_question.ToString();
        
        if (game_data.ContainsKey(current_question))
        {
            InputQuestion.text = game_data[current_question][0];
            InputAnswer.text = game_data[current_question][1];

        }
        //Debug.Log(int.Parse(button_name) + 2);
        //displayQuestion.interactable = false;
        //inputQuestion.interactable = true;
        //dice.SetActive(false);

    }

    public void confirm_question()
    {
        if (game_data.ContainsKey(current_question))
        {
            game_data.Remove(current_question);
        }
        string question = InputQuestion.text;
        string answer = InputAnswer.text;
        string[] Q_A_pair = { question, answer };

        game_data.Add(current_question, Q_A_pair);
        Debug.Log("Question: "+game_data[current_question][0]+ "\nAnswer: "+game_data[current_question][1]);
        


    }

    public void next_question()
    {
        if (current_question < 31)
        {
            current_question += 1;
            current_question_text.text = "Editing: " + current_question.ToString();
            if (game_data.ContainsKey(current_question))
            {
                InputQuestion.text = game_data[current_question][0];
                InputAnswer.text = game_data[current_question][1];

            }
            else
            {
                InputQuestion.text = "";
                InputAnswer.text = "";
            }
        }
    }

    public void previous_question()
    {
        if (current_question > 0)
        {
            current_question -= 1;
            current_question_text.text = "Editing: " + current_question.ToString();
            if (game_data.ContainsKey(current_question))
            {
                InputQuestion.text = game_data[current_question][0];
                InputAnswer.text = game_data[current_question][1];

            }
            else
            {
                InputQuestion.text = "";
                InputAnswer.text = "";
            }
        }
        
    }

    public void print_game_data()
    {
        foreach (KeyValuePair<int, string[]> kvp in game_data)
        {
            Debug.Log("Key: " + kvp.Key.ToString() + "\nQuestion: " + kvp.Value[0] + "\nAnswer: " + kvp.Value[1]);
        }
    }

    public void close_edit_questions()
    {
        editQuestions.SetActive(false); //LEFT OFF HERE on 8/15
        consoleText.text = "Dont forget to save your changes!";

    }
}
