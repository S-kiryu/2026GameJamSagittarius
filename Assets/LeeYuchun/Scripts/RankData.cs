using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Rank
{
    public string name;
    public float time;

    public Rank(string name, float time)
    {
        this.name = name;
        this.time = time;
    }
}


[System.Serializable]
public class RankData
{
    public List<Rank> ranks = new List<Rank>();
}