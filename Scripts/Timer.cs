using UnityEngine;

public class Timer
{
    private float _executionTime;
    private float _delay;
    private bool _looping;
    private bool _stopTheCount;
    private System.Action _action;

    public float ExecutionTime => _executionTime;
    public float Delay => _delay;
    public bool Looping =>_looping;
    public bool StopTheCount => _stopTheCount;
    public System.Action Action => _action;

    public Timer(float delay, System.Action action, bool looping = false)
    {
        _executionTime = Time.time + delay;

        _action = action;
        _looping = looping;
        _delay = delay;

        if (looping)
            _action += () =>
            {
                _executionTime = Time.time + _delay;
            };
    }

    public void ResetTime()
    {
        _executionTime = Time.time + _delay;
    }

    /// <summary>
    /// Reset the time and start the count again
    /// </summary>
    public void RestartTimer()
    {
        ResetTime();
        TimerManager.timerManager.AddTimer(this);
    }

}