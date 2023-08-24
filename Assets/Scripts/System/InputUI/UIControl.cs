using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    public Image[] blood;
    public Sprite blood_red;
    public Sprite blood_gray;

    public RuntimeAnimatorController normal_blood_animation;
    public RuntimeAnimatorController cur_blood_animation;

    public TextMeshProUGUI pointText;

    private PlayerControl control;

    private string blood_red_text = "red";
    private string blood_gray_text = "grey";
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < blood.Length; i++)
        {
            blood[i].name = blood_red_text;
            blood[i].sprite = blood_red;
        }
        pointText.text = "0";
        DataTrigger.RegisterValueChange(GameManager.instances.BLOOD_KEY, ChangeBloodUI);
        DataTrigger.RegisterValueChange(GameManager.instances.POINTS_KEY, ChangePoint);
        control = gameObject.GetComponentInParent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeBloodUI(object data)
    {
        int curBlood = (int)data - 1;

        if (curBlood < 0)
        {
            if (!blood[0].name.Contains(blood_gray_text))
            {
                blood[0].name = blood_gray_text;
                blood[0].sprite = blood_gray;
            }
            return;
        }    

        for (int i = 0; i < 5; i++)
        {
            if (i <= curBlood)
            {
                if (!blood[i].name.Contains(blood_red_text))
                {
                    blood[i].name = blood_red_text;
                    blood[i].sprite = blood_red;
                }

                if (i == curBlood)
                {
                    blood[i].gameObject.GetComponentInParent<Animator>().runtimeAnimatorController = cur_blood_animation;
                }
                else
                    blood[i].gameObject.GetComponentInParent<Animator>().runtimeAnimatorController = normal_blood_animation;
            }
            else
            {
                if (!blood[i].name.Contains(blood_gray_text))
                {
                    blood[i].name = blood_gray_text;
                    blood[i].sprite = blood_gray;
                    blood[i].gameObject.GetComponentInParent<Animator>().runtimeAnimatorController = normal_blood_animation;
                }
            }    
        }    
    }
    void ChangePoint(object data)
    {
        pointText.text = data.ToString();
    }

    public void OnPauseGame()
    {
        DialogCreateGameParam param = new DialogCreateGameParam();
        param.missID = GameManager.instances.missID;
        DialogManager.instances.ShowDialog(DialogIndex.PauseDialog, param);
    }
}
