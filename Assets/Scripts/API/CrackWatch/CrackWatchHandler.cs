using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Linq;

public class CrackWatchHandler : MonoBehaviour
{
    public static IEnumerator GetAll(IGDB_Game game, System.Action<CrackWatch_Game[]> callback)
    {
        // post request on https://gamestatus.info/back/api/gameinfo/game/search_title/ with body {"title":"game.name"}
        string url = "https://gamestatus.info/back/api/gameinfo/game/search_title/";
        string jsonBody = $"{{\"title\":\"{game.name}\"}}";
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonBody);

        UnityWebRequest request = new(url, "POST") { uploadHandler = new UploadHandlerRaw(bodyRaw) };
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string json = "{\"games\":" + request.downloadHandler.text + "}";
            CrackWatch_Games allGames = JsonUtility.FromJson<CrackWatch_Games>(json);
            callback(allGames.games);
        }
    }

    public static IEnumerator GetGame(IGDB_Game game, System.Action<CrackWatch_Game> callback)
    {
        // post request on https://gamestatus.info/back/api/gameinfo/game/search_title/ with body {"title":"game.name"}
        string url = "https://gamestatus.info/back/api/gameinfo/game/search_title/";
        string jsonBody = $"{{\"title\":\"{game.name}\"}}";
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonBody);

        UnityWebRequest request = new(url, "POST") { uploadHandler = new UploadHandlerRaw(bodyRaw) };
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
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
            CrackWatch_Game bestMatch = GetMatch(allGames.games, game);
            callback(bestMatch);
        }
    }

    public static CrackWatch_Game GetMatch(CrackWatch_Game[] allGames, IGDB_Game game)
    {
        // most similar release date
        foreach (CrackWatch_Game crackgame in allGames)
            if (crackgame.release_date == game.GetReleaseDate())
                return crackgame;

        // Remove all games with levenstein distance > 3
        // for (int i = 0; i < allGames.Length; i++)
        //     if (LevenshteinDistance.Compute(allGames[i].title, game.name) > 5)
        //         allGames[i] = null;
        // allGames = allGames.Where(x => x != null).ToArray();

        if (allGames.Length == 0) return null;

        return allGames[0];
    }
}