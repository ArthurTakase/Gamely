using UnityEngine;
using DG.Tweening;

public class Navigate : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject navbar;
    public GameObject defaultPage;
    public GameObject gamePage;

    private GameObject currentPage;

    void Start()
    {
        currentPage = defaultPage;

        // move settings panel to the right
        float width = settingsPanel.transform.GetComponent<RectTransform>().rect.width;
        settingsPanel.transform.localPosition = new Vector3(width, 0, 0);
        settingsPanel.SetActive(false);

        // move game page to the right
        width = gamePage.transform.GetComponent<RectTransform>().rect.width;
        gamePage.transform.localPosition = new Vector3(width, 0, 0);
        gamePage.SetActive(false);

        ShowNavbar();
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        settingsPanel.transform
            .DOLocalMoveX(0, 0.3f)
            .SetEase(Ease.OutQuad);
    }

    public void CloseSettings()
    {
        float width = settingsPanel.transform.GetComponent<RectTransform>().rect.width;
        settingsPanel.transform
            .DOLocalMoveX(width, 0.3f)
            .SetEase(Ease.InQuad)
            .OnComplete(() => settingsPanel.SetActive(false));
    }

    public void OpenGamePage()
    {
        gamePage.SetActive(true);
        gamePage.transform
            .DOLocalMoveX(0, 0.3f)
            .SetEase(Ease.OutQuad);
    }

    public void CloseGamePage()
    {
        float width = gamePage.transform.GetComponent<RectTransform>().rect.width;
        gamePage.transform
            .DOLocalMoveX(width, 0.3f)
            .SetEase(Ease.InQuad)
            .OnComplete(() => gamePage.SetActive(false));
    }

    public void ShowNavbar()
    {
        navbar.transform
            .DOLocalMoveY(0, 0.3f)
            .SetEase(Ease.OutQuad);
    }

    public void HideNavbar()
    {
        float height = navbar.transform.GetComponent<RectTransform>().rect.height;
        navbar.transform
            .DOLocalMoveY(-height, 0.3f)
            .SetEase(Ease.InQuad);
    }

    public void ShowPage(GameObject page)
    {
        currentPage.SetActive(false);
        currentPage = page;
        currentPage.SetActive(true);
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
