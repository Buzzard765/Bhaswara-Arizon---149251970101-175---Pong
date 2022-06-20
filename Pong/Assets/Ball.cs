using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    [SerializeField] float speed, maxSpeed;
    private float returnSpeed;
    public Vector2 balldirection;
    
    public Collider2D coll;
   
    private int HitCount = 0;

    public int HitCount_acc{
        get{ return HitCount;}
        set{ HitCount = value;}
    }
    Core GameManager;
    // Start is called before the first frame update

    private void OnEnable() {
        GameManager = FindObjectOfType<Core>();
        GameManager.onWin += Result;
        returnSpeed = speed;

        balldirection = balldirection.normalized;
    }

    async void Start()
    {
        returnSpeed = speed;
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        StartCoroutine(Launch(3f));              
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate() {
       
    }

    IEnumerator Launch(float delay){
        speed = returnSpeed;     
        int[] angle = new int[]{2,1,-2,-1};   
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        coll.sharedMaterial.bounciness = 1;                  
        HitCount = 0;          
        yield return new WaitForSeconds(delay);
        Movement( new Vector2(angle[Random.Range(0,angle.Length-1)], angle[Random.Range(0,angle.Length-1)]));
        //return speed;
    }

    public void Movement(Vector2 direction){
       
        if(GameManager.P1Score_Acc < GameManager.Limit_Acc
        && GameManager.P2Score_Acc < GameManager.Limit_Acc){           
            rb2d.velocity = direction * speed;
            Debug.Log(speed);
        }
        
    }
    //StartCoroutine dipanggil
    //terus bawahnya dia ubah speed jadi return speed
    //perlu diingat, StartCoroutine itu eksekusinya tidak nunggu sampai coroutinenya selesai baru eksekusi bawahnya
    //tapi langsungcoba cek coroutine di Unity deh
    //sama konsep asynchronous
    private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.name.Contains("Pad")){
            if(HitCount <=maxSpeed){
                HitCount++;
                speed += 0.2f;
                rb2d.velocity *=  speed/returnSpeed;                      
            }
        }
        if(other.gameObject.name.Contains("GoalP1")){
            StartCoroutine(Launch(2f));            
            FindObjectOfType<ItemSpawner>().resetSpawnRate();
            GameManager.P2Score_Acc++;
        }else if(other.gameObject.name.Contains("GoalP2")){
            StartCoroutine(Launch(2f));
            
            FindObjectOfType<ItemSpawner>().resetSpawnRate();
            GameManager.P1Score_Acc++;            
        }
    }

    void Result(){
        SceneManager.LoadSceneAsync("Main Menu");
    }

    
}
