using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string username;
    //public static int score;
    public static bool LoggedIn { get { return username != null; } }
    public static string gameName = "";
    public static int numOfPlayers = 0;
    public static Dictionary<int, string[]> game_data = new Dictionary<int, string[]>();
    public static bool GameUploaded { get { return game_data != null; } }

    public static void LogOut()
    {
        username = null;
    }



}
