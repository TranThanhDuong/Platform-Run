using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoader : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
        ConfigManager.instances.InitConfig(() =>
        {
            DataAPIControler.instances.OnInit(InitDataDone);
        });
    }

    private void InitDataDone()
    {
        //FB_Authentication.instance.InitFB();
        LoadingManager.instances.LoadSceneByIndex(1, () =>
        {
            ViewManager.instances.OnSwitchView(ViewIndex.HomeView);
        });
    }
}
