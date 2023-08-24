using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
public class ChooseMissionView : BaseView
{
    public float startPosX;
    public float midPosX;
    public float endPosX;
    public int missionCount = 27;
    public double maxIndex = 0;
    public int moveDelta = 50;
    public int maxBtn = 10;
    public Text levelText;
    public LevelPage[] page;
    public Image leftBtn;
    public Image rightBtn;
    public int curMission;

    private int curIndex = 0;
    private int curPage = 1;

    public int OtherIndex
    {
        get
        {
            return curIndex == 0 ? 1 : 0;
        }
    }

    private void Start()
    {

    }

    public override void OnSetup(ViewParam param)
    {
        missionCount = ConfigManager.instances.configMission.GetAllRecords().Count;
        curMission = DataAPIControler.instances.GetCurrentMission();

        base.OnSetup(param);
        curIndex = 0;
        curPage = 1;
        maxIndex = Math.Ceiling((double)missionCount / 10);
        levelText.text = curPage + "/" + maxIndex;
        var trans = page[curIndex].gameObject.GetComponent<RectTransform>();

        int curNum = missionCount - ((curPage - 1) * maxBtn + 10);
        if (curNum > 0)
        {
            page[curIndex].SetUp((curPage - 1) * maxBtn, maxBtn, curMission);
        }
        else
        {
            page[curIndex].SetUp((curPage - 1) * maxBtn, missionCount - ((curPage - 1) * maxBtn), curMission);
        }
        trans.position = new Vector2(midPosX, trans.position.y);
        trans = page[OtherIndex].gameObject.GetComponent<RectTransform>();
        trans.position = new Vector2(startPosX, trans.position.y);
        leftBtn.color = new Color(1, 1, 1, 1);
        rightBtn.color = new Color(1, 1, 1, 1);
    }
    public void OnPreviousPage()
    {
        if (curPage == 1)
            return;

        var trans = page[curIndex].gameObject.GetComponent<RectTransform>();
        if (DOTween.IsTweening(trans))
            return;
        curPage--;
        levelText.text = curPage + "/" + maxIndex;

        int curNum = missionCount - ((curPage - 1)  * maxBtn + 10);
        if (curNum > 0)
        {
            page[OtherIndex].SetUp((curPage - 1) * maxBtn, maxBtn, curMission);
        }
        else
        {
            page[OtherIndex].SetUp((curPage - 1) * maxBtn, missionCount - ((curPage - 1) * maxBtn), curMission);
        }
        trans.DOMoveX(startPosX, Time.deltaTime * moveDelta);

        trans = page[OtherIndex].gameObject.GetComponent<RectTransform>();
        trans.position = new Vector2(endPosX, trans.position.y);
        trans.DOMoveX(midPosX, Time.deltaTime * moveDelta);
        curIndex = OtherIndex;
    }

    public void OnNextPage()
    {
        if (curPage >= maxIndex)
            return;

        var trans = page[curIndex].gameObject.GetComponent<RectTransform>();
        if (DOTween.IsTweening(trans))
            return;
        curPage++;

        levelText.text = curPage + "/" + maxIndex;

        trans.DOMoveX(endPosX, Time.deltaTime * moveDelta);

        trans = page[OtherIndex].gameObject.GetComponent<RectTransform>();

        int curNum = missionCount - ((curPage - 1) * maxBtn + 10);
        if (curNum > 0)
        {
            page[OtherIndex].SetUp((curPage - 1) * maxBtn, maxBtn, curMission);
        }
        else
        {
            page[OtherIndex].SetUp((curPage - 1) * maxBtn, missionCount - ((curPage - 1) * maxBtn), curMission);
        }
        trans.position = new Vector2(startPosX, trans.position.y);
        trans.DOMoveX(midPosX, Time.deltaTime * moveDelta);
        curIndex = OtherIndex;
    }

    public void OnBack()
    {
        ViewManager.instances.OnSwitchView(ViewIndex.HomeView);
    }    
}
