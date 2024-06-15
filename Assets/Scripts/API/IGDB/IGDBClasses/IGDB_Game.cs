using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IGDB_Image
{
    public int id;
    public string image_id;

    public string GetURL()
    {
        return $"https://images.igdb.com/igdb/image/upload/t_cover_big/{image_id}.jpg";
    }
}

[System.Serializable]
public class IGDB_Genre
{
    public int id;
    public string name;
}

[System.Serializable]
public class IGDB_Platform
{
    public int id;
    public string name;
}

[System.Serializable]
public class IGDB_Game
{
    public int id;
    public string name;
    public IGDB_Image cover;
    public IGDB_Image[] artworks;
    public int first_release_date;
    public int franchises;
    public IGDB_Genre[] genres;
    public int[] involved_companies;
    public IGDB_Platform[] platforms;
    public float aggregated_rating;
    public float rating;
    public int[] screenshots;
    public int[] similar_games;
    public string summary;
    public string url;
    public int[] collections;

    public string GetReleaseDate()
    {
        return new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(first_release_date).ToString("yyyy-MM-dd");
    }

    public string GetReleaseDateFormatted()
    {
        return new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(first_release_date).ToString("dd MMMM yyyy");
    }

    public string GetRating()
    {
        // int rating = (int)aggregated_rating;
        if (aggregated_rating > 0) ((int)aggregated_rating).ToString();
        return ((int)rating).ToString();
    }
}