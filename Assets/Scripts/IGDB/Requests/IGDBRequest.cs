using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.Networking;

public class IGDBRequest : MonoBehaviour
{
    public static async Task<string> PostRequest(string url, WWWForm body, string clientID, string accessToken)
    {
        using UnityWebRequest www = UnityWebRequest.Post(url, body);
        www.SetRequestHeader("Accept", "application/json");
        www.SetRequestHeader("Client-ID", clientID);
        www.SetRequestHeader("Authorization", "Bearer " + accessToken);

        while (!www.isDone)
        {
            await Task.Yield();
        }

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
            return null;
        }

        return www.downloadHandler.text;
    }
}