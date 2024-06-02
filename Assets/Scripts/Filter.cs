using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    public FiltersManager filtersManager;
    public bool isSelected;
    private Outline outline;
    private TextMeshProUGUI text;

    public void Init(FiltersManager filtersManager)
    {
        this.filtersManager = filtersManager;
        outline = GetComponent<Outline>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Enable()
    {
        isSelected = true;

        outline.effectColor = filtersManager.selectedColor;
        text.color = filtersManager.selectedColor;
        // text.fontStyle = FontStyles.Bold;
    }

    public void Disable()
    {
        isSelected = false;

        outline.effectColor = filtersManager.deselectedColor;
        text.color = filtersManager.deselectedColor;
        // text.fontStyle = FontStyles.Normal;
    }

    public void OnClick()
    {
        filtersManager.DisableAllFilters();
        Enable();
    }
}