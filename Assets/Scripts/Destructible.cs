using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int maxHP = 100;
    private int currentHP;

    public List<Sprite> injureSpriteList;
    private SpriteRenderer spriteRenderer;

    private GameObject boomPerfab;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        boomPerfab = Resources.Load<GameObject>("Boom1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHP -= (int)(collision.relativeVelocity.magnitude * 6);
        if (currentHP <= 0)
        {
            Dead();
        }
        else
        {
            int index = (int)((maxHP - currentHP) / (maxHP / (injureSpriteList.Count + 1.0f))) - 1;
            if (index != -1)
            {
                spriteRenderer.sprite = injureSpriteList[index];
            }
            
        }
    }
    public virtual void Dead()
    {
        GameObject.Instantiate(boomPerfab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
