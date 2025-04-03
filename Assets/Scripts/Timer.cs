using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timerValue;
    private Coroutine _coroutine;
    private float _delay = 0.5f;
    private bool _isRuning = false;

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
            _isRuning = true;
        }
        else if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            _isRuning = false;
        }
    }

    private IEnumerator CountDown()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isRuning)
        {
            yield return wait;

            _timerValue++;
            ValueChanged?.Invoke(_timerValue);
        }
    }
}
