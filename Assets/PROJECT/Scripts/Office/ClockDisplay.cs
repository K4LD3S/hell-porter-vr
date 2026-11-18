using UnityEngine;
using TMPro;

public class ClockDisplay : MonoBehaviour
{
    public GameClock clock;   // arrossega-hi l'objecte amb GameClock
    public TMP_Text label;    // arrossega-hi ClockText

    int lastStep = -1;

    void Update()
    {
        // Minuts totals de joc, arrodonits a blocs de 10
        int totalMinutes = (int)(clock.CurrentHour * 60f);
        int step = totalMinutes / 10;
        if (step == lastStep) return;      // no canvia res, no fem res
        lastStep = step;

        int hh = (step * 10) / 60;
        int mm = (step * 10) % 60;
        int h12 = (hh % 12 == 0) ? 12 : hh % 12;

        label.text = $"{h12}:{mm:00} AM";
    }
}