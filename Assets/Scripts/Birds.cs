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
    public BirdState BirdState = BirdState.BeforeShot;
    public float flySpeed = 8.0f;

    private bool isMouseDown = false;

    private float maxDistance = 2.05f;
    

    private Rigidbody2D rgd;

    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (BirdState)
        {
            case BirdState.Waiting:
                break;
            case BirdState.BeforeShot:
                MoveControl();
                break;
            case BirdState.AfterShot:
                StopControl();
                break;
            case BirdState.WaitToDie:
                break;
            default:
                break;
        }

    }

    private void OnMouseDown()
    {
        if(BirdState == BirdState.BeforeShot)
        {
            isMouseDown = true;
            SlingShot.instance.StartDraw(transform);

        }
    }
    private void OnMouseUp()
    {
        if(BirdState == BirdState.BeforeShot)
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
        BirdState = BirdState.AfterShot;
    }

    public void GoStage(Vector3 position)
    {
        BirdState = BirdState.BeforeShot;
        transform.position = position;
    }
    private void StopControl()
    {
        if (rgd.velocity.magnitude < 0.1f)
        {
            BirdState = BirdState.WaitToDie;
            Invoke("LoadNextBird", 1f);
            
        }
    }

    private void LoadNextBird()
    {
        Destroy(gameObject);
        GameObject.Instantiate(Resources.Load("Boom1"), transform.position, Quaternion.identity);
        GameManager.Instance.LoadNextBird();
    }

}
