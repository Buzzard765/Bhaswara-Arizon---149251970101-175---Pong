using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadMovement : MonoBehaviour
{
    [SerializeField]float speed;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name.Contains("P1")){
            movement1();
        }else if(gameObject.name.Contains("P2")){
            movement2();
        }
    }

    void movement1(){
        if(Input.GetKey(KeyCode.W)){
            transform.position += transform.up * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position -= transform.up * Time.deltaTime * speed;
        }
    }

    void movement2(){
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.position += transform.up * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.position -= transform.up * Time.deltaTime * speed;
        }
    }

    
}
