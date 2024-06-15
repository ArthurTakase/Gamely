using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    private IGDB_Image screenshot;
    public Image screenshotImage;

    public void Init(IGDB_Image screenshotObject)
    {
        screenshot = screenshotObject;
        LoadScreenshot();
    }

    private void LoadScreenshot()
    {
        StartCoroutine(DownloadPicture.Download(screenshot.GetURL(), (sprite) =>
        {
            screenshotImage.sprite = sprite;
        },
        (errortxt) =>
        {
            screenshotImage.sprite = null;
            screenshotImage.color = Color.black;
        }));
    }
}