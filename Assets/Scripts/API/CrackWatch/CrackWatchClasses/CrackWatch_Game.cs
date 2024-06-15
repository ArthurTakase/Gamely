[System.Serializable]
public class CrackWatch_Game
{
    public string id;
    public string slug;
    public string title;
    public bool is_AAA;
    public string protections;
    public string hacked_groups;
    public string release_date;
    public string crack_date;
    public string short_image;
    public string full_image;
    public string teaser_link;
    public string torrent_link;
    public string mata_score;
    public string user_score;
    public string readable_status;
    public bool is_offline_act;
    public string steam_media_id;
    public string steam_prod_id;

    public string Serialize()
    {
        string hacked_groups = this.hacked_groups.Replace("[", "").Replace("]", "").Replace("\"", "");

        if (hacked_groups == "") return readable_status;
        return $"<b>{title}</b> {readable_status} ({hacked_groups})";
    }
}