using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public string username;
    public string password;
    public User(String userName, String passWord)
    {
        // username = createAccountManagement.username;
        //password = createAccountManagement.password;
        username = userName;
        password = passWord;
    }
}
