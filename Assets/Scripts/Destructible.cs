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
        TakeDamage((int)(collision.relativeVelocity.magnitude * 6));
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Dead();
        }
        else
        {
            Sprite beforeSprite = spriteRenderer.sprite;
            int index = (int)((maxHP - currentHP) / (maxHP / (injureSpriteList.Count + 1.0f))) - 1;
            if (index != -1)
            {
                spriteRenderer.sprite = injureSpriteList[index];
            }
            if (beforeSprite != spriteRenderer.sprite)
            {
                PlayAudioCollision();
            }

        }
    }

    protected virtual void PlayAudioCollision()
    {
        AudioManager.instance.PlayWoodCollision(transform.position);
    }
    protected virtual void PlayAudioDestroyed()
    {
        AudioManager.instance.PlayWoodDestoryed(transform.position);
    }
    public virtual void Dead()
    {
        PlayAudioDestroyed();
        GameObject.Instantiate(boomPerfab,transform.position,Quaternion.identity);
        Destroy(gameObject);
        
    }
}
