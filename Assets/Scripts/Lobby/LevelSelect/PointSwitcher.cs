using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lobby.LevelSelect
{
    public class PointSwitcher : MonoBehaviour
    {
        public List<FieldPoint> points;
        public List<FieldPoint> ActivePoint;

        private float tickTime;
        private float stepTickTime = 0.5f;

        private bool isSet;
        
        public void Activate(bool value)
        {
            ActivePoint = new List<FieldPoint>();
            isSet = value;
            tickTime = stepTickTime;
        }
        
        private void Update()
        {
            if (!isSet)
                return;
            
            tickTime += Time.deltaTime;

            if (tickTime >= stepTickTime)
            {
                points.ForEach(p => p.Activate(IsPointVisible(p.transform.position)));
                SetFillPoints();
                tickTime = 0;
            }
        }

        public bool IsPointVisible(Vector3 transformPosition)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transformPosition);

            return screenPoint.x > 0 && screenPoint.x < Screen.width &&
                   screenPoint.y > 0 && screenPoint.y < Screen.height;
        }

        public void SetFillPoints()
        {
            //ActivePoint.Clear();
            ActivePoint = points.Where(p => p.IsActive).ToList();
        }
    }
}