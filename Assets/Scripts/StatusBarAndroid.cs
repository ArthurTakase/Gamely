using UnityEngine;

public class StatusBarAndroid : MonoBehaviour
{
    private AndroidJavaObject _activity;
    private AndroidJavaObject _plugin;

    [System.Obsolete]
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.FullScreenWindow, Screen.currentResolution.refreshRateRatio);
        Application.targetFrameRate = 120;

        if (Application.platform == RuntimePlatform.Android)
        {
            using (AndroidJavaClass unityPlayer = new("com.unity3d.player.UnityPlayer"))
                _activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            using AndroidJavaClass pluginClass = new("com.yourcompany.unityplugin.UnityAndroidPlugin");
            _plugin = pluginClass.CallStatic<AndroidJavaObject>("init", _activity);
        }
    }

    public void ShowSystemUI()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _plugin.Call("showSystemUI");
        }
    }
}
