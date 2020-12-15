using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{


    public float movespeed = 1f;
    private float camY;



    // Start is called before the first frame update
    void Start()
    {
        camY = Camera.main.transform.position.y - 10f;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Deactivate();
    }

    void move()
    {
        Vector3 temp = transform.position;
        temp.y -= movespeed * Time.deltaTime;
        transform.position = temp;
       
        
    }

    void Deactivate()
    {
        if(transform.position.y < camY)
        {
            gameObject.SetActive (false);
          
        }
       
    }

   
}//class
