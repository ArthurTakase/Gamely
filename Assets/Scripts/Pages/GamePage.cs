using UnityEngine;

public class GamePage : MonoBehaviour
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
                navigate.CloseGamePage();
                navigate.ShowNavbar();
            }
    }
}