using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    
    public int m_HP;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject ui_congrats;

    void BeShot(int damage)
    {
        m_HP -= damage;
        if (m_HP == 0)
        {
            Destroy(gameObject);
            
            ui_congrats.SetActive(true);



           

        }
    }

   
}
