using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    void Start()
    {
        speed = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        float cMove = Time.deltaTime * speed;
        transform.Translate(Vector3.forward * cMove);

        if(this.transform.position.z >= 10)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}