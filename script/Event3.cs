using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3 : MonoBehaviour
{
    public Rigidbody2D m_toge;
    public Rigidbody2D m_toge2;
    public Rigidbody2D m_toge3;
    public Rigidbody2D m_toge4;
    public Rigidbody2D m_toge5;


    public float speed = -10f;
    public int MaxTurns = 3;
    private int turns = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            turns++;
            print("success");
            Vector2 v = new Vector2(0, speed);
            m_toge.velocity = v * Time.deltaTime;
            m_toge2.velocity = v * Time.deltaTime;
            m_toge3.velocity = v * Time.deltaTime;
            m_toge4.velocity = v * Time.deltaTime;
            m_toge5.velocity = v * Time.deltaTime;
            if (turns >= MaxTurns)
            {

                Destroy(gameObject);
            }
        }
    }
}