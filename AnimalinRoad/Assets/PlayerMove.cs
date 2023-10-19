using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.end == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.5f, 0.0f, 0.0f);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.transform.Translate(0.5f, 0.0f, 0.0f);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.transform.Translate(0.0f, 0.0f, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.transform.Translate(0.0f, 0.0f, -0.5f);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            gm.GameOver();
        }
        else if (other.CompareTag("Coin") && gm.end != true)
        {
            gm.GetScore();
        }
    }
}
