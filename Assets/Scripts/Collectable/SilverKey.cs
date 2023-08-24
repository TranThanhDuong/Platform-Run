using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverKey : TouchableObj
{
    public ParticleSystem particle;
    public override void SetUp(TouchableParam param)
    {
        player = param.player;
    }

    public override void OnTouchObj()
    {
        if (particle)
            particle.Play();

        player.OnCollectSilverKeys();
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(DistroyThis());
    }
    public override IEnumerator DistroyThis()
    {
        yield return new WaitForSeconds(0.4f);

        if (particle)
            particle.Pause();
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
    }
}
