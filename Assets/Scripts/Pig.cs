using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Destructible
{
    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.OnPigDead();
    }
}
