using UnityEngine;
using DG.Tweening;

public class Navigate : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject navbar;
    public GameObject defaultPage;

    private GameObject currentPage;

    void Start()
    {
        currentPage = defaultPage;

        float width = settingsPanel.transform.GetComponent<RectTransform>().rect.width;
        settingsPanel.transform.localPosition = new Vector3(width, 0, 0);
        settingsPanel.SetActive(false);

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

    public void OpenPopUp(GameObject popup)
    {
        popup.SetActive(true);
        popup.transform
            .DOLocalMoveY(0, 0.3f)
            .SetEase(Ease.OutQuad);
    }

    public void ClosePopUp(GameObject popup)
    {
        float height = popup.transform.GetComponent<RectTransform>().rect.height;
        popup.transform
            .DOLocalMoveY(-height, 0.3f)
            .SetEase(Ease.InQuad)
            .OnComplete(() => popup.SetActive(false));
    }
}
