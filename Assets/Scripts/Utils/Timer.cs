using System;
using UnityEngine;

namespace TimerController
{
    public static class Timer
    {
        public static float Run(float timer, float interval, Action actionTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = interval;
                actionTimer?.Invoke();
            }

            return timer;
        }
    }
}