using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI statsText;
    private float deltaTime;

    void Start()
    {
        // FPS L�M�T ARTTIRMA
        //Application.targetFrameRate = 60; // Hedef 60 FPS
        //QualitySettings.vSyncCount = 0;   // VSync kapal�
    }

    void Update()
    {
        // FPS hesaplama
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        float ms = deltaTime * 1000.0f;

        // Sahnedeki obje say�s�
        int objectCount = FindObjectsOfType<GameObject>().Length;

        // Haf�za kullan�m� (MB)
        long totalMemory = Profiler.GetTotalAllocatedMemoryLong() / (1024 * 1024);
        long reservedMemory = Profiler.GetTotalReservedMemoryLong() / (1024 * 1024);
        long unusedReservedMemory = reservedMemory - totalMemory;

        long gpuMemory = Profiler.GetAllocatedMemoryForGraphicsDriver() / (1024 * 1024);

        // Ekrana yaz
        statsText.text = Mathf.Ceil(fps).ToString();
    }
}
