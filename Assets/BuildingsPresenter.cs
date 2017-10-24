using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsPresenter : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    
    public void Present(List<Building> buildings)
    {
        var index = 0;
        foreach (var building in buildings)
        {
            var image = new GameObject(string.Format("Building {0}", index)).AddComponent<Image>();
            var hue = (float)index / buildings.Count;
            var color = Color.HSVToRGB(hue, 1f, 1f);
            color.a = 0.4f;
            image.color = color;
            image.transform.SetParent(_canvas.transform, false);
            var rect = image.rectTransform;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.zero;
            rect.pivot = Vector2.zero;
            rect.anchoredPosition = new Vector2(building.Start, 0);
            rect.sizeDelta = new Vector3(building.End - building.Start, building.Height);
            index++;
        }
    }
}
