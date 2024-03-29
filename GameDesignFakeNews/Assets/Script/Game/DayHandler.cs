﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayHandler : MonoSingleton<DayHandler>
{
    [SerializeField] private GameObject EndGamePanel;
    [SerializeField] private int totalDays = 1;
    [SerializeField] private int dayIndex = 0;
    private RankingManager rankingManager;
    private int endDayIndex = 0;

    private void Start()
    {
        rankingManager = GetComponent<RankingManager>();
        StartDay();
    }

    public void StartDay()
    {
        if (dayIndex < totalDays + 3)
        {
            string context = (++dayIndex <= totalDays) ? ("Day" + dayIndex) : ("EndGame/Day" + dayIndex);
            ArticlesHandler.Instance.LoadArticles(context);
        }
        else
        {
            EndGamePanel.SetActive(true);
            EndGamePanel.GetComponentInChildren<Text>().text += "\nVous avez eu la fin du media " + rankingManager.GetTopMedia(); 
        }
    }

    public void EndDay()
    {
        rankingManager.UpdateRanking();
        ArticlesHandler.Instance.ClearArticles();
        StartDay();
    }
}
