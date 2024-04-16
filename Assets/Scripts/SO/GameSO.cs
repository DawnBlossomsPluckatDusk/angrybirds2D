using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameSO : ScriptableObject
{
    public MapSO[] mapArray;
    public int selectedMapID = -1;
    public int selectLevelID = -1;

    public void UpdateLevel(int number)
    {
        if (number <= 0)
        {
            return;
        }
        else if(number > mapArray[selectedMapID-1].starnumberOfLevel[selectLevelID-1])
        {
            mapArray[selectedMapID-1].starnumberOfMap += number - mapArray[selectedMapID-1].starnumberOfLevel[selectLevelID-1];
            mapArray[selectedMapID-1].starnumberOfLevel[selectLevelID-1] = number;

            //判断是否是最后一关且存在下一个地图
            if(selectLevelID >= mapArray[selectedMapID - 1].starnumberOfLevel.Length && selectedMapID < mapArray.Length-1)
            {
                //判断下一个地图是否开启
                if (mapArray[selectedMapID].starnumberOfMap == -1)
                {
                    mapArray[selectedMapID].starnumberOfMap = 0;
                    mapArray[selectedMapID].starnumberOfLevel[0] = 0;
                }
            }
            //判断是否是最后一关
            if(selectLevelID < mapArray[selectedMapID - 1].starnumberOfLevel.Length)
            {
                //判读下一关卡是否解锁
                if (mapArray[selectedMapID - 1].starnumberOfLevel[selectLevelID] == -1)
                {
                    mapArray[selectedMapID - 1].starnumberOfLevel[selectLevelID]= 0;
                }
            }
        }
    }
}
