using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private Animator animator;
    private Button button;

    private int starCount = 0;

    public GameObject NextLevelButton;

    public GameObject fail;
    public StarUI star1;
    public StarUI star2;
    public StarUI star3;
    public void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }

    public void Show(int starCount)
    {
        animator.SetTrigger("IsShow");
        this.starCount = starCount;
    }
    public void ShowStar()
    {
        if (starCount == 0)
        {
            fail.SetActive(true);
            NextLevelButton.SetActive(false);
        }
        if(starCount >= 1)
        {
            star1.Show();
        }
        if(starCount >= 2)
        {
            star2.Show();
        }
        if (starCount >= 3)
        {
            star3.Show();
        }

    }
    public void OnRestartButtonClip()
    {
        GameManager.Instance.RestartLevel();
    }
    public void OnLevelListButtonClip()
    {
        GameManager.Instance.LevelList();
    }
    public void OnNextLevelButtonClip()
    {
        GameManager.Instance.NextLevel();
    }
}
