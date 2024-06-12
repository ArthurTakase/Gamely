using UnityEngine;
using TMPro;

public class Search : MonoBehaviour
{
    public TextMeshProUGUI searchResultText;

    public void SearchGame(string gameName)
    {
        Debug.Log("Searching for " + gameName);
        searchResultText.text = "";

        if (string.IsNullOrEmpty(gameName))
            return;

        StartCoroutine(RAWGHandler.GetGamesFromName(gameName, (json) =>
        {
            SearchResult searchResult = JsonUtility.FromJson<SearchResult>(json);
            foreach (Game game in searchResult.results)
                searchResultText.text += game.name + "\n";
        }));
    }
}