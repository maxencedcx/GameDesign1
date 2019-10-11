using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public Dictionary<string, double> NewspaperRanking = new Dictionary<string, double>()
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
            Debug.Log(item.name + Addscore);
        }
    }
}
