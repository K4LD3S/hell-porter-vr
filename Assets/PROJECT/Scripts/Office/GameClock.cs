using System;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    public float nightRealSeconds = 480f;   // 8 min reals = 1 nit
    public float startHour = 0f;            // 00:00
    public float endHour = 6f;              // 06:00

    public float CurrentHour { get; private set; }
    public event Action<int> OnHourChanged;
    public event Action OnNightEnd;

    float t;
    int lastHour = -1;
    bool ended;

    void Start() { CurrentHour = startHour; }

    void Update()
    {
        if (ended) return;

        t += Time.deltaTime;
        float p = Mathf.Clamp01(t / nightRealSeconds);
        CurrentHour = Mathf.Lerp(startHour, endHour, p);

        int h = (int)CurrentHour;
        if (h != lastHour)
        {
            lastHour = h;
            OnHourChanged?.Invoke(h);
        }

        if (p >= 1f)
        {
            ended = true;
            OnNightEnd?.Invoke();
        }
    }
}