using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class IGDBHandler : MonoBehaviour
{
    public static IEnumerator GetGamesFromName(string gameName, System.Action<string> callback)
    {
        IGDBData igdbData = GetIGDBData();

        string url = $"https://api.igdb.com/v4/games/?search={gameName}&fields=platforms.name,genres.name,aggregated_rating,artworks.image_id,cover.image_id,aggregated_rating_count,artworks,category,collection,collections,cover,first_release_date,franchise,franchises,genres,involved_companies,name,parent_game,platforms,rating,release_dates,screenshots,similar_games,slug,status,storyline,summary,tags,themes,updated_at,url;limit 50;";

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Accept", "application/json");
        www.SetRequestHeader("Client-ID", igdbData.APP_ID);
        www.SetRequestHeader("Authorization", $"Bearer {igdbData.token.access_token}");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            callback(www.downloadHandler.text);
        }
    }

    public static IGDBData GetIGDBData()
    {
        return FindObjectOfType<IGDBManager>().IGDBData;
    }
}