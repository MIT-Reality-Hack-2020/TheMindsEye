using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic {
    public string objectName;
    public float totalTime;
}

public class Global
{
    public static bool fadeOut = false;
    public static string weapon = "";
    public static string murderer = "";

    public static bool EndGame = false;
    public static int interation = 0;

    public static Statistic[] statistic = new Statistic[30];
}
