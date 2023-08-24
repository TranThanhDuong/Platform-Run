using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeView : BaseView
{
    public override void OnSetup(ViewParam param)
    {
        base.OnSetup(param);
    }

    public void OnStartGame()
    {
        ViewManager.instances.OnSwitchView(ViewIndex.ChooseMissionView);
    }

    public void OnLeaveGame()
    {
        Application.Quit();
    }
    public void OnRate()
    {

    }

    public void OnShare()
    {

    }
}
