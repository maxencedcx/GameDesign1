using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticleMapper : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text text;
    public void MapArticle(Article article)
    {
        title.text = article.title;
        text.text = article.text;
    }
}
