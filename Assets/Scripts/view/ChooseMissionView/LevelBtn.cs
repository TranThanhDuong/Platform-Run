using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelBtnParam
{
    public int levelID;
    public bool isFinish;
    public bool isCur;
    public int numDone;
}

public class LevelBtn : MonoBehaviour
{
    public GameObject lockBtn;
    public GameObject haveDoneBtn;
    public GameObject AvatarIcon;
    public GameObject curBG;
    public GameObject[] collectionStart;
    public TextMeshProUGUI levelID;
    private int missionID = 0;
    private int numDone = 0;
    public void SetUp(LevelBtnParam param)
    {
        for (int i = 0; i < collectionStart.Length; i++)
            collectionStart[i].SetActive(false);
        levelID.text = param.levelID.ToString();
        missionID = param.levelID;
        numDone = param.numDone;
        if (!param.isFinish && !param.isCur)
        {
            lockBtn.SetActive(true);
            haveDoneBtn.SetActive(false);
            curBG.SetActive(false);
            AvatarIcon.SetActive(false);
        }
        else
        {
            if(param.isCur)
            {
                lockBtn.SetActive(false);
                haveDoneBtn.SetActive(true);
                curBG.SetActive(true);
                AvatarIcon.SetActive(true);
            }    
            else
            {
                lockBtn.SetActive(false);
                haveDoneBtn.SetActive(true);
                curBG.SetActive(false);
                AvatarIcon.SetActive(false);
            }
            if (param.numDone > 0)
                collectionStart[0].SetActive(true);

            if (param.numDone > 1)
                collectionStart[1].SetActive(true);

            if (param.numDone > 2)
                collectionStart[2].SetActive(true);
        }
    }
    
    public void OnClickLevel()
    {
        //Open Dialog here
        DialogCreateGameParam param = new DialogCreateGameParam();
        param.missID = missionID;
        param.totalDone = numDone;
        DialogManager.instances.ShowDialog(DialogIndex.CreateGameDialog, param);
    }
}
