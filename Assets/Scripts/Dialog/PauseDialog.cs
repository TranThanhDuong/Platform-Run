using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ricimi;
public class PauseDialog : BaseDialog
{
    public PlayPopup starCtrl;
    public GameObject btnRetry;
    public GameObject btnNext;
    public TextMeshProUGUI lbLevel;
    public TextMeshProUGUI lbMiss_1;
    public TextMeshProUGUI lbMiss_Need_1;
    public TextMeshProUGUI lbMiss_2;
    public TextMeshProUGUI lbMiss_Need_2;

    private int missionID;
    public override void OnSetup(DialogParam param)
    {
        base.OnSetup(param);
        
        DialogCreateGameParam create = (DialogCreateGameParam)param;
        starCtrl.SetAchievedStars(create.totalDone);
        if (create.isFinish)
        {
            btnRetry.SetActive(false);
            btnNext.SetActive(true);
        }
        else
        {
            btnRetry.SetActive(true);
            btnNext.SetActive(false);
        }
        missionID = create.missID;
        ConfigMission config = ConfigManager.instances.configMission;
        ConfigMissionRecord record = config.GetRecordByKeySearch(create.missID);

        lbLevel.text = "Level " + missionID;
        lbMiss_1.text = config.GetMissionTypeName(record.mission_type_1);
        lbMiss_2.text = config.GetMissionTypeName(record.mission_type_2);

        lbMiss_Need_1.text = record.mission_need_num_1 + " " + config.GetMissionItemName(record.mission_item_1);
        lbMiss_Need_2.text = record.mission_need_num_2 + " " + config.GetMissionItemName(record.mission_item_2);
    }

    public void OnQuitGame()
    {
        DialogManager.instances.HideDialog(this.index);
        LoadingManager.instances.LoadSceneByIndex(1, () =>
        {
            ViewManager.instances.OnSwitchView(ViewIndex.HomeView);
        });
    }

    public void OnRetryGame()
    {
        DialogManager.instances.HideDialog(this.index);
        LoadingManager.instances.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex, () =>
        {
            ViewManager.instances.OnSwitchView(ViewIndex.EmptyView);
            GameManager.instances.missID = missionID;
        });
    }    

    public void OnClose()
    {
        DialogManager.instances.HideDialog(this.index);
    }

    public void OnNextLevel()
    {
        ConfigMissionRecord record = ConfigManager.instances.configMission.GetRecordByKeySearch(missionID + 1);

        if(record == null)
        {
            DialogManager.instances.ShowDialog(DialogIndex.TextDialog, new TextDialogParam { text = "We're develop new level now, please wait thanks for the support!" });
            return;
        }
        DialogManager.instances.HideDialog(this.index);
        LoadingManager.instances.LoadSceneByIndex(record.sceneid, () =>
        {
            ViewManager.instances.OnSwitchView(ViewIndex.EmptyView);
            GameManager.instances.missID = record.id;
        });
    }

    public override void OnShowDialog()
    {
        base.OnShowDialog();
    }

    public override void OnHidewDialog()
    {
        base.OnHidewDialog();
    }
}
