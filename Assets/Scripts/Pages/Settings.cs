using UnityEngine;

public class Settings : MonoBehaviour
{
    public Navigate navigate;

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                navigate.CloseSettings();
                navigate.ShowNavbar();
            }
    }
}