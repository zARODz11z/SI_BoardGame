using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Runtime.CompilerServices;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
    BinaryFormatter binFormatter = new BinaryFormatter();
    MemoryStream mStream = new MemoryStream();

    readonly string getURL = "https://www.andrewthedev.com/UnityGames/SI_BoardGame/download.php";
    readonly string postURL = "https://www.andrewthedev.com/UnityGames/SI_BoardGame/save.php";

    public Dictionary<int, string[]> game_data = new Dictionary<int, string[]>();

    public void Start()
    {
        consoleText.text = "Successfully created " + DBManager.gameName + " Dont forget to save!";

    }


    public void CallSave()
    {
        if (game_data != null)
        {
            consoleText.text = "Sending data...";
            binFormatter.Serialize(mStream, game_data);
            byte[] binaryGameData = mStream.ToArray();
            string binaryString = Convert.ToBase64String(binaryGameData);
            //byte[] ex = Convert.FromBase64String(binaryData); How to convert back
            Debug.Log("Length of byte array binaryData: "+binaryGameData.Length.ToString());
            //Debug.Log(ex.Length);
            
            
             StartCoroutine(Save(DBManager.gameName, DBManager.username, binaryString));
        }
        else
        {
            consoleText.text = "Add a question & answer before saving";

        }
    }
    IEnumerator Save(string gameName, string userName, string binaryGameData)
    {
        Debug.Log("Binary string length:" +binaryGameData.Length.ToString());
        WWWForm form = new WWWForm();
        form.AddField("gameName", "exampleGame");
        form.AddField("game_data", binaryGameData);
        //wwwForm.Add(new MultipartFormDataSection("gameData", gameData));

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            string fromPhp = www.downloadHandler.text;
            Debug.Log(fromPhp.Equals(binaryGameData));
            Debug.Log("From PHP: "+www.downloadHandler.text);
        }
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
        Debug.Log("Question: " + game_data[current_question][0] + "\nAnswer: " + game_data[current_question][1]);



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
