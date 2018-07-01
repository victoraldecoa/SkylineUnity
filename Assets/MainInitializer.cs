using System.Collections.Generic;
using SkylineBuilder;
using SkylineUtilities;
using UnityEngine;

public class MainInitializer : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private void Awake()
    {
        var buildings = new List<Building>
        {
            new Building
            {
                Start = 100,
                End = 200,
                Height = 200
            },
            new Building
            {
                Start = 300,
                End = 400,
                Height = 100
            },
            new Building
            {
                Start = 350,
                End = 450,
                Height = 60
            },
            new Building
            {
                Start = 280,
                End = 540,
                Height = 40
            },
            new Building
            {
                Start = 430,
                End = 520,
                Height = 300
            }
        };
        
        var builder = new SkylineBuilder.SkylineBuilder(new LinqBuildingsOrderedByHeight {Buildings = new List<Building>()});
        var pointOfChanges = builder.Build(buildings);
        
        var buildingsPresenter = new BuildingsPresenter();
        buildingsPresenter.Present(buildings, _canvas);

        var skylinePresenter = new SkylinePresenter(pointOfChanges, _canvas);
        skylinePresenter.Present();
    }
}