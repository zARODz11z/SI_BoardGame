using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class boardGameInputQuestionManagement : MonoBehaviour
{
    public Text text;
    public InputField inputField;
    public Font BoldFont;
    public Font NormalFont;
    Toggle Boldtog;
    Toggle Italtog;
    private ColorBlock theColor;


    private bool isBolded;
    private bool isItaliced;
    // Start is called before the first frame update
    void Start()
    {
        Boldtog = GameObject.FindGameObjectWithTag("BoldButton").GetComponent<Toggle>();
        Italtog = GameObject.FindGameObjectWithTag("ItalButton").GetComponent<Toggle>();
    }

    public void LoadInputQuestionUI()
    {
        Debug.Log("Clicked");
    }
    public void Bold()
    {
        //string str1 = inputField.text.Substring(0)+"<b>";
        //string str1 = inputField.text.Substring(0, inputField.text.Length) + "<b>";
        inputField.text = inputField.text + "<b>";
        //Debug.Log(str1);
        //string str2="";

        theColor = Boldtog.colors;
        isBolded = Boldtog.isOn;
        if (isBolded)
        {

           theColor.selectedColor = Color.black;
            theColor.pressedColor = Color.red;
            Boldtog.colors = theColor;
            //inputField.textComponent.text.Insert(inputField.text.Length, "<b>");
            //text.fontStyle = FontStyle.Bold;
            //text.font = BoldFont;
            inputField.caretPosition = inputField.text.Length;

        }
        else if (!isBolded)
        {
            // str2 = inputField.text.Substring(inputField.text.LastIndexOf(">"))+"</b>";
            inputField.text.Remove(inputField.text.Length - 3, 3);
            Debug.Log(inputField.text);

            inputField.text=inputField.text.Substring(0,inputField.text.Length-3)+"</b>";
            theColor.selectedColor = Color.white;
            theColor.pressedColor = Color.red;
            Boldtog.colors = theColor;
            inputField.caretPosition = inputField.text.Length;

            //text.fontStyle = FontStyle.Normal;
            //text.font = NormalFont;
        }
        //inputField.text = str1 + str2;
        inputField.caretPosition = inputField.text.Length;
    }
    public void Italics()
    {
        theColor = Italtog.colors;

        isItaliced = Italtog.isOn;
        if (isItaliced)
        {
            theColor.selectedColor = Color.black;
            theColor.pressedColor = Color.red;
            Italtog.colors = theColor;
            text.fontStyle = FontStyle.Italic;
            //text.font = BoldFont;
        }
        else if (!isItaliced)
        {
            theColor.selectedColor = Color.white;
            theColor.pressedColor = Color.red;
            Italtog.colors = theColor;
            text.fontStyle = FontStyle.Normal;
        }
    }
    public void FontSize()
    {

    }
    public void Image()
    {

    }
    public void Superscript()
    {

    }
    public void Subsript()
    {

    }
    public void ContinueButton()
    {

    }


}
