using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkylinePresenter : MonoBehaviour
{
    [SerializeField] GameObject _canvas;

    public void Present(List<PointOfChange> skyline)
    {
        var index = 0;
        var lastPoint = new PointOfChange
        {
            X = -10,
            Y = 0
        };
        skyline.Add(new PointOfChange
        {
            X = 1000,
            Y = 0
        });
        const float lineWidth = 5f;
        foreach (var point in skyline)
        {
            var horizontalLine = new GameObject(string.Format("Horizontal Line {0}", index)).AddComponent<Image>();
            horizontalLine.transform.SetParent(_canvas.transform, false);
            horizontalLine.color = Color.black;
            var rect = horizontalLine.rectTransform;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.zero;
            rect.pivot = Vector2.zero;
            rect.anchoredPosition = new Vector2(lastPoint.X - lineWidth / 2, lastPoint.Y - lineWidth / 2);
            rect.sizeDelta = new Vector3(point.X - lastPoint.X + lineWidth, lineWidth);
            
            var verticalLine = new GameObject(string.Format("Vertical Line {0}", index)).AddComponent<Image>();
            verticalLine.transform.SetParent(_canvas.transform, false);
            verticalLine.color = Color.black;
            rect = verticalLine.rectTransform;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.zero;
            rect.pivot = Vector2.zero;

            var initialY = point.Y > lastPoint.Y ? lastPoint.Y : point.Y; 
            rect.anchoredPosition = new Vector2(point.X - lineWidth / 2, initialY - lineWidth / 2);
            rect.sizeDelta = new Vector3(lineWidth, Math.Abs(point.Y - lastPoint.Y) + lineWidth);

            lastPoint = point;
            index++;
        }
    }
}