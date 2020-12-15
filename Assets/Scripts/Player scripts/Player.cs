using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    private Animator anim;
    private bool onleft, onright;
    private bool jumped;


    [SerializeField]
    AudioSource kill, jump;
    
    [SerializeField]
    private AudioClip dead;

    private bool isAlive= true;
    void Awake()
    {
        GameObject.Find("JumpBtn").GetComponent<Button>().onClick.AddListener(Jump);
        anim = GetComponent<Animator>();
        onright = true;
        onleft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            if (!jumped)
            {
                if (onright)
                {
                    anim.Play("Run_right");
                }
                else
                {
                    anim.Play("Run_left");
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                {
                    if (onright)
                    {
                        anim.Play("Jumpleft");
                    }
                    else
                    {
                        anim.Play("Jumpright");
                    }
                    jumped = true;
                }
            }
        }
    }

    public void Jump()
    {
        if(isAlive)
        {
            if (onright)
            {
                anim.Play("Jumpleft");
            }
            else
            {
                anim.Play("Jumpright");
            }
            jumped = true;
            jump.Play();
        }
    }

    void OnLeft()
    {
        onleft = true;
        onright = false;
        jumped = false;

    }

    void OnRight()
    {
        onleft = false;
        onright = true;
        jumped = false;
    }

    void Playerdied()
    {
        kill.clip = dead;
        kill.Play();
        isAlive = false;
        if(transform.position.x>0)
        {
            anim.Play("playerdiedright");
        }
        else
        {
            anim.Play("playerdiedleft");
        }


        GameplayController.instance.GameOver();
        Time.timeScale = 0f;

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(jumped)
        {
            if (target.tag=="Enemy")
            {
                target.gameObject.SetActive(false);
                kill.Play();
            }
        }
        else
        {
            if(target.tag=="Enemy")
            {
                Playerdied();
            }
        }
        if(target.tag=="EnemyTree")
        {
            Playerdied();
        }
    }
}//class
