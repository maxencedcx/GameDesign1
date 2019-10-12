
public struct Article
{
    public Article(string title, string text = "", string media = "")
    {
        this.title = title;
        this.text = text;
        this.media = media;
    }

    public string title;
    public string text;
    public string media;
}
