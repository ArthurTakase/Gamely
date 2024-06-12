using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GamePoster : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI title;
    [HideInInspector] public string id;

    public void SetGame(IGDB_Game game)
    {
        title.text = game.name;
        id = game.id.ToString();
        StartCoroutine(LoadImage(game.cover.GetURL()));
    }

    private IEnumerator LoadImage(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError) Debug.Log(www.error);
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }

        image.color = Color.white;
    }
}