using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
    [SerializeField] Vector2 BoundaryMax, BoundaryMin;
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

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, BoundaryMin.x, BoundaryMax.x),
            Mathf.Clamp(transform.position.y, BoundaryMin.y, BoundaryMax.y)
        );
    }

    void movement1(){
        if(Input.GetKey(KeyCode.W)){
            transform.position += transform.up * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position -= transform.up * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += transform.right * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position -= transform.right * Time.deltaTime * speed;
        }

    }

    void movement2(){
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.position += transform.up * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.position -= transform.up * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.position += transform.right * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.position -= transform.right * Time.deltaTime * speed;
        }
    }

    
}
