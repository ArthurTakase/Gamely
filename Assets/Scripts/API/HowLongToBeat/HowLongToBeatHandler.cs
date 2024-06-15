using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class HowLongToBeatHandler : MonoBehaviour
{
    public static IEnumerator GetAll(string name, System.Action<string> callback, System.Action<string> errorCallback)
    {
        // post request on https://howlongtobeat.com/api/search
        string url = "https://howlongtobeat.com/api/search";
        string jsonBody = $"{{\"searchType\":\"games\",\"searchTerms\":[\"{name}\"],\"searchPage\":1,\"size\":20,\"searchOptions\":{{\"games\":{{\"userId\":0,\"platform\":\"\",\"sortCategory\":\"popular\",\"rangeCategory\":\"main\",\"rangeTime\":{{\"min\":0,\"max\":0}},\"gameplay\":{{\"perspective\":\"\",\"flow\":\"\",\"genre\":\"\"}},\"modifier\":\"\"}},\"users\":{{\"sortCategory\":\"postcount\"}},\"filter\":\"\",\"sort\":0,\"randomizer\":0}}";

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        // request.SetRequestHeader("Referer", "https://howlongtobeat.com/");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            errorCallback(request.error);
        }
        else
        {
            callback(request.downloadHandler.text);
        }
    }
}