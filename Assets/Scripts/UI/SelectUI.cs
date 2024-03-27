using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mapListGo;
    public GameObject LevelListGo;

    public List<MapUI> mapUIList;
    public GameObject levelTemplatePrefab;
    public GameObject levelGridGo;

    public void ShowMapList(MapSO[] mapArray)
    {
        mapListGo.SetActive(true);
        LevelListGo.SetActive(false);
        UpdateMapUIList(mapArray);
    }
    private void UpdateMapUIList(MapSO[] mapArray)
    {
        for (int i = 0; i < mapArray.Length; i++)
        {
            mapUIList[i].show(mapArray[i].starnumberOfMap,this,i+1);
        }
    }
    public void OnMapButtonClick(int mapID)
    {
        LevelSelectManager.instance.SetSelectedMap(mapID);
        ShowLevelGrid();
    }

    private void ShowLevelGrid()
    {
        mapListGo.SetActive(false);
        LevelListGo.SetActive(true);

        int[] starNumberOfLevel = LevelSelectManager.instance.GetSelectedMap();
        foreach (Transform child in levelGridGo.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < starNumberOfLevel.Length; i++)
        {
            GameObject go = GameObject.Instantiate(levelTemplatePrefab);
            go.GetComponent<RectTransform>().SetParent(levelGridGo.transform);

            go.GetComponent<LevelUI>().Show(starNumberOfLevel[i],i+1,this);
        }
    }
    public void OnLevelButtonClick(int levelID)
    {
        LevelSelectManager.instance.SetSelectedLevel(levelID);
    }
    public void OnReturnButtonClick()
    {
        mapListGo.SetActive(true);
        LevelListGo.SetActive(false);
    }
}
