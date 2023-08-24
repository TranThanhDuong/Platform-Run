using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class ConfigMissionRecord
{
    //id	waveid	sceneid	rewardid
    public int id;
    public int sceneid;
    public int mission_type_1;
    public TouchableObjType mission_item_1;
    public int mission_need_num_1;
    public int mission_type_2;
    public TouchableObjType mission_item_2;
    public int mission_need_num_2;
}
public class ConfigMission : BYDataTable<ConfigMissionRecord>
{
    public override void SetCompareObject()
    {
        base.SetCompareObject();
        recoreCompare = new ConfigCompareKey<ConfigMissionRecord>("id");
    }
    public List<ConfigMissionRecord> GetAllRecords()
    {
        return records;
    }

    public string GetMissionTypeName(int type_id)
    {
        switch(type_id)
        {
            case 1:
                {
                    return "Reach Score:";
                }
            case 2:
                {
                    return "Collect:";
                }
            default:
                {
                    return "";
                }
        }
    }
    public string GetMissionItemName(TouchableObjType item_id)
    {
        if (item_id == TouchableObjType.NONE)
            return "";
        else
        {
            return (item_id).ToString();
        }
    }
}

