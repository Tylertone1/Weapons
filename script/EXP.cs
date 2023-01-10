using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    public int Myexp = 1;
    public static EXP _instance;

    private void Awake()
    {
        _instance = this;
    }

}