using UnityEngine;
using DG.Tweening;

public class Navigate : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject navbar;

    void Start()
    {
        CloseSettings();
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
}
