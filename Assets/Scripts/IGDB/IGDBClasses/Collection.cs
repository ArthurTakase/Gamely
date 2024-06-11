using UnityEngine;

[System.Serializable]
public class Collection
{
    public string checksum { get; set; }
    public Game[] games { get; set; }
    public string name { get; set; }
    public string slug { get; set; }
    public string url { get; set; }
}