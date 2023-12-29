using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Destructible
{
    public int score = 3000;
    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.OnPigDead();
        ScoreManager.instance.ShowScore(transform.position,score);
    }
    protected override void PlayAudioCollision()
    {
        AudioManager.instance.PlayPigCollision(transform.position);
    }
    protected override void PlayAudioDestroyed()
    {
        
    }
}
