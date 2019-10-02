using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RankingBar : MonoBehaviour, IHasChanged
{
    [SerializeField] Transform slots;
    [SerializeField] Text rankText;

    void Start()
    {
        HasChanged();
    }

    #region IHasChanged implementation
    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" - ");
        foreach(Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if (item)
            {
                builder.Append(item.name);
                builder.Append(" - ");
            }
        }
        rankText.text = builder.ToString();
    }
    #endregion

}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}