using UnityEngine;

[System.Serializable]
public class Game
{
    // https://api-docs.igdb.com/?shell#game

    public double aggregated_rating { get; set; }
    public int aggregated_rating_count { get; set; }
    public string[] artworks { get; set; }
    public Artwork[] artworksObj { get; set; }
    public string checksum { get; set; }
    public string[] collections { get; set; }
    public Collection[] collectionsObj { get; set; }
    public Cover cover { get; set; }
    // first release date
    public string[] genres { get; set; }
    public Genre[] genresObj { get; set; }
    public string name { get; set; }
    // platforms
    public double rating { get; set; }
    // similar_games
    // status
}