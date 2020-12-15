using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{

    private bool attackright;
    private float attackspeed = 6f;


    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-45f, 45f)));

        if(transform.position.x>0f)
        {
            attackright = false;
        }
        else
        {
            attackright = true;
        }


        Invoke("Deactivate", 5f);

    }



    // Update is called once per frame
    void Update()
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

    void Deactivate()
    {
        gameObject.SetActive(false); 
    }

}//class
