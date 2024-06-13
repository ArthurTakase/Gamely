using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CrackWatchHandler : MonoBehaviour
{
    public static IEnumerator GetAll(string name, System.Action<CrackWatch_Game[]> callback)
    {
        // post request on https://gamestatus.info/back/api/gameinfo/game/search_title/ with body {"title":"game.name"}
        string url = "https://gamestatus.info/back/api/gameinfo/game/search_title/";
        string jsonBody = $"{{\"title\":\"{name}\"}}";
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonBody);

        UnityWebRequest request = new(url, "POST") { uploadHandler = new UploadHandlerRaw(bodyRaw) };
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            string json = "{\"games\":" + request.downloadHandler.text + "}";
            CrackWatch_Games allGames = JsonUtility.FromJson<CrackWatch_Games>(json);
            callback(allGames.games);
        }
    }

    public static IEnumerator GetGame(string name, System.Action<CrackWatch_Game> callback)
    {
        // post request on https://gamestatus.info/back/api/gameinfo/game/search_title/ with body {"title":"game.name"}
        string url = "https://gamestatus.info/back/api/gameinfo/game/search_title/";
        string jsonBody = $"{{\"title\":\"{name}\"}}";
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonBody);

        UnityWebRequest request = new(url, "POST") { uploadHandler = new UploadHandlerRaw(bodyRaw) };
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string json = "{\"games\":" + request.downloadHandler.text + "}";
            CrackWatch_Games allGames = JsonUtility.FromJson<CrackWatch_Games>(json);
            if (allGames.games.Length == 0)
            {
                callback(null);
                yield break;
            }
            // CrackWatch_Game bestMatch = GetMatch(allGames.games, name);
            callback(allGames.games[0]);
        }
    }

    public static CrackWatch_Game GetMatch(CrackWatch_Game[] allGames, string name)
    {
        // find the one where the name is the most similar
        CrackWatch_Game bestMatch = null;
        int bestMatchScore = 0;
        foreach (CrackWatch_Game game in allGames)
        {
            int score = LevenshteinDistance.Compute(game.title.ToLower(), name.ToLower());
            if (score > bestMatchScore)
            {
                bestMatch = game;
                bestMatchScore = score;
            }
        }

        return bestMatch;
    }
}