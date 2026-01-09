using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [Header("Testing")]
    public bool  showActiveTimers;

    private List<Timer> _timers = new List<Timer>();
    public List<Timer> Timers { get { return _timers; } }

    private static TimerManager _timerManager;
    public static TimerManager timerManager
    {
        get
        {
            if (_timerManager == null)
            {
                _timerManager = new GameObject("TimerManager").AddComponent<TimerManager>();
                DontDestroyOnLoad(_timerManager.gameObject);
            }
            return _timerManager;
        }
    }

    //::MONO_BEHAVIOUR::MONO_BEHAVIOUR::MONO_BEHAVIOUR::MONO_BEHAVIOUR::MONO_BEHAVIOUR::MONO_BEHAVIOUR::MONO_BEHAVIOUR

    private void Update()
    {
        if (showActiveTimers && _timerManager.Timers.Count > 0) Debug.Log("There are: " + _timerManager.Timers.Count + " Timer/s");

        for (int i = 0; i < _timers.Count; i++)
        {
            if (_timers[i].StopTheCount) //Stop and remove the timer if it is necessary without execute its action
            {
                _timers.RemoveAt(i);
            }

            else if (_timers[i].ExecutionTime < Time.time) //If the time is finished: execute the action and remove the timer of the list if looping is false
            {
                _timers[i].Action?.Invoke();
                if (_timers[i].Looping == false)
                {
                    _timers.RemoveAt(i);
                }
            }
        }
    }

    public void AddTimer(float delay, System.Action action, bool looping = false)
    {
        _timerManager._timers.Add(new Timer(delay, action, looping));

    }
    public void AddTimer(Timer timer)
    {
        _timerManager._timers.Add(timer);
       
    }
}
