using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Search : MonoBehaviour
{
    public Transform searchResultsParent;
    private PageSpawner pageSpawner;
    private readonly List<GameObject> searchResults = new();

    private void Start()
    {
        pageSpawner = GetComponent<PageSpawner>();
    }

    public void SearchGame(string gameName)
    {
        if (string.IsNullOrEmpty(gameName)) return;

        foreach (GameObject result in searchResults) Destroy(result);
        searchResults.Clear();

        StartCoroutine(IGDBHandler.GetGamesFromName(gameName, (json) =>
        {
            json = "{\"games\":" + json + "}";
            IGDB_Games games = JsonUtility.FromJson<IGDB_Games>(json);
            foreach (IGDB_Game game in games.games)
            {
                GameObject poster = pageSpawner.SpawnGamePosters(game, searchResultsParent);
                searchResults.Add(poster);
            }

            AutoGrid grid = searchResultsParent.GetComponent<AutoGrid>();
            grid.UpdateCellSize();
        }));
    }
}