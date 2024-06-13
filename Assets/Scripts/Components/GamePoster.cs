using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePoster : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI title;
    [HideInInspector] public string id;
    private Button button;
    private IGDB_Game game;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            FindObjectOfType<Navigate>().HideNavbar();
            FindObjectOfType<PageSpawner>().SpawnGamePage(game);
        });
    }

    public void SetGame(IGDB_Game game)
    {
        this.game = game;
        title.text = game.name;
        id = game.id.ToString();
        StartCoroutine(DownloadPicture.Download(game.cover.GetURL(), (sprite) =>
        {
            image.sprite = sprite;
            image.color = Color.white;
        }));
    }
}