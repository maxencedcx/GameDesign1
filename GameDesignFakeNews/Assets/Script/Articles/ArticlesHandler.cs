using System.Collections.Generic;
using UnityEngine;

public class ArticlesHandler : MonoSingleton<ArticlesHandler>
{
    [SerializeField] List<GameObject> articlesUI;
    public List<Article> articles = new List<Article>();

    public void AddArticle(Article article)
    {
        Debug.Log("adding article : " + article.title);
        articles.Add(article);
    }

    public void RemoveArticle(string title)
    {
        articles.Remove(articles.Find(article => article.title == title));
    }

    public void LoadArticles(string context)
    {
        int index = 0;
        foreach (Article article in ArticlesLoader.Instance.LoadArticles(context))
        {
            AddArticle(article);
            if (index < articlesUI.Count)
                articlesUI[index].GetComponent<ArticleMapper>().MapArticle(article);
            index++;
        }
    }

    public void ClearArticles()
    {
        articles.Clear();
    }
}
