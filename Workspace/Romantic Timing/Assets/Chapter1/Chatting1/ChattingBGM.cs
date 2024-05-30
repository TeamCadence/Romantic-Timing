using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChattingBGM : MonoBehaviour
{
    private static ChattingBGM Instance;

    void Awake()
    {
        if(Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
