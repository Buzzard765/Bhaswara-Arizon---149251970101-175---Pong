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
        int[] angle = new int[]{2,1,-2,-1};
        int[] direction = new int[]{2,1,-2,-1};
        HitCount = 0;
        yield return new WaitForSeconds(3f);
        Movement(new Vector2(
            direction[Random.Range(0,direction.Length-1)]
            ,angle[Random.Range(0,angle.Length-1)]));
    }

    public void Movement(Vector2 direction){
        direction = direction.normalized;
        float ballspeed = speed + HitCount;
        rb2d.velocity = direction *  ballspeed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision");
        if(other.gameObject.name.Contains("Pad")){
            if(speed <=maxSpeed){
                speed++;
            }
        }
        
        if(other.gameObject.name.Contains("Goal")){
            StartCoroutine(ReLaunch());
        }
    }

    IEnumerator ReLaunch(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        int[] angle = new int[]{2,1,-2,-1};
        int[] direction = new int[]{2,1,-2,-1};
        HitCount = 0;
        yield return new WaitForSeconds(1f);
        Movement(new Vector2(
            direction[Random.Range(0,direction.Length-1)]
            ,angle[Random.Range(0,angle.Length-1)]));
    }

   
    

    
}
