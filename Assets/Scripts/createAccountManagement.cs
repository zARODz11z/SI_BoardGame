using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.VersionControl;
using UnityEngine.Networking;

public class createAccountManagement : MonoBehaviour
{
    public static string username;
    public static string password;
    private string confirmPassword;
    public GameObject ErrorMsgs;
    public static string tempUsername;

    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;


    
    public void CallRegister()
    {
        StartCoroutine(Register());

    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost:81/SI_BoardGame/register.php", form);

        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully");
            SceneManager.LoadScene("WelcomePage");

        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
    
    public void finishCreate()
    {
        getUsername();
        getPassword();
        //RetrieveFromDatabase(username);
        

        if (tempUsername.Length==0&&!username.Equals("") && !password.Equals("") && password.Equals(confirmPassword))
        {
            //GameObject.Find("PasswordInput").GetComponent<InputField>().contentType = InputField.ContentType.Password;

            //GameObject.Find("ConfirmPasswordInput").GetComponent<InputField>().contentType = InputField.ContentType.Password;
            
                Debug.Log("passed 1st if in finish");
                User user = new User(username, password);
                //PostToDatabase(user, username);
                SceneManager.LoadScene("boardGameSetUp");
         

        }
        else
        {
            //string msg = GameObject.Find("errorMsg").GetComponent<Text>().ToString();
            Debug.Log("error");
           if (tempUsername.Length!=0)
            {
                Debug.Log("username is taken");
            }

            ErrorMsgs.SetActive(true);

        }
    }
  

    public void MuteToggle()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute = !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute;
    }
    public void getUsername()
    {
        username = GameObject.Find("userNameInput").GetComponent<Text>().text;
        Debug.Log("username is: " + username);
    }
    public void getPassword()
    {
        password = GameObject.Find("passwordInput").GetComponent<Text>().text;
        confirmPassword = GameObject.Find("confirmPasswordInput").GetComponent<Text>().text;
        Debug.Log("password is: " + password);
        Debug.Log("confirm password is: " + confirmPassword);

    }
    public void goHome()
    {
        SceneManager.LoadScene("WelcomePage");
    }

}


