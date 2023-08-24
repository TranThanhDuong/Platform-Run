using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ricimi;
public class CreateGameDialog : BaseDialog
{
    public PlayPopup starCtrl;
    public int mission_id;
    public TextMeshProUGUI lbLevel;
    public TextMeshProUGUI lbMiss_1;
    public TextMeshProUGUI lbMiss_Need_1;
    public TextMeshProUGUI lbMiss_2;
    public TextMeshProUGUI lbMiss_Need_2;
    public override void OnSetup(DialogParam param)
    {
        base.OnSetup(param);
        DialogCreateGameParam create = (DialogCreateGameParam)param;
        starCtrl.SetAchievedStars(create.totalDone);

        mission_id = create.missID;
        ConfigMission config = ConfigManager.instances.configMission;
        ConfigMissionRecord record = config.GetRecordByKeySearch(create.missID);

        lbLevel.text = "Level " + mission_id;
        lbMiss_1.text = config.GetMissionTypeName(record.mission_type_1);
        lbMiss_2.text = config.GetMissionTypeName(record.mission_type_2);
        lbMiss_Need_1.text = record.mission_need_num_1 + " " + config.GetMissionItemName(record.mission_item_1);
        lbMiss_Need_2.text = record.mission_need_num_2 + " " + config.GetMissionItemName(record.mission_item_2);
    }

    public void OnStartGame()
    {
        DialogManager.instances.HideDialog(this.index);
        ViewManager.instances.OnSwitchView(ViewIndex.EmptyView);
        LoadingManager.instances.LoadSceneByIndex(ConfigManager.instances.configMission.GetRecordByKeySearch(mission_id).sceneid, () =>
        {
            GameManager.instances.missID = mission_id;
        });
    }

    public void OnClose()
    {
        DialogManager.instances.HideDialog(this.index);
    }    
}
