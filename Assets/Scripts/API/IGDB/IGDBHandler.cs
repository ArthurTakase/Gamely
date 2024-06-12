using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class IGDBHandler : MonoBehaviour
{
    public static IEnumerator GetGamesFromName(string gameName, System.Action<string> callback)
    {
        IGDBData igdbData = GetIGDBData();

        Debug.Log("Getting game info for " + gameName);
        string url = $"https://api.igdb.com/v4/games/?search={gameName}&fields=aggregated_rating,cover.image_id,artworks,category,collection,collections,cover,dlcs,expanded_games,expansions,external_games,first_release_date,follows,forks,franchise,franchises,game_engines,game_localizations,game_modes,genres,hypes,involved_companies,keywords,language_supports,multiplayer_modes,name,parent_game,platforms,player_perspectives,ports,rating,rating_count,release_dates,remakes,remasters,screenshots,similar_games,slug,standalone_expansions,status,storyline,summary,tags,themes,total_rating,total_rating_count,updated_at,url,version_parent,version_title,videos,websites;";

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Accept", "application/json");
        www.SetRequestHeader("Client-ID", igdbData.APP_ID);
        www.SetRequestHeader("Authorization", $"Bearer {igdbData.token.access_token}");

        yield return www.SendWebRequest();

        Debug.Log("Response code: " + www.responseCode);

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
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