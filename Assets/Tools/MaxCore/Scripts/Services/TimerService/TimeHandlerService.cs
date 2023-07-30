using System;
using UnityEngine;

namespace Tools.MaxCore.Scripts.Services.TimerService
{
    public class TimeHandlerService
    {
        public double TotalSecondUntilEndOfDay { get; set; }

        private string TempDataTime
        {
            get => PlayerPrefs.GetString("LastBonusDate", "01/01/1970");
            set => PlayerPrefs.SetString("LastBonusDate", value);
        }

        public bool IsUpdateDay;
        public event Action OnUpdateDay;

        public void Init()
        {
            TotalSecondUntilEndOfDay = (DateTime.Today.AddDays(1) - DateTime.Now).TotalSeconds;
        
            var currentDate = DateTime.Today /*+ new TimeSpan(1,0,0,0)*/;
            var lastBonusDate = DateTime.Parse(TempDataTime);

            if (currentDate != lastBonusDate)
                NotifyUpdateDay(currentDate);
        }

        private void NotifyUpdateDay(DateTime currentDate)
        {
            TempDataTime = currentDate.ToString();
            IsUpdateDay = true;
        
            OnUpdateDay?.Invoke();
        }
    }
}