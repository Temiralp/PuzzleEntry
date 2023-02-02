using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    float touchAngle;
    Vector2 firstTouchPos;
    Vector2 finishTouchPos;
    GameObject otherObje;
    GameManager gm;
    int column;
    int row;
    

    void Start()
    {
        column = (int)transform.position.x;
        row = (int)transform.position.y;
        gm = FindObjectOfType<GameManager>();
    
    }

    // Update is called once per frame
    void Update()
    {
        column = (int)transform.position.x;
        row = (int)transform.position.y;
        CandyCheck();
    }
    private void OnMouseDown()
    {
        firstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        finishTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        AngleCalculation();
        CandyMovement();
    }
    void AngleCalculation()
    {
        touchAngle = Mathf.Atan2(finishTouchPos.y - firstTouchPos.y, finishTouchPos.x - firstTouchPos.x) * Mathf.Rad2Deg;
        Debug.Log(touchAngle);
    }
void CandyMovement()
    {
        //saða hareket
        if (touchAngle > -45 && touchAngle < 45 && transform.position.x < 4) {
            otherObje = gm.allCandy[column+1, row];

            otherObje.transform.position = new Vector2(column, row);

            gm.allCandy[column, row] = otherObje;
            gm.allCandy[column+1, row] = this.gameObject;
            this.gameObject.transform.position = new Vector2(column+1, row);
          

        }
        if ((touchAngle > 135 || touchAngle <= -135)&& transform.position.x >0)
        {
            this.gameObject.transform.position = new Vector2(transform.position.x -1, transform.position.y);
        }
        //up
        if (touchAngle > 45 && touchAngle <= 135&& transform.position.y <4)
        {
            this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y+1);
        }
        //down
        if (touchAngle < -45 && touchAngle >= -135 && transform.position.y >0)
        {
            this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        }


    }
    void CandyCheck()
    {
        if(gm.allCandy[0,0].tag == gm.allCandy[1, 0].tag)
        {
            Debug.Log("0,0-0,1 eþit");
            //gm.allCandy[0, 0].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //gm.allCandy[1, 0].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //Destroy(gm.allCandy[0, 0].gameObject);

        }
    }
}
