using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    [SerializeField] BuildingsPresenter _buildingsPresenter;
    [SerializeField] SkylinePresenter _skylinePresenter;

    void Awake()
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
        _buildingsPresenter.Present(buildings);

        var builder = new SkylineBuilder();
        _skylinePresenter.Present(builder.Build(buildings));
    }
}