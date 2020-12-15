using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public float movespeed = 5f;
    private float camY;
    private bool attackplayer;
    public GameObject shruiken;
    
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


        if(transform.position.y<0)
        {
            if(!attackplayer)
            {
                attackplayer = true;
                Instantiate(shruiken, transform.position, Quaternion.identity);
            }
        }
    }
    void Deactivate()
    {
        if(transform.position.y < camY)
        {
            gameObject.SetActive(false);
        }
    }
}//class
