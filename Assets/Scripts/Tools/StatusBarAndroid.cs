using UnityEngine;

public class StatusBarAndroid : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.FullScreenWindow, Screen.currentResolution.refreshRateRatio);
        Application.targetFrameRate = 120;
        Screen.fullScreen = false;
    }
}
