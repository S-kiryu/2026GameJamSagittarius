using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Rank
{
    public string name;
    public float time;

    public string themeName;

    public Rank(string name, float time, string themeName)
    {
        this.name = name;
        this.time = time;
        this.themeName = themeName;
    }
}


[System.Serializable]
public class RankData
{
    public List<Rank> ranks = new List<Rank>();
}