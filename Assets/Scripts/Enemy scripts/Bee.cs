using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{

    public float movespeed = 3.5f;

    private bool attackstart;
    private bool Moveattack;
    private bool attackright;

    private float attackspeed = 6f;

    void Start()
    {
        if(transform.position.x>0f)
        {
            attackright = false;
        }
        else
        {
            attackright = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        beeattack();
    }



    void beeattack()
    {
        if(transform.position.y>0f)
        {
            Vector3 temp = transform.position;
            temp.y -= movespeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            if(!attackstart)
            {
                attackstart = true;

                StartCoroutine(AttackPlayer());
            }
      
        }
        
        if(Moveattack)
        {
            if(!attackright)
            {
                transform.position -= Vector3.right * attackspeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * attackspeed * Time.deltaTime;
            }
        }
    
    }

    void Deactivate()
    {
            gameObject.SetActive(false);
    }
    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(1.5f);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, -45f)));

        Moveattack = true;
        Invoke("Deactivate", 5f);
    }

}//class
