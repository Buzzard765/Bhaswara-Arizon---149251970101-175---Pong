using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] float speed, maxSpeed;
    Collider2D coll;
    private int HitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        StartCoroutine(Launch());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Launch(){
        HitCount = 0;
        yield return new WaitForSeconds(3f);
        Movement(new Vector2(2,-1));
    }

    public void Movement(Vector2 direction){
        direction = direction.normalized;
        float ballspeed = speed + HitCount;
        rb2d.velocity = direction *  ballspeed;
    }

    private void onCollisionEnter2D(Collider2D collision){
        if(collision.gameObject.name.Contains("Pad")){
            if(speed <=maxSpeed){
                HitCount++;
            }
        }
    }
}
