using System;

namespace SmartHomeSecurity
{
    // Delegate definition
    public delegate void SecurityAction(string zone);

    public class MotionSensor
    {
        public SecurityAction OnEmergency;

        public void DetectIntruder(string zoneName)
        {
            Console.WriteLine($"[SENSOR] Motion detected in {zoneName}!");

            OnEmergency?.Invoke(zoneName);
        }
    }

    public class AlarmSystem
    {
        public void SoundSiren(string zone)
        {
            Console.WriteLine($"[ALARM] WOO-OOO! High-decibel siren active in {zone}.");
        }
    }

    public class PoliceNotifier
    {
        public void CallDispatch(string zone)
        {
            Console.WriteLine($"[POLICE] Notifying local precinct of intrusion in {zone}.");
        }
    }
}
