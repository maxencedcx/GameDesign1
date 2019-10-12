using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayHandler : MonoSingleton<DayHandler>
{
    [SerializeField] private int totalDays = 1;
    [SerializeField] private int dayIndex = 0;
    private int endDayIndex = 0;

    private void Start()
    {
        StartDay();
    }

    public void StartDay()
    {
        string context = (++dayIndex <= totalDays) ? ("Day" + dayIndex) : ("EndGame/Day" + dayIndex);
        ArticlesHandler.Instance.LoadArticles(context);
    }

    public void EndDay()
    {
        ArticlesHandler.Instance.ClearArticles();
        StartDay();
    }
}
