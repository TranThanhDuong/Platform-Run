using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogIndex
{

    PauseDialog = 1,
    CreateGameDialog,
    TextDialog,
}
public class DialogConfig
{
    public static DialogIndex[] dialogIndexs = {
        DialogIndex.PauseDialog,
        DialogIndex.CreateGameDialog,
        DialogIndex.TextDialog
};
}
public class DialogParam
{

}
public class TextDialogParam : DialogParam
{
    public string text;
}
public class DialogCreateGameParam : DialogParam
{
    public bool isFinish = false;
    public int totalDone;
    public int missID;
}
