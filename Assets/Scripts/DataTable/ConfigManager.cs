using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager :Singleton<ConfigManager> 
{
    [HideInInspector]
    public ConfigMission configMission;
    // Start is called before the first frame update
    public void InitConfig(Action callback)
    {
        StartCoroutine(LoadConfig(callback));
    }
    IEnumerator LoadConfig(Action callback)
    {
        configMission = Resources.Load("DataTable/ConfigMission", typeof(ScriptableObject)) as ConfigMission;
        yield return new WaitUntil(() => configMission != null);
        callback?.Invoke();
    }
}
