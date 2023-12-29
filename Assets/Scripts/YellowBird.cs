using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Birds
{
    
    protected override void FlyingSkill()
    {
        rgd.velocity = rgd.velocity * 2;
    }
}
