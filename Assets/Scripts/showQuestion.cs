using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showQuestion : MonoBehaviour
{
    public GameObject dice;
    public GameObject question;
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
