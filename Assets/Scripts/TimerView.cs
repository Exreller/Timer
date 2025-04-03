using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.ValueChanged += DisplayCountDown;
    }

    private void OnDisable()
    {
        _timer.ValueChanged -= DisplayCountDown;
    }

    private void DisplayCountDown(float count)
    {
        _text.text = count.ToString("");
    }
}
