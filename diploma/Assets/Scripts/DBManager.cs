using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager 
{
    public static string nickname;
    public static string mail;
    public static string difficult;
    public static string skin_id;
    public static int id;
    public static float score;
    public static int gold;
    public static float diff_status = 1f;
    public static bool LoggedIn { get { return mail != null; } }

    public static void LoggedOut()
    {
        mail = null;
    }
}
