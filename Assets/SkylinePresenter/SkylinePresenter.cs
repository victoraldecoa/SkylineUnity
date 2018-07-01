using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SkylineBuilder
{
    public class SkylinePresenter
    {
        private const float LineWidth = 5f;

        private readonly GameObject _canvas;
        private readonly IEnumerable<PointOfChange> _skyline;

        public SkylinePresenter(IEnumerable<PointOfChange> skyline, GameObject canvas)
        {
            _canvas = canvas;
            _skyline = skyline;
        }

        public void Present()
        {
            var index = 0;
            var lastPoint = new PointOfChange
            {
                X = -10,
                Y = 0
            };
            
            foreach (var point in _skyline)
            {
                AddPoint(point, index, lastPoint);
                index++;
                lastPoint = point;
            }

            AddPoint(new PointOfChange
            {
                X = 1000,
                Y = 0
            }, index, lastPoint);
        }

        private void AddPoint(PointOfChange point, int index, PointOfChange lastPoint)
        {
            var horizontalLine = new GameObject(string.Format("Horizontal Line {0}", index)).AddComponent<Image>();
            horizontalLine.transform.SetParent(_canvas.transform, false);
            horizontalLine.color = Color.black;
            var rect = horizontalLine.rectTransform;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.zero;
            rect.pivot = Vector2.zero;
            rect.anchoredPosition = new Vector2(lastPoint.X - LineWidth / 2, lastPoint.Y - LineWidth / 2);
            rect.sizeDelta = new Vector3(point.X - lastPoint.X + LineWidth, LineWidth);

            var verticalLine = new GameObject(string.Format("Vertical Line {0}", index)).AddComponent<Image>();
            verticalLine.transform.SetParent(_canvas.transform, false);
            verticalLine.color = Color.black;
            rect = verticalLine.rectTransform;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.zero;
            rect.pivot = Vector2.zero;

            var initialY = point.Y > lastPoint.Y ? lastPoint.Y : point.Y;
            rect.anchoredPosition = new Vector2(point.X - LineWidth / 2, initialY - LineWidth / 2);
            rect.sizeDelta = new Vector3(LineWidth, Math.Abs(point.Y - lastPoint.Y) + LineWidth);
        }
    }
}