using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

public class GameRequest : MonoBehaviour
{
    private static IEnumerator GetGame(string gameName, string clientID, string accessToken)
    {
        string url = "https://api.igdb.com/v4/search";
        WWWForm body = new();
        body.AddField("fields", "alternative_name,character,checksum,collection,company,description,game,name,platform,published_at,test_dummy,theme;");
        yield return IGDBRequest.PostRequest(url, body, clientID, accessToken);
    }

    public static async Task<Search> GetGame(string gameName, string clientID, string accessToken)
    {
        string url = "https://api.igdb.com/v4/search";
        WWWForm body = new();
        body.AddField("fields", "alternative_name,character,checksum,collection,company,description,game,name,platform,published_at,test_dummy,theme;");
        string response = await IGDBRequest.PostRequest(url, body, clientID, accessToken);
        Search search = JsonUtility.FromJson<Search>(response);
        return search;
    }
}