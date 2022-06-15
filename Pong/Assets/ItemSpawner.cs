using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] PowerUpP1, PowerUpP2;
    public Vector2 P1SideMax, P2SideMax, P1SideMin, P2SideMin;
    [SerializeField]float spawnRate;
    private float returnSpawnRate;
    public int spawnAmount = 2;
    int sideindex;
    // Start is called before the first frame update
    void Start()
    {
        
        returnSpawnRate = spawnRate;
        spawnRate+=3;
        sideindex = Random.Range(0,2);
        Debug.Log(1>1);
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate -= Time.deltaTime;
        if(spawnRate <=0 && (spawnAmount >0 && spawnAmount <=2)){
            switch(sideindex){
                case 0:
                    SpawnPowerUp(
                        PowerUpP1[Random.Range(0,PowerUpP1.Length)],
                        new Vector2(
                            Random.Range(P1SideMax.x, P1SideMin.x),
                            Random.Range(P1SideMax.y, P1SideMin.y)
                            )
                        );
                    break;
                case 1:
                    SpawnPowerUp(
                        PowerUpP1[Random.Range(0,PowerUpP2.Length)],
                        new Vector2(
                            Random.Range(P2SideMax.x, P2SideMin.x),
                            Random.Range(P2SideMax.y, P2SideMin.y))
                           );
                    break;
                default:                   
                    break;
            }               
            resetSpawnRate();
        }
    }

    void SpawnPowerUp(GameObject PowerUp, Vector2 SpawnSpot){
        Instantiate(PowerUp, SpawnSpot, Quaternion.identity);
        spawnAmount-=1;
        sideindex = Random.Range(0,2); 
    }

    public void resetSpawnRate(){
        spawnRate = returnSpawnRate;
    }
}
