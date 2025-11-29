using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Dropdown month_dd;
    public TMP_Dropdown day_dd;
    public TMP_Dropdown year_dd;
    public Button create_b;

    public GameObject timePrefab;
    public Transform prefabPos;

    private void Awake()
    {
        //year
        year_dd.value = 2025;

        //months
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
            .Where(m => !string.IsNullOrEmpty(m))
            .ToList();

        month_dd.ClearOptions();
        month_dd.AddOptions(months);

        int currentMonthIndex = System.DateTime.Now.Month - 1;
        month_dd.value = Mathf.Clamp(currentMonthIndex, 0, months.Count - 1);
        month_dd.RefreshShownValue();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForDays()
    {
        Debug.Log(month_dd.value);

        int daysInMonth = DateTime.DaysInMonth(year_dd.value, Mathf.Clamp(month_dd.value, 1, 12) + 1);
        var options = new List<string>(daysInMonth);
        for (int d = 1; d <= daysInMonth; d++)
        {
            options.Add(d.ToString());
        }

        day_dd.ClearOptions();
        day_dd.AddOptions(options);
        day_dd.RefreshShownValue();
    }

    public void Create()
    {
        GameObject newTimestand = Instantiate(timePrefab, prefabPos);
        TimestandBehaviour timestandBehaviour_ins = newTimestand.GetComponent<TimestandBehaviour>();
        timestandBehaviour_ins.ChangeData(inputField.name, month_dd.value, day_dd.value, year_dd.value);
    }
}
