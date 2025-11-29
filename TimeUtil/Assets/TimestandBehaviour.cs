using TMPro;
using UnityEngine;

public class TimestandBehaviour : MonoBehaviour
{
    public TMP_Text text;
    public string name;
    public int day;
    public int month;
    public int year;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeData(string _name, int _day, int _month, int _year)
    {
        string name = _name;
        int day = _day;
        int month = _month;
        int year = _year;
    }
}
