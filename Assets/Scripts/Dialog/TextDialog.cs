using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDialog : BaseDialog
{
    public TextMeshProUGUI text;
    public override void OnSetup(DialogParam param)
    {
        base.OnSetup(param);
        text.SetText (((TextDialogParam)param).text);
    }

    public void OnClose()
    {
        DialogManager.instances.HideDialog(this.index);
    }
}
