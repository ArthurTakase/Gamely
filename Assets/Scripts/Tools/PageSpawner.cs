using UnityEngine;
using System.Collections.Generic;

public class PageSpawner : MonoBehaviour
{
    public GameObject gamePosterPrefab;

    public GameObject SpawnGamePosters(IGDB_Game game, Transform parent)
    {
        GameObject gamePoster = Instantiate(gamePosterPrefab, transform);
        gamePoster.transform.SetParent(parent);
        gamePoster.transform.localScale = Vector3.one;
        gamePoster.transform.localPosition = Vector3.zero;
        gamePoster.GetComponent<GamePoster>().SetGame(game);

        return gamePoster;
    }
}