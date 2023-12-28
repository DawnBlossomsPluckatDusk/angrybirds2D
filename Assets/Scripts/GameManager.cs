using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Birds[] birdList;
    private int index = -1;

    private int pigTotalCount;
    private int pigDeadCount;

    private FollowTarget cameraFollowTarget;


    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        birdList = FindObjectsByType<Birds>(FindObjectsSortMode.None);
        pigTotalCount = FindObjectsByType<Pig>(FindObjectsSortMode.None).Length;
        cameraFollowTarget = Camera.main.GetComponent<FollowTarget>();
        LoadNextBird();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextBird()
    {
        index++;
        if (index >= birdList.Length)
        {
            GameEnd();
        }
        else
        {
            birdList[index].GoStage(SlingShot.instance.GetcenterPoint());
            cameraFollowTarget.setTarget(birdList[index].transform);
        }
        
    }

    public void OnPigDead()
    {
        pigDeadCount++;

        if(pigDeadCount >= pigTotalCount)
        {
            GameEnd();
        }
    }
    private void GameEnd()
    {

    }


}
