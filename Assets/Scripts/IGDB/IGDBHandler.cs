using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


[System.Serializable]
public class Token
{
    public string access_token;
    public string token_type;
    public int expires_in;
}

public class IGDBHandler : MonoBehaviour
{
    public readonly string APP_ID = "ww67u9s1cjyzzhj6gnp8fho3kcstxc";
    public readonly string APP_SECRET = "wk1j1pdg2je5hq9wto8l9pt1vn4tra";
    private Token token = null;

    public void Start()
    {
        StartCoroutine(GetToken());
    }

    private IEnumerator GetToken()
    {
        WWWForm form = new();
        form.AddField("client_id", APP_ID);
        form.AddField("client_secret", APP_SECRET);
        form.AddField("grant_type", "client_credentials");

        using UnityWebRequest www = UnityWebRequest.Post("https://id.twitch.tv/oauth2/token", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
            yield break;
        }

        string json = www.downloadHandler.text;
        token = JsonUtility.FromJson<Token>(json);
        Debug.Log(token.access_token);
        Debug.Log(GameRequest.GetGame("Zelda", APP_ID, token.access_token));
    }
}