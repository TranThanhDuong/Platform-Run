using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerDataBiding dataBiding;
    public Rigidbody2D rigidbodyPlayer;
    public InputManager input;
    public float speedMove=1;
    public float jumpForce = 10;
    private int totalBlood = 5;
    private bool isTakingDamage = false;
    [SerializeField]
    private bool isAlive = true;
    [SerializeField]
    private bool isGround_;
    private bool IsGround
    {
        set
        {
            dataBiding.IsGround = value;
            isGround_ = value;
        }
        get
        {
            return isGround_;
        }
    }
    [SerializeField]
    private bool isLadder = false;
    public bool IsLadder
    {
        set
        {
            isLadder = value;
            dataBiding.IsLadder = value;
        }
        get
        {
            return isLadder;
        }
    }
    public Transform anchorFoot;
    public Transform anchorFoot_1;
    public Transform anchorFoot_Front;
    public LayerMask maskGround;
    public LayerMask maskGroundLimit;
    public LayerMask maskLadder;
    private float velocity = 0;
    public float a_Horizontal = 2f;
    private float velocity_up = 0;

    private Transform trans;
    private float timeDelay = 0;
    private Vector2 posHit;
    private Transform transCurrentLadder;
    //x = x0 + v0 *t + a *t *t / 2

    private int stars = 0;
    private int coins = 0;
    private int totalPoint = 0;
    private int silverKeys = 0;
    private int goldKeys = 0;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        totalBlood = 5;
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float y = trans.position.y;
        float x = trans.position.x;


        if (y < -3)
        {
            trans.position = GameManager.instances.spawnPos.position;
            dataBiding.Speed = 0;
            velocity_up = 0;
            velocity = 0;
            x = trans.position.x;
            y = trans.position.y;
            OnTakeDamage(1, true);
        }

        dataBiding.Speed = input.moveDir.x;//Input.GetAxisRaw("Horizontal");

        timeDelay += Time.deltaTime;
 
        CheckGround();

        if (input.moveDir.y > 0 && IsGround && !this.IsLadder)//Input.GetKeyDown(KeyCode.Space)
        {
            velocity_up = jumpForce;
            IsGround = false;
            timeDelay = 0;
        }
        if (input.moveDir.y < 0 && IsGround)//Input.GetKeyDown(KeyCode.C)
        {
            OnFallDown();
        }
        float input_x = input.moveDir.x;//Input.GetAxisRaw("Horizontal");

        if (!IsGround)
        {
            dataBiding.JumpForce = velocity_up;

            float t = Time.deltaTime;
            y = trans.position.y + velocity_up * t - 9.8f * t * t / 2f;
            velocity_up = velocity_up - 9.8f * t;

            if (input_x == 0)
            {
                velocity = velocity - dataBiding.Speed * a_Horizontal * Time.deltaTime;

            }
            else
            {
                velocity = input_x * speedMove * Time.deltaTime;//Input.GetAxisRaw("Horizontal")
            }

        }
        else
        {

            velocity = input_x * speedMove * Time.deltaTime;//Input.GetAxisRaw("Horizontal")
            y = posHit.y;
            velocity_up = 0;

        }

        // ----------- ladder code 
        float yLadder = input.moveDir.y;//Input.GetAxisRaw("Vertical")
        if (Mathf.Abs(yLadder)>0||!IsGround)
        {
            this.IsLadder = CheckLadder(yLadder);
        }
        else if(IsGround)
        {
            this.IsLadder = false;
        }

       
        if (this.IsLadder)
        {

            y = trans.position.y + yLadder * Time.deltaTime * 2f;

            velocity_up = 0;


            if (Mathf.Abs(yLadder) > 0)
            {
                velocity = 0;
                x = transCurrentLadder.position.x;
                dataBiding.SpeedLadder = Mathf.Abs(yLadder);
            }
            else if (!IsGround)
            {
                velocity = 0;
                x = transCurrentLadder.position.x;
                dataBiding.SpeedLadder = 0.2f;
            }
            else if (IsGround)
            {
                dataBiding.SpeedLadder = 0;
            }


        }
        else
        {
            dataBiding.SpeedLadder = 0;
        }

        //------------ end    

        RaycastHit2D hitInfo = Physics2D.Linecast(anchorFoot.position, anchorFoot_Front.position, maskGroundLimit);
        if (hitInfo.collider == null)
            x += velocity;
        trans.position =new Vector2(x ,y);

    }
    private void OnFallDown()
    {
        RaycastHit2D hitInfo = Physics2D.Linecast(anchorFoot.position, anchorFoot_1.position, maskGroundLimit);

        if (hitInfo.collider == null)
        {
            timeDelay = 0.15f;
            IsGround = false;
            velocity_up = -jumpForce / 4f;
        }
       
    }
    private void CheckGround()
    {

        if (timeDelay > 0.3f&&velocity_up<=0)
        {
            Vector2 dir = transform.position - anchorFoot.position;
            dir.Normalize();
            Debug.DrawRay(anchorFoot.position, dir);
            RaycastHit2D hitInfo = Physics2D.Linecast(anchorFoot.position, anchorFoot_1.position, maskGround);

            if (hitInfo.collider != null)
            {
                if (hitInfo.transform.gameObject.layer == 15 && hitInfo.transform.gameObject.tag != "BreakableBrige")
                {
                    IsGround = false;
                    posHit = trans.position;
                    return;
                }

                IsGround = true;
                posHit = hitInfo.point;
            }
            else
            {
                IsGround = false;
                posHit = trans.position;
            }
        }

    }
    private void CheckGround_2()
    {

        if(timeDelay>0.3f)
        {
            Vector2 dir = transform.position - anchorFoot.position;
            dir.Normalize();
            Debug.DrawRay(anchorFoot.position, dir);
            RaycastHit2D hitInfo = Physics2D.Linecast(anchorFoot.position, anchorFoot_1.position, maskGround);
           
            if (hitInfo.collider != null)
            {
                IsGround = true;
                posHit = hitInfo.point;
            }
            else
            {
                IsGround = false;
                posHit = trans.position;
            }
        }

    }
    private bool CheckLadder(float y_Input=0)
    {
        Vector2 dir = Vector2.zero;
        if(y_Input>0)
        {
            dir = Vector2.up;
        }
        else
        {
            dir = Vector2.down;
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(anchorFoot.position, dir, 0.5f, maskLadder);
        if (hitInfo.collider != null)
        {
            transCurrentLadder = hitInfo.transform;
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            OnTakeDamage(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.layer==12)
        //{
        //    collision.GetComponent<EnemyControl>().OnHitPlayer();
        //}

        if (collision.gameObject.layer == 10 && velocity_up > 0)
        {
            velocity_up = 0;
        }
       
        if (collision.gameObject.layer == 15)
        {
            TouchableParam param = new TouchableParam();
            param.player = this;
            collision.GetComponent<TouchableObj>().SetUp(param);
            collision.GetComponent<TouchableObj>().OnTouchObj();
        }

        if(collision.gameObject.layer == 16)
        {
            DialogCreateGameParam param = new DialogCreateGameParam();
            param.missID = GameManager.instances.missID;
            param.isFinish = true;
            param.totalDone = 1;

            ConfigMissionRecord record = ConfigManager.instances.configMission.GetRecordByKeySearch(GameManager.instances.missID);
            int miss_1 = GetPlayerMissionVal(record.mission_type_1, record.mission_item_1);
            int miss_2 = GetPlayerMissionVal(record.mission_type_2, record.mission_item_2);

            if (miss_1 >= record.mission_need_num_1)
                param.totalDone++;
            if (miss_2 >= record.mission_need_num_2)
                param.totalDone++;

            DataAPIControler.instances.ChangeMissionData(param.missID, miss_1, miss_2, (isOk) => { });
            DialogManager.instances.ShowDialog(DialogIndex.PauseDialog, param);
        }    
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ladder"))
    //    {
    //        this.IsLadder = false;
    //    }
    //}


    public void OnAddBlood(TouchableObjType type)
    {
        switch(type)
        {
            case TouchableObjType.BLOOD:
                totalBlood++;
                break;
            case TouchableObjType.FOOD:
                totalBlood += 2;
                break;
            default:
                break;
        }
        if (totalBlood > 5)
            totalBlood = 5;

        totalBlood.TriggerEventData(GameManager.instances.BLOOD_KEY);
    }

    private IEnumerator TakingDamage()
    {
        yield return new WaitForSeconds(3);
        isTakingDamage = false;
        //dataBiding.IsTakingDamage = isTakingDamage;
    }    

    public void OnTakeDamage(int damage, bool forcetotake=false)
    {
        if (!isAlive)
        {
            totalBlood = 0;
            return;
        }

        if (isTakingDamage && !forcetotake)
            return;

        totalBlood -= damage;
        if(totalBlood <= 0)
        {
            isAlive = false;
            DialogCreateGameParam param = new DialogCreateGameParam();
            param.missID = GameManager.instances.missID;
            param.totalDone = 0;

            ConfigMissionRecord record = ConfigManager.instances.configMission.GetRecordByKeySearch(GameManager.instances.missID);
            int miss_1 = GetPlayerMissionVal(record.mission_type_1, record.mission_item_1);
            int miss_2 = GetPlayerMissionVal(record.mission_type_2, record.mission_item_2);
            DialogManager.instances.ShowDialog(DialogIndex.PauseDialog, param);
        }
        totalBlood.TriggerEventData(GameManager.instances.BLOOD_KEY);
        isTakingDamage = true;
        dataBiding.IsTakingDamage = isTakingDamage;
        StartCoroutine(TakingDamage());
    }

    public void OnCollectCoins()
    {
        totalPoint += 1;
        coins++;
        totalPoint.TriggerEventData(GameManager.instances.POINTS_KEY);
    }

    public void OnCollectStar()
    {
        totalPoint += 5;
        stars++;
        totalPoint.TriggerEventData(GameManager.instances.POINTS_KEY);
    }

    public void OnCollectSilverKeys()
    {
        silverKeys++;
        silverKeys.TriggerEventData(GameManager.instances.SILVERKEYS_KEY);
    }

    public void OnCollectGoldKeys()
    {
        goldKeys++;
        goldKeys.TriggerEventData(GameManager.instances.GOLDKEYS_KEY);
    }

    public bool OnUseGoldKeys()
    {
        if (goldKeys > 0)
        {
            goldKeys--;
            goldKeys.TriggerEventData(GameManager.instances.GOLDKEYS_KEY);
            return true;
        }
        return false;
    }

    public bool OnUseSilverKeys()
    {
        if (silverKeys > 0)
        {
            silverKeys--;
            silverKeys.TriggerEventData(GameManager.instances.SILVERKEYS_KEY);
            return true;
        }
        return false;
    }

    public int GetPlayerMissionVal(int missionType, TouchableObjType itemID)
    {
        switch (missionType)
        {
            case 1:
                {
                    return totalPoint;
                }
            case 2:
                {
                    switch (itemID)
                    {
                        case TouchableObjType.COINS:
                            {
                                return coins;
                            }
                        case TouchableObjType.SILVER_KEY:
                            {
                                return silverKeys;
                            }
                        case TouchableObjType.GOLD_KEY:
                            {
                                return goldKeys;
                            }
                        case TouchableObjType.STAR:
                            {
                                return stars;
                            }
                    }
                    break;
                }
        }
        return 0;
    }
}
