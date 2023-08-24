using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class DataAPIControler : Singleton<DataAPIControler>
{
    [SerializeField]
    private DataBaseLocal model;
    // Start is called before the first frame update
    private Dictionary<string, MissionData> missions;
    public void OnInit(Action callback)
    {
        if (model.LoadData())
        {
            callback?.Invoke();
        }
        else
        {
            PlayerData playerData = new PlayerData();
            playerData.currentMission = 0;
            Dictionary<string, MissionData> missionCollection_ = new Dictionary<string, MissionData>();
            playerData.missionCollection = missionCollection_;
            model.CreateNewData(playerData);
            callback?.Invoke();

        }
        // setting get data 
        missions = model.Read<Dictionary<string, MissionData>>(DataPath.PLAYER_MISSION);
        DataTrigger.RegisterValueChange(DataPath.PLAYER_MISSION, (data) =>
        {
            missions = (Dictionary<string, MissionData>)data;
        });

    }
    public Dictionary<string, MissionData> GetMissionData()
    {
        return model.Read<Dictionary<string, MissionData>>(DataPath.PLAYER_MISSION);
    }

    public MissionData GetMissionDataByID(int id)
    {
        MissionData item = model.Read<MissionData>(DataPath.PLAYER_MISSION, id);
        return item;
    }
    public int GetCurrentMission()
    {
        return model.Read<int>(DataPath.PLAYER_CURRENT_MISSION) + 1;
    }
    public void ChangeCurrentMission(int id, Action callBack)
    {
        model.UpdateData(DataPath.PLAYER_CURRENT_MISSION, id, callBack);
    }
    public void ChangeMissionData(int id, int mission_1, int mission_2, Action<bool> callBack)
    {
        MissionData mission = GetMissionDataByID(id);

        if (mission == null)
            mission = new MissionData();

       

        mission.id = id;
        if(mission_1 > mission.mission_1)
            mission.mission_1 = mission_1;
        if (mission_2 > mission.mission_2)
            mission.mission_2 = mission_2;

        model.UpdateData<MissionData>(DataPath.PLAYER_MISSION, id, mission, () =>
        {
            callBack?.Invoke(true);
        });

        int currentMiss = GetCurrentMission();
        if (id >= currentMiss)
            ChangeCurrentMission(id++, () => { });
    }
}