using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;
    private Coroutine timerCoroutine;

    // Timer başladığında tetiklenecek event
    public event System.Action<float> OnTimeUpdated;
    public event System.Action OnTimerFinished;

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            OnTimeUpdated?.Invoke(elapsedTime);
        }
    }

    // Dışarıdan başlatma
    public void StartTimer()
    {
        if (timerCoroutine == null)
        {
            isTimerRunning = true;
            timerCoroutine = StartCoroutine(TimerCoroutine());
        }
    }

    // Dışarıdan durdurma
    public void StopTimer()
    {
        isTimerRunning = false;
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    // Zamanlayıcıyı sıfırlama
    public void ResetTimer()
    {
        elapsedTime = 0f;
        OnTimeUpdated?.Invoke(elapsedTime);
    }

    // Timer Coroutine (başlatma, bitirme)
    private IEnumerator TimerCoroutine()
    {
        // Timer bir süre devam ettikten sonra
        yield return new WaitForSeconds(5f); // Örneğin, 5 saniye sürecek

        StopTimer(); // Zamanlayıcıyı durdur
        OnTimerFinished?.Invoke(); // Timer tamamlandığında event'i tetikle
    }
}
