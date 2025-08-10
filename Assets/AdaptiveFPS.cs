using UnityEngine;
using TMPro;

public class AdaptiveFPS : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    [System.Obsolete]
    void Start()
    {
        // Cihaz�n ekran yenileme h�z�n� ��ren
        int refreshRate = Screen.currentResolution.refreshRate;

        // FPS hedefini ekran yenileme h�z�na ayarla
        Application.targetFrameRate = refreshRate;
        QualitySettings.vSyncCount = 0; // VSync kapal�

        if (infoText != null)
        {
            infoText.text = $"Target FPS: {refreshRate}\n" +
                            $"Device Refresh Rate: {refreshRate}Hz";
        }
    }
}
