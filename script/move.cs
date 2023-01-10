using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class move : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        
        int rangeNum = Random.Range(0, 10);
        print(rangeNum);
        transform.Translate(Vector3.up * Time.deltaTime * rangeNum);
        
    }
}
