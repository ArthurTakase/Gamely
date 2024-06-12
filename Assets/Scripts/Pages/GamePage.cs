using UnityEngine;

public class GamePage : MonoBehaviour
{
    private Navigate navigate;

    public void Start()
    {
        navigate = FindObjectOfType<Navigate>();
    }

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