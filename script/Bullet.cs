using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.Runtime.InteropServices;

public class Bullet : MonoBehaviour
{
    public int bullet_damage = 15;
    public Bullet data;
    public GameObject win;


    






    private void OnTriggerEnter2D(Collider2D collision)
    {   

        
        collision.SendMessage("BeShot", bullet_damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        win = GameObject.FindWithTag("Respawn");

        
        winover();




    }

    public void winover()
    {
        var asshole = win;
        
        if(asshole != null)
        {
            bullet_damage += 100;
        }
    }
    
}
