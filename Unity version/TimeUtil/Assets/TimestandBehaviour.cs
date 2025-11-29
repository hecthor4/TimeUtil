using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class TimestandBehaviour : MonoBehaviour
{
    public TMP_Text text;
    public string item_name;
    public int day;
    public int month;
    public int year;

    public string daysUntilTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int DaysUntil(int day, int month, int year)
    {
        DateTime target;
        try
        {
            target = new DateTime(year, month, day);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentException("invalid");
        }
        DateTime today = DateTime.Today;

        TimeSpan diff = target - today;

        return diff.Days;
    }

    public void CalculateDays(int day, int month, int year)
    {
        DateTime target = new DateTime(year, month, day);
        DateTime today = DateTime.Today;
        TimeSpan diff = target - today;

        int daysUntilTarget_int = diff.Days;
        daysUntilTarget = daysUntilTarget_int.ToString();
    }

    public void ChangeData(string _name, int _day, int _month, int _year)
    {
        string item_name = _name;
        int day = _day + 1;
        int month = _month + 1;
        int year = _year + 2025;

        CalculateDays(day, month, year);
        text.text = item_name + " / Quedan: " + daysUntilTarget + " días.";
    }
}
