using UnityEngine;
using TMPro;

public class AdaptiveFPS : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    [System.Obsolete]
    void Start()
    {
        // Cihazýn ekran yenileme hýzýný öðren
        int refreshRate = Screen.currentResolution.refreshRate;

        // FPS hedefini ekran yenileme hýzýna ayarla
        Application.targetFrameRate = refreshRate;
        QualitySettings.vSyncCount = 0; // VSync kapalý

        if (infoText != null)
        {
            infoText.text = $"Target FPS: {refreshRate}\n" +
                            $"Device Refresh Rate: {refreshRate}Hz";
        }
    }
}
