using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TouchableObjType
{
    NONE,
    COINS,
    SILVER_KEY,
    GOLD_KEY,
    BRIGE,
    BLOOD,
    FOOD,
    STAR,
}

public class GameManager : Singleton<GameManager>
{
    public string POINTS_KEY = "POINTS";
    public string SILVERKEYS_KEY = "SILVERKEYS";
    public string GOLDKEYS_KEY = "GOLDKEYS";
    public string BLOOD_KEY = "BLOODS";
    public Transform spawnPos;

    public int missID = 0;
}
