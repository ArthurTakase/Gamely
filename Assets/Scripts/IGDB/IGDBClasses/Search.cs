using UnityEngine;

[System.Serializable]
public class Search
{
    // https://api-docs.igdb.com/?shell#search
    public string checksum { get; set; }
    public string[] game { get; set; }
    public Game[] gameObj { get; set; }
}