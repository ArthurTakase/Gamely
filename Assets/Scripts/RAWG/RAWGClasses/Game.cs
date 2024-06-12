[System.Serializable]
public struct Plateform
{
    public string platform;
    public string released_at;
    public string requirements;
}

[System.Serializable]
public class Game
{
    public string id;
    public string slug;
    public string name;
    public string released;
    public bool tba;
    public string background_image;
    public float rating;
    public float rating_top;
    public string ratings_count;
    public string reviews_text_count;
    public string added;
    public string metacritic;
    public string playtime;
    public string suggestions_count;
    public string updated;
    public string esrb_rating;
    public Plateform[] platforms;
}