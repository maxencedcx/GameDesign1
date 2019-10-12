using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class ArticlesLoader : MonoSingleton<ArticlesLoader>
{
    private FileInfo[] GetArticlesInFolder(string folder)
    {
        DirectoryInfo d = new DirectoryInfo(folder);
        return d.GetFiles("*.txt");
    }

    public List<Article> LoadArticles(string context)
    {
        List<Article> articles = new List<Article>();

        try
        {
            foreach (FileInfo fi in GetArticlesInFolder(Application.dataPath + "/Resources/Articles/" + context))
            {
                Article article = JsonConvert.DeserializeObject<Article>(File.ReadAllText(fi.FullName));
                article.media = fi.Name.Replace(fi.Extension, "");
                Debug.Log(article.media);
                articles.Add(article);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception catched: " + e.Message);
        }

        return articles;
    }
}

