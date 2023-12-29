using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BirdState
{
    Waiting,
    BeforeShot,
    AfterShot,
    WaitToDie
}

public class Birds : MonoBehaviour
{
    public BirdState state = BirdState.BeforeShot;
    public float flySpeed = 8.0f;

    private bool isMouseDown = false;

    private float maxDistance = 2.05f;

    private bool isFlying = true;
    private bool usedSkill = false;

    protected Rigidbody2D rgd;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        rgd.bodyType = RigidbodyType2D.Static;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                WaitControl();
                break;
            case BirdState.BeforeShot:
                MoveControl();
                break;
            case BirdState.AfterShot:
                StopControl();
                SkillControl();
                break;
            case BirdState.WaitToDie:
                break;
            default:
                break;
        }

    }

    private void WaitControl()
    {

    }
    private void OnMouseDown()
    {
        if(state == BirdState.BeforeShot)
        {
            isMouseDown = true;
            SlingShot.instance.StartDraw(transform);
            AudioManager.instance.PlayBirdSelect(transform.position);
        }
    }
    private void OnMouseUp()
    {
        if(state == BirdState.BeforeShot)
        {
            isMouseDown = false;
            SlingShot.instance.EndDraw();
            fly();
        }
        
    }

    private void MoveControl()
    {
        if (isMouseDown)
        {
            transform.position = GetMousePosition();
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mp =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 centerPosition = SlingShot.instance.GetcenterPoint();
        mp.z = 0;

        Vector3 mouseDir = mp - centerPosition;

        float  distance = (mouseDir).magnitude;
        if (distance > maxDistance)
        {
            mp = (mouseDir).normalized * maxDistance + centerPosition;
        }

        return mp;
    }
    private void fly()
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;
        rgd.velocity = (SlingShot.instance.GetcenterPoint() - transform.position).normalized * flySpeed;
        state = BirdState.AfterShot;
        AudioManager.instance.PlayBirdFlying(transform.position);
    }

    public void GoStage(Vector3 position)
    {
        state = BirdState.BeforeShot;
        transform.position = position;
    }
    private void StopControl()
    {
        if (rgd.velocity.magnitude < 0.1f)
        {
            state = BirdState.WaitToDie;
            Invoke("LoadNextBird", 1f);
            
        }
    }
    private void SkillControl()
    {
        if (usedSkill == true) return;

        if(isFlying == true && Input.GetMouseButtonDown(0))
        {
            usedSkill = true;
            FlyingSkill();
        }
        if(Input.GetMouseButtonDown(0))
        {
            usedSkill = true;
            FullTimeSkill();
        }
    }
    protected virtual void FlyingSkill()
    {

    }
    protected virtual void FullTimeSkill()
    {

    }
    private void LoadNextBird()
    {
        Destroy(gameObject);
        GameObject.Instantiate(Resources.Load("Boom1"), transform.position, Quaternion.identity);
        GameManager.Instance.LoadNextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(state == BirdState.AfterShot)
        {
            isFlying = false;
        }
        if(state == BirdState.AfterShot && collision.relativeVelocity.magnitude > 5)
        {
            AudioManager.instance.PlayBirdCollision(transform.position);
        }
    }

}
