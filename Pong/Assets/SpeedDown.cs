using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : PowerUp
{   
    public float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReturnAmount2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name.Contains("Ball")){
            SlowDown();
            ReturnAmount(0);
        }
    }

    private void SlowDown(){
        Ball ball = FindObjectOfType<Ball>();
        ball.rb2d.velocity *= magnitude;        
    }   

    IEnumerator ReturnAmount2(){
        yield return new WaitForSeconds(9f);
        FindObjectOfType<ItemSpawner>().spawnAmount++;
        Destroy(gameObject);
    }

}
