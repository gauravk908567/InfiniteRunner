using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{


    private float move_speed = 3f;
    

   
    void Update()
    {
        Move();

    }



    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += move_speed * Time.deltaTime;
        transform.position = temp;
    }

     void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "SideBound")
        {
            move_speed *= -1f;

           Vector3 temp = transform.localScale;
           temp.x *= -1f;
           transform.localScale = temp;
       }
   }
   

}//class
