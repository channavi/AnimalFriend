using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject gameManager;
    public int moveX, moveY;

    public Sprite[] dirSprites = new Sprite[3];

    // 0 : 위 1: 아래 2 : 왼쪽 3 : 오른쪽
    public GameObject[] collideBlock = new GameObject[4];

    public int posx, posy;
    public bool[] isMove = new bool[4];
    public Vector3 targetPosition;
    public Vector3 blockPosition;
    public Vector3 blockTargetPosition;

    public void init()
    {
        gameManager = GameObject.Find("GameManager");
        moveX = gameManager.GetComponent<GameManager>().moveX;
        moveY = gameManager.GetComponent<GameManager>().moveY;
        // 처음 위치 설정
        posx = 0; posy = 0;
        targetPosition = new Vector3(posx,posy);
        this.gameObject.transform.position = new Vector3(posx, posy, 0);
        targetPosition = this.gameObject.transform.position;
        for (int i = 0; i<4; i++) isMove[i] = false;
    }

    public void move(string direction)
    {
        // 보고 있는 방향이 다르면 sprite를 각각 다르게 설정
        if(direction.Equals("up"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dirSprites[1];
            if (collideBlock[0] != null)
            {
                collideBlock[0].GetComponent<block>().move(0, 1);
            }
        }
        else if (direction.Equals("down"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dirSprites[0];
            if (collideBlock[1] != null)
            {
                collideBlock[1].GetComponent<block>().move(0, -1);
            }
        }
        else if (direction.Equals("left"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dirSprites[2];
            this.gameObject.transform.localScale = new Vector3(1,1,1);
            if (collideBlock[2] != null)
            {
                collideBlock[2].GetComponent<block>().move(-1, 0);
            }
        }
        else if (direction.Equals("right"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dirSprites[2];
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            if (collideBlock[3] != null)
            {
                collideBlock[3].GetComponent<block>().move(1, 0);
            }
        }
        this.gameObject.transform.position = new Vector3(posx, posy, 0);
    }

    public void blockMove(string direction)
    {
        if (collideBlock[0] != null) 
        {
            gameManager.GetComponent<MapManager>
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
