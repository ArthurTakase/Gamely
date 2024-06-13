using UnityEngine;

public class PageSpawner : MonoBehaviour
{
    public GameObject defaultPageParent;
    public GameObject gamePosterPrefab;
    public GameObject gamePagePrefab;

    public GameObject SpawnGamePosters(IGDB_Game game, Transform parent)
    {
        GameObject gamePoster = Instantiate(gamePosterPrefab, transform);
        gamePoster.transform.SetParent(parent);
        gamePoster.transform.localScale = Vector3.one;
        gamePoster.transform.localPosition = Vector3.zero;
        gamePoster.GetComponent<GamePoster>().SetGame(game);

        return gamePoster;
    }

    public GameObject SpawnGamePage(IGDB_Game game)
    {
        GameObject gamePage = Instantiate(gamePagePrefab, defaultPageParent.transform);
        gamePage.transform.SetParent(defaultPageParent.transform);
        gamePage.transform.localScale = Vector3.one;
        gamePage.transform.localPosition = Vector3.zero;
        gamePage.GetComponent<GamePage>().SetGame(game);

        return gamePage;
    }
}