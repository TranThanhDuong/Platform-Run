using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelPage : MonoBehaviour
{
    [SerializeField]
    private string levelBtnPath = "";
    private int maxElement = 10;
    [SerializeField]
    private LevelBtn[] levelBtns;

    public void Awake()
    {
        if (levelBtns.Length > 0)
            return;

        levelBtns = new LevelBtn[maxElement];
        for (int i = 0; i < maxElement; i++)
        {
            GameObject newBtn = Instantiate(Resources.Load(levelBtnPath, typeof(GameObject))) as GameObject;
            newBtn.transform.SetParent(this.gameObject.transform);
            levelBtns[i] = newBtn.GetComponent<LevelBtn>();
            LevelBtnParam param = new LevelBtnParam();
            levelBtns[i].SetUp(param);
        }
    }
    public void SetUp(int start, int num, int cur = -1)
    {
        for (int i = 0; i < maxElement; i++)
        {
            if(i + 1 > num)
            {
                levelBtns[i].gameObject.SetActive(false);
                continue;
            }    

            LevelBtnParam param = new LevelBtnParam();
            param.levelID = start + i + 1;
            MissionData data = DataAPIControler.instances.GetMissionDataByID(start + i + 1);
            ConfigMissionRecord config = ConfigManager.instances.configMission.GetRecordByKeySearch(start + i + 1);

            param.isFinish = data != null ? true : false;
            param.numDone = 0;

            if (param.isFinish)
            {
                param.numDone = 1;
                if (config.mission_need_num_1 <= data.mission_1)
                    param.numDone++;
                if (config.mission_need_num_2 <= data.mission_2)
                    param.numDone++;
            }
           
            if (cur == i + start + 1)
                param.isCur = true;
            else
                param.isCur = false;

            levelBtns[i].gameObject.SetActive(true);
            levelBtns[i].SetUp(param);
        }
    }
}
