using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show()
    {
        animator.SetBool("IsShow", true);
    } 
}
