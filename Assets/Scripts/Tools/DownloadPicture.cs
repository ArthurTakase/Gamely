using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DownloadPicture : MonoBehaviour
{
    public static IEnumerator Download(string url, System.Action<Sprite> callback, System.Action<string> errorCallback = null)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            if (errorCallback != null) errorCallback(www.error);
            else Debug.LogError(www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            callback(sprite);
        }
    }
}