using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

   Rigidbody2D m_enemy;
    CapsuleCollider2D m_colli;
    public int m_HP;
    public float speed = -10;
    public int MaxTurns = 3;
    private int turns = 0;
    public int m_damage = 5;
   
    public int exp;

    public LayerMask m_groundLayer;





    public GameObject checkwall;
    // Start is called before the first frame update

    void Awake()
    {
        
        m_enemy = GetComponent<Rigidbody2D>();
        m_colli = GetComponent<CapsuleCollider2D>();


    }


    void Start()
    {

        m_colli.isTrigger = false;
        Invoke("delayOpen", 0.5f);

    }

    // Update is called once per frame

    void delayOpen()
    {
        m_colli.isTrigger = true;

    }


    void Update()
    {




        transform.Translate(Vector3.left * Time.deltaTime * speed);








        if (turns >= MaxTurns)
        {

            Destroy(gameObject);
        }

        

    }

    public AudioClip EnemyAudio;


    public void BeShot(int damage)
    {
        m_HP -= damage;
        if (m_HP == 0)
        {
            
            
                Destroy(gameObject);
            AudioSource.PlayClipAtPoint(EnemyAudio, transform.position, 1);
            turns++;
            print("success");
            







        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("BeDamaged", m_damage, SendMessageOptions.DontRequireReceiver);
        }
        else if(other.gameObject.tag == "ground")
        {
            Flip();
            speed = speed * -1;
        }

    }

    int GetHP()
    {
        return m_HP;
    }





    
    private void Flip()
    {
       
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    
    //void Awake()
    // {
    // exp = transform.GetComponent<EXP>().Myexp;
    //
    //}
}
