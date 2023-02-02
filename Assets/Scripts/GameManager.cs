using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject grid;
    public GameObject[] candy;
    public GameObject[,] allCandy;

    void Start()
    {
        allCandy = new GameObject[5, 5];
        for(int i =0; i<5; i++)
        {
            for(int j =0; j<5; j++)
            {
                Vector2 tempPos = new Vector2(i, j);
                Instantiate(grid, tempPos, Quaternion.identity);
              GameObject candys =  Instantiate(candy[Random.Range(0,3)], tempPos, Quaternion.identity);
                allCandy[i, j] = candys;
             

        }

    }


    }
   

    void Update()
    {
        
    }
 
}
