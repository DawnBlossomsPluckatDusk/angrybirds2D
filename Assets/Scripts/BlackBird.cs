using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class BlackBird : Birds
{

    public float boomRadius = 2.5f;
    protected override void FullTimeSkill()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, boomRadius);
        foreach (Collider2D collider in colliders)
        {
            Destructible des = collider.GetComponent<Destructible>();
            if (des != null)
            {
                des.TakeDamage(int.MaxValue);
            }
        }
        state = BirdState.WaitToDie;
        LoadNextBird();
    }
}
