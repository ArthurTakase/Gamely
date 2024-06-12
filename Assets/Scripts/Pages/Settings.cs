using UnityEngine;

public class Settings : MonoBehaviour
{
    private Navigate navigate;
    public bool enableBackButton = true;

    public void Start()
    {
        navigate = FindObjectOfType<Navigate>();
    }

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKeyDown(KeyCode.Escape) && enableBackButton)
            {
                navigate.CloseSettings();
                navigate.ShowNavbar();
            }
    }
}