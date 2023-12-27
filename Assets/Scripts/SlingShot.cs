using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SlingShot : MonoBehaviour
{
    public static SlingShot instance {  get; private set; }

    private LineRenderer leftLineRender;
    private LineRenderer rightLineRender;

    private Transform leftPoint;
    private Transform rightPoint;
    private Transform centerPoint;

    private Transform birdstransform;
    private bool isdrawing = false;

    private void Awake()
    {
        instance = this;

        leftLineRender = transform.Find("LeftLineRender").GetComponent<LineRenderer>();
        rightLineRender = transform.Find("RightLineRender").GetComponent<LineRenderer>();

        leftPoint = transform.Find("LeftPoint");
        rightPoint = transform.Find("RightPoint");
        centerPoint = transform.Find("CenterPoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        HideLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(isdrawing)
        {
            Draw();
            
        }
    }
    public void StartDraw(Transform birdstransform)
    {
        isdrawing = true;   
        this.birdstransform = birdstransform;
        ShowLine();

    }
    public void EndDraw()
    {
        isdrawing = false;
        HideLine();
    }

    public void Draw()
    {
        Vector3 birdPosition = birdstransform.position;

        birdPosition = ((birdPosition - centerPoint.position).normalized * 0.32f) + birdPosition;

        leftLineRender.SetPosition(0, birdPosition);
        leftLineRender.SetPosition(1,leftPoint.position);
        
        rightLineRender.SetPosition(0, birdPosition);
        rightLineRender.SetPosition(1,rightPoint.position);
    }

    public Vector3 GetcenterPoint()
    {
        return centerPoint.position;
    }

    public void HideLine()
    {
        leftLineRender.enabled = false;
        rightLineRender.enabled = false;
    }
    public void ShowLine()
    {
        leftLineRender.enabled = true;
        rightLineRender.enabled = true;
    }
}
