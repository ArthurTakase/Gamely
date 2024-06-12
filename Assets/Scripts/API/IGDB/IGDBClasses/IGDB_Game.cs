using UnityEngine;

[System.Serializable]
public class Cover
{
    public int id;
    public string image_id;

    public string GetURL()
    {
        return $"https://images.igdb.com/igdb/image/upload/t_cover_big/{image_id}.jpg";
    }
}

[System.Serializable]
public class IGDB_Game
{
    public int id;
    public string name;
    public Cover cover;
    public int first_release_date;
    public int franchises;
    public int[] genres;
    public int[] involved_companies;
    public int[] platforms;
    public float aggregated_rating;
    public int[] screenshots;
    public int[] similar_games;
    public string summary;
    public string url;
    public int[] collections;
}