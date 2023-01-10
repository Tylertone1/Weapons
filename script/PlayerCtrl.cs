using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.Runtime.InteropServices;

public class PlayerCtrl : MonoBehaviour
{

    public GameObject knife;
    public GameObject sword;
    public GameObject Stabbingsword;
    public GameObject Greatsword;
    public GameObject Bronzesword;
    public GameObject Goldensword;
    public GameObject goldedasd;
    public GameObject dwdaw;
    public GameObject dawd;
    public GameObject dawddd;

















    public int m_HP = 100;
    public PlayerCtrl data;
    public Text Life;
    public Text xxx;
    public Text Grade;

    bool m_isGrounded;

    bool m_isWalled;
   

    public LayerMask m_groundLayer;
    public float m_groundCheckDistance = 0.4f;

    public Transform m_headCheck;
    public Transform m_footCheck;
    public float m_wallCheckDistance = 0.4f;
    


    Animator m_anim;
    Rigidbody2D m_body;

    bool m_FacingRight = true;

    public float m_Speed = 200f;
    public float m_jumpForce = 20f;

    public float m_CanJumpTime = 0.2f;
    private float m_JumpTimer;
    private bool m_isJumping;
    private bool m_attack;

    private Vector2 m_vec;
    private float m_input_h;

    // 二段跳
    private int m_jumpTimes;



    public GameObject pfb_bullet;
    protected Vector2 bulletSpeed = new Vector2(15, 0);
    public AudioClip shooting;
    public int EXP = 0;//level
    public int Level = 1;
    public AudioClip inopp;

    /// </summary>

    void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_body = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_JumpTimer = 0f;
        m_isJumping = false;
        m_anim.SetBool("attack", false);
        m_vec = new Vector2(0, m_jumpForce);
        m_jumpTimes = 0;
       


    }


   
    
       

    


    private void Update()
    {
        m_isGrounded = IsGrounded();
        Life.text = "Life:" + m_HP.ToString();

        if (m_anim.GetBool("Ground") != m_isGrounded)
        {
            m_anim.SetBool("Ground", m_isGrounded);
        }

        #region 跳跃代码
        // 跳跃
        if (m_isJumping && Input.GetButton("Jump"))
        {
            if (m_JumpTimer <= m_CanJumpTime)
            {
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
                m_JumpTimer += Time.deltaTime;
            }
            else
            {
                m_isJumping = false;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(m_isGrounded)
            {
                m_jumpTimes = 1;

                m_isJumping = true;
                m_JumpTimer = 0f;
                m_isGrounded = false;
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
            }
            else if (m_jumpTimes == 1)
            {
                m_jumpTimes = 2;

                m_isJumping = true;
                m_JumpTimer = 0f;
                m_isGrounded = false;
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
            }

        }
        

        if (Input.GetButtonUp("Jump"))
        {
            m_isJumping = false;
        }

        m_anim.SetFloat("vSpeed", m_body.velocity.y);
        #endregion


        m_input_h = Input.GetAxisRaw("Horizontal");
        Move(m_input_h);


        if (Input.GetButtonDown("Fire1"))



        {



            m_anim.SetBool("attack", true);
                GameObject obj = Instantiate(pfb_bullet, transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().velocity = m_FacingRight ? bulletSpeed : -1 * bulletSpeed;

            

            AudioSource.PlayClipAtPoint(shooting, transform.position, 1);

        }


        if (Input.GetButtonUp("Fire1"))
        {
            m_anim.SetBool("attack", false);
        }

        


        Grade.text = "EXP:" + EXP.ToString();
        

        if (EXP >= 10)
        {
            
            
            EXP = 0;
            Level++;
            


            AudioSource.PlayClipAtPoint(inopp, transform.position, 1);




            xxx.text = "Level:" + Level.ToString();




           
            
             ;
            if (Level == 2)
            {
                knife.SetActive(false);
                sword.SetActive(true);



            }


            else if ( Level==3)
            {
                sword.SetActive(false);
                Stabbingsword.SetActive(true);
                
            }
            else if (Level ==4 )
            {
                Stabbingsword.SetActive(false);
                Greatsword.SetActive(true);
            }
            else if (Level == 5)
            {
                Greatsword.SetActive(false);
                Bronzesword.SetActive(true);
            }
            else if (Level == 6)
            {
                Bronzesword.SetActive(false);
                Goldensword.SetActive(true);
            }
            else if (Level == 7)
            {
                Goldensword.SetActive(false);
                goldedasd.SetActive(true);
            }
            else if (Level == 8)
            {
                goldedasd.SetActive(false);
                dwdaw.SetActive(true);
            }
            else if (Level == 9)
            {
                dwdaw.SetActive(false);
                dawd.SetActive(true);
            }
            else if (Level == 10)
            {
                dawd.SetActive(false);
                dawddd.SetActive(true);
                winImage.SetActive(true);
                m_HP = 1000;

            }










        }

        

    }

    private void Move(float h)
    {
        m_isWalled = IsWalled(m_FacingRight ? 1 : -1);

        if (m_FacingRight)
        {
            if(h<0)
            {
                Flip();
            }
            else if(m_isWalled)
            {
                m_anim.SetBool("run", false);
                return;
            }
        }
        else
        {
            if(h>0)
            {
                Flip();
            }
            else if(m_isWalled)
            {
                m_anim.SetBool("run", false);
                return;
            }
        }

        Vector2 v = m_body.velocity;
        v.x = h * m_Speed * 1;        
        m_body.velocity = v;


        m_anim.SetBool("run", !(h == 0));
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, m_groundCheckDistance, m_groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    private bool IsWalled(float dir)
    {
        RaycastHit2D hit1 = Physics2D.Raycast(m_headCheck.position, dir * Vector2.right, m_wallCheckDistance, m_groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(m_footCheck.position, dir * Vector2.right, m_wallCheckDistance, m_groundLayer);
        if ((hit1.collider == null)&&(hit2.collider == null))
        {
            return false;
        }
        return true;
    }

    
    public GameObject ui_GameOverImage;
    public GameObject winImage;
    public AudioClip FailAudio;
    public AudioClip EnemyAudio;
    public AudioClip Hurt;
    public AudioClip boom;
    public AudioClip ore1;
    public AudioClip ore2;
    public AudioClip ore3;
    public AudioClip heal;
    public AudioClip curse;






    void BeDamaged(int damage
        )
    {
        m_HP -= damage;
        AudioSource.PlayClipAtPoint(Hurt, transform.position, 1);
        if (m_HP<=0)
        {
            // 玩家死亡
            Destroy(gameObject);
            ui_GameOverImage.SetActive(true);
            AudioSource.PlayClipAtPoint(FailAudio, transform.position, 1);

        }
    }





   
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boom")
        {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                GameObject.Destroy(enemies[i]);
            }


            AudioSource.PlayClipAtPoint(boom, transform.position, 1);
            
        }
        if (other.tag != "grave")
        {
            if (other.tag == "Gem")
            {
                m_HP += 15;
                AudioSource.PlayClipAtPoint(heal, transform.position, 1);
            }
            else if (other.name == "Ore1(Clone)")
            {
                EXP += 2;
                AudioSource.PlayClipAtPoint(ore1, transform.position, 1);
            }
            else if (other.name == "Ore2(Clone)")
            {
                EXP += 3;
                AudioSource.PlayClipAtPoint(ore2, transform.position, 1);
            }
            else if (other.name == "Ore3(Clone)")
            {
                EXP += 7;
                AudioSource.PlayClipAtPoint(ore3, transform.position, 1);
            }
            
            Destroy(other.gameObject);
        }
           else if(other.tag == "grave")
        {
            m_HP -= 3;
            AudioSource.PlayClipAtPoint(curse, transform.position, 1);
        }
        


    }


    





}
