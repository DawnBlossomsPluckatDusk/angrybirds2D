using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnpauseButtonClick()
    {
        Time.timeScale = 0;
        animator.SetBool("IsShow", true);
    }
    public void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        animator.SetBool("IsShow", false);
    }
    public void OnLevelListButtonClick()
    {
        GameManager.Instance.LevelList();
    }
    public void OnRestartButtonClick()
    {
        GameManager.Instance.RestartLevel();
    }
}
