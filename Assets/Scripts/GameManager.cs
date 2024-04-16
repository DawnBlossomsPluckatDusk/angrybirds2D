using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Birds[] birdList;
    private int index = -1;
    private int starCount = 0;
    private int pigTotalCount;
    private int pigDeadCount;

    private FollowTarget cameraFollowTarget;

    public GameOverUI gameOverUI;

    public GameSO gameSO;

    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
        LoadSelectedLevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        birdList = FindObjectsByType<Birds>(FindObjectsSortMode.None);
        pigTotalCount = FindObjectsByType<Pig>(FindObjectsSortMode.None).Length;
        cameraFollowTarget = Camera.main.GetComponent<FollowTarget>();
        LoadNextBird();

    }

    private void LoadSelectedLevel()
    {
        int mapID = gameSO.selectedMapID;
        int levelID = gameSO.selectLevelID;
        Time.timeScale = 1;
        GameObject levelPrefab = Resources.Load<GameObject>("Map" + mapID + "/" + "Level" + levelID);
        GameObject.Instantiate(levelPrefab);

    }

    public void LoadNextBird()
    {
        index++;
        if (index >= birdList.Length)
        {
            GameOver();
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
            GameOver();
        }
    }
    private void GameOver()
    {
        starCount = 0;
        float pigDeadPercent = pigDeadCount * 1f / pigTotalCount;
        if (pigDeadCount == pigTotalCount)
        {
            starCount = 3;
        }
        else if(pigDeadPercent > 0.66f)
        {
            starCount = 2;
        }
        else if(pigDeadPercent > 0.33f)
        {
            starCount = 1;
        }
        else
        {
            starCount = 0;
        }

        gameSO.UpdateLevel(starCount);
        gameOverUI.Show(starCount);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelList()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void NextLevel()
    {
        gameSO.selectLevelID = gameSO.selectLevelID + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
