using System.Collections.Generic;
using UnityEngine;

public class ArticlesHandler : MonoSingleton<ArticlesHandler>
{
    [SerializeField] List<GameObject> articlesUI;
    public List<Article> articles = new List<Article>();
    private RankingManager rankingManager;

    void Start()
    {
        rankingManager = GetComponent<RankingManager>();
    }

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
        if (context.StartsWith("EndGame"))
            context += "/" + rankingManager.GetTopMedia();
        Debug.Log(context);
        foreach (Article article in ArticlesLoader.Instance.LoadArticles(context))
        {
            AddArticle(article);
            checkMedia(article);
        }
    }

    private void checkMedia(Article article)
    {
        foreach (GameObject media in articlesUI)
        {
            if (media.name.Equals(article.media))
                media.GetComponent<ArticleMapper>().MapArticle(article);
        }
    }

    public void ClearArticles()
    {
        articles.Clear();
    }
}
