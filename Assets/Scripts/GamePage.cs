using UnityEngine;

public class GamePage : MonoBehaviour
{
    public Navigate navigate;

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                navigate.CloseGamePage();
                navigate.ShowNavbar();
            }
    }
}