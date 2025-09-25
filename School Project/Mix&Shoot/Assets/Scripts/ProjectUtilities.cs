using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectUtilities
{
    public static string FormatTimeToString(float timer)
    {
        string output = "";

        int sec = (int)(timer % 60);
        int min = (int)(timer / 60);

        output += min < 10 ? $"0{min}" : min;
        output += ":";
        output += sec < 10 ? $"0{sec}" : sec;

        return output;
    }
}
