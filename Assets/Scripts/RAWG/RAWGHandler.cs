using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RAWGHandler : MonoBehaviour
{
    // public readonly string APP_ID = "ww67u9s1cjyzzhj6gnp8fho3kcstxc";
    // public readonly string APP_SECRET = "wk1j1pdg2je5hq9wto8l9pt1vn4tra";
    public static string RAWG_API_KEY = "007a5a77b74046b4bfb3db3998149a13";

    public static IEnumerator GetGamesFromName(string gameName, System.Action<string> callback)
    {
        Debug.Log("Getting game info for " + gameName);
        string url = $"https://api.rawg.io/api/games?key={RAWG_API_KEY}&search={gameName}";
        UnityWebRequest www = UnityWebRequest.Get(url);
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
}