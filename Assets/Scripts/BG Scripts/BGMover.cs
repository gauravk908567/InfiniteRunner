using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : MonoBehaviour
{
    public float movespeed = 5f;
    private GameObject[] sidebounds;

    private float cameraY;
    private float BoundHeight;

    public GameObject[] Enemies;
    public GameObject[] spawnpos;
    void Awake()
    {
        sidebounds = GameObject.FindGameObjectsWithTag("SideBound");
        cameraY = Camera.main.gameObject.transform.position.y-15f;

        BoundHeight = GetComponent<BoxCollider2D>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Reposition();
    }

     void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= movespeed * Time.deltaTime;
        transform.position = temp;
    }

    void Reposition()
    {
        if(transform.position.y<cameraY)
        {
            float highestBoundsY=sidebounds[0].transform.position.y;
            for(int i=1;i<sidebounds.Length; i++)
            {
                if(highestBoundsY<sidebounds[i].transform.position.y)
                {
                    highestBoundsY = sidebounds[i].transform.position.y;
                }
            }

            Vector3 temp = transform.position;
            temp.y = highestBoundsY + BoundHeight-1f;
            transform.position = temp;


            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        if(Random.Range(0,10)>0)
        {
            int randomEnemyIndex = Random.Range(0, Enemies.Length);
            if(randomEnemyIndex==0)
            {
                Instantiate(Enemies[randomEnemyIndex], new Vector3 (0f,transform.position.y, 3f), Quaternion.identity);
            }
            else
            {
                GameObject enemyObj = Instantiate(Enemies[randomEnemyIndex]);
                Vector3 enemyScale = enemyObj.transform.localScale;

                if(Random.Range(0,2)>0)
                {
                    enemyObj.transform.position = spawnpos[0].transform.position;
                    enemyScale.x = -Mathf.Abs(enemyScale.x);
                }
                else
                {
                    enemyObj.transform.position = spawnpos[1].transform.position;
                    enemyScale.x = Mathf.Abs(enemyScale.x);
                }
                enemyObj.transform.localScale = enemyScale;
            }
        }
    }


}//class
