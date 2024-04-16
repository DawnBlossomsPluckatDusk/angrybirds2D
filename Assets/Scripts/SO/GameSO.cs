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

            //�ж��Ƿ������һ���Ҵ�����һ����ͼ
            if(selectLevelID >= mapArray[selectedMapID - 1].starnumberOfLevel.Length && selectedMapID < mapArray.Length-1)
            {
                //�ж���һ����ͼ�Ƿ���
                if (mapArray[selectedMapID].starnumberOfMap == -1)
                {
                    mapArray[selectedMapID].starnumberOfMap = 0;
                    mapArray[selectedMapID].starnumberOfLevel[0] = 0;
                }
            }
            //�ж��Ƿ������һ��
            if(selectLevelID < mapArray[selectedMapID - 1].starnumberOfLevel.Length)
            {
                //�ж���һ�ؿ��Ƿ����
                if (mapArray[selectedMapID - 1].starnumberOfLevel[selectLevelID] == -1)
                {
                    mapArray[selectedMapID - 1].starnumberOfLevel[selectLevelID]= 0;
                }
            }
        }
    }
}
