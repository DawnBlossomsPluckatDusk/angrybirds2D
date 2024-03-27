using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager instance {  get; private set; }
    public GameSO gameSO;
    public SelectUI selectUI;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        selectUI.ShowMapList(gameSO.mapArray);
    }

    // Update is called once per frame
    public void SetSelectedMap(int mapID)
    {
        gameSO.selectedMapID = mapID;
    }
    public int[] GetSelectedMap()
    {
        return gameSO.mapArray[gameSO.selectedMapID - 1].starnumberOfLevel;
    }

    public void SetSelectedLevel(int levelID)
    {
        gameSO.selectLevelID = levelID;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
