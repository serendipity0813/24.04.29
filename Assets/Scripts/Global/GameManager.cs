using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int[,] Numbers = new int[4, 4];
    public event EventHandler Click;

    private void Awake()
    {
        if(Instance == null)
        Instance = this;
    }

    private void Start()
    {
        for(int i=0; i<4; i++)
        {
            for(int j=0; j<4; j++)
            {
                Numbers[i, j] = 1;
            }
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    private void OnClick()
    {
        Debug.Log("click");
    }
}
