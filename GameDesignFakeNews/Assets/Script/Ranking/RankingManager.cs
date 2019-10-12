using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public Dictionary<string, int> NewspaperRanking = new Dictionary<string, int>()
    {
        {"News", 0},
        {"News (1)", 0},
        {"News (2)", 0},
        {"News (3)", 0},
        {"News (4)", 0},
        {"News (5)", 0}
    };
    [SerializeField] Transform slots;

    public void UpdateRanking()
    {
        foreach (Transform slotTransform in slots)
        {
            int Addscore = 6;
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if (item)
            {
                NewspaperRanking[item.name] += Addscore;
                Addscore--;
            }
        }
    }

    public string GetTopMedia()
    {
        int BestScore = 0;
        string BestMedia ="";
        foreach (var item in NewspaperRanking)
        {
            if (item.Value > BestScore)
            {
                BestScore = item.Value;
                BestMedia = item.Key;
            }
        }
        return (BestMedia);
    }
}
