using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData 
{
    [SerializeField]
    public int currentMission;
    [SerializeField]
    public Dictionary<string, MissionData> missionCollection = new Dictionary<string, MissionData>();
}

[Serializable]
public class MissionData
{
    public int id;
    public int mission_1;
    public int mission_2;
}


public static class DataUtilities
{
    public static string ToKey(this object data)
    {
        return "K_" + data.ToString();
    }
}