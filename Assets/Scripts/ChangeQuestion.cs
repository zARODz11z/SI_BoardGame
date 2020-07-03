using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using TMPro;
public class ChangeQuestion : MonoBehaviour
{
    static public TextMeshProUGUI text;
    public string filePath = @"Assets\Questions.txt";
    static public string[] lines;
    static public int index = 0;
    public GameObject dice;
    static public TMP_InputField QuestionNumInput;
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("text").GetComponent<TextMeshProUGUI>();
        lines = File.ReadAllLines(filePath); //returns an array of strings
        foreach(string line in lines)
        {
            Debug.Log(line);
        }
        text.text = lines[0];

    }

    static public void displayNewQuestion()
    {
        Debug.Log("reached");
        //string Itext = QuestionNumInput.text;
        //int num = Convert.ToInt32(Itext);
        //Debug.Log("num extracted" + num);
        index += 1;
        text.text = lines[index];
    }
}
