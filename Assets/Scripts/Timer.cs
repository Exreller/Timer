using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timerValue;
    private Coroutine _coroutine;
    private float _delay = 0.5f;

    public event Action<float> ValueChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwitchTimer();
        }
    }

    private void SwitchTimer()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(CountDown());
        }
        else if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator CountDown()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            yield return wait;

            _timerValue++;
            ValueChanged?.Invoke(_timerValue);
        }
    }
}
