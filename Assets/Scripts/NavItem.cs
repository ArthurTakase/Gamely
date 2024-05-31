using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class NavItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image icon;
    [SerializeField] private GameObject iconBackground;
    private bool isSelected = false;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color unselectedColor;
    private float iconBackgroundWidth;
    private Navbar navbar;

    private void Start()
    {
        navbar = GetComponentInParent<Navbar>();
        iconBackgroundWidth = iconBackground.transform.localScale.x;
    }

    public void Activate()
    {
        navbar.DeactivateAll();
        isSelected = true;
        iconBackground.SetActive(true);
        AnimateIconBackground();
        title.color = selectedColor;
        icon.color = selectedColor;
        title.fontStyle = FontStyles.Bold;
    }

    public void Deactivate()
    {
        isSelected = false;
        iconBackground.SetActive(false);
        title.color = unselectedColor;
        icon.color = unselectedColor;
        title.fontStyle = FontStyles.Normal;
    }

    public void Toggle()
    {
        if (isSelected) Deactivate();
        else Activate();
    }

    public void AnimateIconBackground()
    {
        // use dotween to animate the icon background. the width go from 0 to the width of the icon
        iconBackground.transform.localScale = new Vector3(0, 1, 1);

        iconBackground.transform
            .DOScaleX(iconBackgroundWidth, 0.5f)
            .SetEase(Ease.OutBack);
    }
}
