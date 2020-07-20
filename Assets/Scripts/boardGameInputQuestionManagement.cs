using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class boardGameInputQuestionManagement : MonoBehaviour
{
    public InputField QuestionInput;
    public InputField AnswerInput;

    public int Index = 0;
    public string[] gameArray = DBManager.gameContent;

    public void showPreviousQuestion()
    {

    }
    public void showNextQuestion()
    {
        
    }

}
