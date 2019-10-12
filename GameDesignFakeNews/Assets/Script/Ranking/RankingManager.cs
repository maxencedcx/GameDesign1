using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public Dictionary<string, int> NewspaperRanking = new Dictionary<string, int>()
    {
        {"Economique", 0},
        {"Anarchiste", 0},
        {"Militaire", 0},
        {"Scientifique", 0},
        {"Religieux", 0},
    };
    [SerializeField] Transform slots;

    public void UpdateRanking()
    {
        Debug.Log("passe1");
        int Addscore = 5;
        foreach (Transform slotTransform in slots)
        {
            name = slotTransform.GetChild(0).name;
            if (!name.Contains("Text"))
            {
                NewspaperRanking[name] += Addscore;
                Addscore--;
            }
        }
        Debug.Log("passe3");    
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
