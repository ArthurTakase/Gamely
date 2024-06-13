using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class GamePage : MonoBehaviour
{
    public bool enableBackButton = true;
    private IGDB_Game game;
    private float width;
    private bool isDescriptionExpanded = false;
    private readonly float maxDescription = 300;

    public Image backgroundPosterImage;
    public Image posterImage;
    public TextMeshProUGUI navbarTitleText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI subtitleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI platformsText;
    public TextMeshProUGUI genresText;
    public TextMeshProUGUI howlongtobeatText;
    public TextMeshProUGUI crackwatchText;

    public void Start()
    {
        width = transform.GetComponent<RectTransform>().rect.width;
        transform.localPosition = new Vector3(width, 0, 0);
        transform
            .DOLocalMoveX(0, 0.3f)
            .SetEase(Ease.OutQuad);
    }

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKeyDown(KeyCode.Escape) && enableBackButton)
                Close();
    }

    public void Close()
    {
        FindObjectOfType<Navigate>().ShowNavbar();
        float width = transform.GetComponent<RectTransform>().rect.width;
        transform
            .DOLocalMoveX(width, 0.3f)
            .SetEase(Ease.InQuad)
            .OnComplete(() => Destroy(gameObject));
    }

    public void ExpandDescription()
    {
        if (isDescriptionExpanded && game.summary.Length > maxDescription)
        {
            isDescriptionExpanded = false;
            descriptionText.text = game.summary[..(System.Index)maxDescription] + "...";
            return;
        }
        else
        {
            descriptionText.text = game.summary;
            isDescriptionExpanded = true;
        }
    }

    // private IEnumerator CrackWatch(System.Action<string> callback)
    // {
    //     // post request on https://gamestatus.info/back/api/gameinfo/game/search_title/ with body {"title":"game.name"}
    //     string url = "https://gamestatus.info/back/api/gameinfo/game/search_title/";
    //     string jsonBody = $"{{\"title\":\"{game.name}\"}}";
    //     byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonBody);

    //     UnityWebRequest request = new(url, "POST") { uploadHandler = new UploadHandlerRaw(bodyRaw) };
    //     request.SetRequestHeader("Content-Type", "application/json");
    //     request.downloadHandler = new DownloadHandlerBuffer();

    //     yield return request.SendWebRequest();

    //     if (request.result == UnityWebRequest.Result.ConnectionError)
    //     {
    //         Debug.Log(request.error);
    //     }
    //     else
    //     {
    //         callback(request.downloadHandler.text);
    //     }
    // }

    public void SetGame(IGDB_Game game)
    {
        this.game = game;

        titleText.text = game.name;
        navbarTitleText.text = game.name;
        scoreText.text = game.GetRating();
        subtitleText.text = game.GetReleaseDate();
        descriptionText.text = game.summary.Length > maxDescription ? game.summary[..(System.Index)maxDescription] + "..." : game.summary;
        platformsText.text = "";
        genresText.text = "";
        howlongtobeatText.text = "Loading...";
        crackwatchText.text = "Loading...";

        foreach (IGDB_Platform platform in game.platforms) platformsText.text += platform.name + ", ";
        if (platformsText.text.Length > 0) platformsText.text = platformsText.text[..^2];

        foreach (IGDB_Genre genre in game.genres) genresText.text += genre.name + ", ";
        if (genresText.text.Length > 0) genresText.text = genresText.text[..^2];

        StartCoroutine(CrackWatchHandler.GetGame(game.name, (game) =>
        {
            if (game == null)
            {
                crackwatchText.text = "Not found";
                return;
            }

            Debug.Log(game.Serialize());
            crackwatchText.text = game.Serialize();
        }));

        StartCoroutine(DownloadPicture.Download(game.cover.GetURL(), (sprite) =>
        {
            if (game.artworks == null || game.artworks.Length == 0) backgroundPosterImage.sprite = sprite;
            posterImage.sprite = sprite;
        },
        (errortxt) =>
        {
            posterImage.sprite = null;
            posterImage.color = Color.black;
        }));

        if (game.artworks != null && game.artworks.Length > 0)
        {
            StartCoroutine(DownloadPicture.Download(game.artworks.First().GetURL(), (sprite) =>
            {
                backgroundPosterImage.sprite = sprite;
            },
            (errortxt) =>
            {
                backgroundPosterImage.sprite = null;
                backgroundPosterImage.color = Color.black;
            }));
        }
    }
}