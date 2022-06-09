using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] float speed, maxSpeed;
    Collider2D coll;
    private int HitCount = 0;
    Core GameManager;
    // Start is called before the first frame update

    private void OnEnable() {
        GameManager = FindObjectOfType<Core>();
        GameManager.onWin += Result;
    }

    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        StartCoroutine(Launch(3f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Launch(float delay){        
         rb2d.velocity = Vector2.zero;
            transform.position = Vector2.zero;
            int[] angle = new int[]{2,1,-2,-1};       
            HitCount = 0;
            yield return new WaitForSeconds(delay);
            Movement(new Vector2(
                angle[Random.Range(0,angle.Length-1)], 
                angle[Random.Range(0,angle.Length-1)])
            );
    }

    public void Movement(Vector2 direction){
        if(GameManager.P1Score_Acc < GameManager.Limit_Acc
        && GameManager.P2Score_Acc < GameManager.Limit_Acc){
            direction = direction.normalized;   
            rb2d.velocity = direction * speed;
            Debug.Log(rb2d.velocity);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.name.Contains("Pad")){
            if(speed <=maxSpeed){
                speed++;
            }
        }

        if(other.gameObject.name.Contains("GoalP1")){
            StartCoroutine(Launch(2f));
            GameManager.P2Score_Acc++;
        }else if(other.gameObject.name.Contains("GoalP2")
        ){
            StartCoroutine(Launch(2f));
            GameManager.P1Score_Acc++;
        }
    }

    void Result(){
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
