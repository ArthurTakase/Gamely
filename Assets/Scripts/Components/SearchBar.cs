using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : MonoBehaviour
{
    public TMP_InputField inputField;
    public Sprite searchIcon;
    public Sprite crossIcon;
    public Image icon;

    public void OnSelect()
    {
        inputField.Select();
    }

    public void OnValueChanged(string value)
    {
        if (value.Length > 0) icon.sprite = crossIcon;
        else icon.sprite = searchIcon;
    }

    public void Clear()
    {
        if (inputField.text.Length == 0) return;
        inputField.text = "";
        icon.sprite = searchIcon;
        FindObjectOfType<Search>().RemoveSearchResults();
    }
}