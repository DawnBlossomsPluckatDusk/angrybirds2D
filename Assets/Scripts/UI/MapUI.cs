using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public GameObject lockUI;
    public GameObject starUI;
    public TextMeshProUGUI starCountTextUI;
    
    private SelectUI selectUI;
    private int mapID;
    public void show(int starCount,SelectUI selectUI,int mapID)
    {
        this.selectUI = selectUI;
        this.mapID = mapID;
        if (starCount < 0)
        {
            GetComponent<Button>().enabled = false;
            lockUI.SetActive(true);
            lockUI.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            starUI.SetActive(false);
        }
        else
        {

            lockUI.SetActive(false);
            starUI.SetActive(true);
            starCountTextUI.text = starCount.ToString();
        }
    }

    public void Onclick()
    {
        selectUI.OnMapButtonClick(mapID);
    }
}
