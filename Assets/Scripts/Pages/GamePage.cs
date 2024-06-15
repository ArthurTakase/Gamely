using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    public Image navbarTitleBackground;
    public GameObject viewport;
    public GameObject metascorZone;
    public GameObject gallery;
    public GameObject screenshotPrefab;

    private Color32 greenBackground = new(9, 33, 16, 255);
    private Color32 greenOutline = new(48, 178, 69, 255);
    private Color32 yellowBackground = new(51, 53, 9, 255);
    private Color32 yellowOutline = new(178, 176, 48, 255);
    private Color32 redBackground = new(53, 12, 9, 255);
    private Color32 redOutline = new(178, 48, 48, 255);


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

        if (posterImage.sprite != null)
        {
            Vector3[] corners = new Vector3[4];
            viewport.GetComponent<RectTransform>().GetWorldCorners(corners);
            Vector3 pos = Camera.main.WorldToViewportPoint(posterImage.transform.position);
            if (pos.y > 310)
            {
                navbarTitleText.gameObject.SetActive(true);
                navbarTitleBackground.gameObject.SetActive(true);
            }
            else
            {
                navbarTitleText.gameObject.SetActive(false);
                navbarTitleBackground.gameObject.SetActive(false);
            }
        }
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
        }
        else
        {
            descriptionText.text = game.summary;
            isDescriptionExpanded = true;
        }

        DOTween.Sequence()
            .Append(descriptionText.rectTransform.DOSizeDelta(new Vector2(descriptionText.rectTransform.sizeDelta.x, descriptionText.preferredHeight), 0.3f))
            .Append(descriptionText.rectTransform.DOSizeDelta(new Vector2(descriptionText.rectTransform.sizeDelta.x, 100), 0.3f));
    }

    public void SetMetascoreColor()
    {
        if (scoreText.text == "0")
        {
            metascorZone.SetActive(false);
            return;
        }

        Transform child = metascorZone.transform.GetChild(0);
        Outline outline = child.GetComponent<Outline>();
        Image image = child.GetComponent<Image>();

        if (game.GetRatingFloat() > 0 && game.GetRatingFloat() < 50)
        {
            scoreText.color = redOutline;
            outline.effectColor = redOutline;
            image.color = redBackground;
            return;
        }

        if (game.GetRatingFloat() >= 50 && game.GetRatingFloat() < 75)
        {
            scoreText.color = yellowOutline;
            outline.effectColor = yellowOutline;
            image.color = yellowBackground;
            return;
        }

        scoreText.color = greenOutline;
        outline.effectColor = greenOutline;
        image.color = greenBackground;
    }

    public void SetGame(IGDB_Game game)
    {
        this.game = game;

        titleText.text = game.name;
        navbarTitleText.text = game.name;
        scoreText.text = game.GetRating();
        subtitleText.text = game.GetReleaseDateFormatted();
        descriptionText.text = game.summary.Length > maxDescription ? game.summary[..(System.Index)maxDescription] + "..." : game.summary;
        platformsText.text = "";
        genresText.text = "";
        howlongtobeatText.text = "Loading...";
        crackwatchText.text = "Loading...";

        SetMetascoreColor();

        foreach (IGDB_Platform platform in game.platforms) platformsText.text += platform.name + ", ";
        if (platformsText.text.Length > 0) platformsText.text = platformsText.text[..^2];
        //update height of the text
        // platformsText.rectTransform.sizeDelta = new Vector2(platformsText.rectTransform.sizeDelta.x, platformsText.preferredHeight);

        foreach (IGDB_Genre genre in game.genres) genresText.text += genre.name + ", ";
        if (genresText.text.Length > 0) genresText.text = genresText.text[..^2];
        //update height of the text
        // genresText.rectTransform.sizeDelta = new Vector2(genresText.rectTransform.sizeDelta.x, genresText.preferredHeight);

        StartCoroutine(CrackWatchHandler.GetGame(game, (crackGame) =>
        {
            if (crackGame == null)
            {
                Debug.Log("Game not found on CrackWatch");
                crackwatchText.text = "No crackwatch data found.";
                return;
            }

            crackwatchText.text = crackGame.Serialize();
        }));

        StartCoroutine(HowLongToBeatHandler.GetAll(game.name, (json) =>
        {
            Debug.Log(json);
        },
        (error) =>
        {
            howlongtobeatText.text = "No howlongtobeat data found.";
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

        if (game.screenshots != null && game.screenshots.Length > 0)
        {
            foreach (IGDB_Image screenshot in game.screenshots)
            {
                GameObject screenshotObject = Instantiate(screenshotPrefab, gallery.transform);
                screenshotObject.GetComponent<Screenshot>().Init(screenshot);
            }
        }
        else
        {
            gallery.SetActive(false);
        }

        Canvas.ForceUpdateCanvases();
        // tooltTipText.transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;
        // tooltTipText.transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true;
    }
}