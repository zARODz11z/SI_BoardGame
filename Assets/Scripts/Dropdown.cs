using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dropdown : MonoBehaviour
{
    public GameObject output;
    public int val;
    private void Start()
    {
        val = GameObject.FindGameObjectWithTag("FontDropDown").GetComponent<TMP_Dropdown>().value;
    }
    public void HandleInputData()
    {
        //val = 
        if (val == 0)
        {
            output.GetComponent<TMP_InputField>().pointSize = 60;
        }
        else if (val==1)
        {
            output.GetComponent<TMP_InputField>().pointSize = 65;
        }
        else if (val == 2)
        {
            output.GetComponent<TMP_InputField>().pointSize = 70;
        }
        else if (val == 3)
        {
            output.GetComponent<TMP_InputField>().pointSize = 75;
        }
    }

}
