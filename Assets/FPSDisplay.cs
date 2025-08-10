using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI statsText;
    private float deltaTime;

    void Start()
    {
        // FPS LÝMÝT ARTTIRMA
        //Application.targetFrameRate = 60; // Hedef 60 FPS
        //QualitySettings.vSyncCount = 0;   // VSync kapalý
    }

    void Update()
    {
        // FPS hesaplama
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        float ms = deltaTime * 1000.0f;

        // Sahnedeki obje sayýsý
        int objectCount = FindObjectsOfType<GameObject>().Length;

        // Hafýza kullanýmý (MB)
        long totalMemory = Profiler.GetTotalAllocatedMemoryLong() / (1024 * 1024);
        long reservedMemory = Profiler.GetTotalReservedMemoryLong() / (1024 * 1024);
        long unusedReservedMemory = reservedMemory - totalMemory;

        long gpuMemory = Profiler.GetAllocatedMemoryForGraphicsDriver() / (1024 * 1024);

        // Ekrana yaz
        statsText.text = Mathf.Ceil(fps).ToString();
    }
}
