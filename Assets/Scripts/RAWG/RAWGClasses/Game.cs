[System.Serializable]
public struct Plateform
{
    public string platform;
    public string released_at;
    public string requirements;
}

[System.Serializable]
public class Game
{
    public string id;
    public string slug;
    public string name;
    public string released;
    public bool tba;
    public string background_image;
    public float rating;
    public float rating_top;
    public string ratings_count;
    public string reviews_text_count;
    public string added;
    public string metacritic;
    public string playtime;
    public string suggestions_count;
    public string updated;
    public string esrb_rating;
    public Plateform[] platforms;


    //     "id": 0,
    //     "slug": "string",
    //     "name": "string",
    //     "released": "2024-06-11",
    //     "tba": true,
    //     "background_image": "http://example.com",
    //     "rating": 0,
    //     "rating_top": 0,
    //     "ratings": { },
    //     "ratings_count": 0,
    //     "reviews_text_count": "string",
    //     "added": 0,
    //     "added_by_status": { },
    //     "metacritic": 0,
    //     "playtime": 0,
    //     "suggestions_count": 0,
    //     "updated": "2024-06-11T12:42:01Z",
    //     "esrb_rating": 

    // {

    //     "id": 0,
    //     "slug": "everyone",
    //     "name": "Everyone"

    // },
    // "platforms": 
    // [

    // {

    //     "platform": 

    // {},
    // "released_at": "string",
    // "requirements": 
    //         }
    //     ]

}