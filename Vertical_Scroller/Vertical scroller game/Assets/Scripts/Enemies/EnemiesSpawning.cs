using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawning : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    public GameObject RockEnemy;
    public GameObject ShootingRock;
    public GameObject HomingRock;
    public float TimeBetweenRocks;
    
    private bool AutoSpawnRocks;
    private bool AutoSpawnWaves;

    private Camera _camera;
    private float ScreenWidth;
    private float ScreenHeight;

    int difficulty;

    private GameObject ParentObject;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 0;
        ParentObject = GameObject.Find("ParentObject");
        scoreSystem = GetComponent<ScoreSystem>();
        _camera = Camera.main;
        ScreenWidth = 1 / (_camera.WorldToViewportPoint(new Vector3(1,1,0)).x - 0.5f);
        ScreenHeight = 1 / (_camera.WorldToViewportPoint(new Vector3(1,1,0)).y - 0.5f);

        AutoSpawnRocks = true;
        AutoSpawnWaves = true;

        if(AutoSpawnRocks)
        Invoke("SpawnRock",TimeBetweenRocks);

        if(AutoSpawnWaves)
        Invoke("AutoSpawnRandomWave",0.66f);
    }

    void Update()
    {
        if(difficulty<=10)
        difficulty = (int)(scoreSystem.score / 200);
    }

    void SpawnRock(){
        Vector2 SpawnPosition = new Vector2(Random.Range(-ScreenWidth/2 * 0.9f,ScreenWidth/2 * 0.9f),ScreenHeight/2 * 1.1f);
        GameObject SpawnedRock =  Instantiate(RockEnemy, SpawnPosition, Quaternion.identity);
        SpawnedRock.transform.SetParent(ParentObject.transform);
        if(AutoSpawnRocks)
        Invoke("SpawnRock",TimeBetweenRocks);
    }

    void AutoSpawnRandomWave(){
        SpawnRandomWave();
        Invoke("AutoSpawnRandomWave",TimeBetweenRocks * 5);
    }

    void SpawnRandomWave(){
        int NumOfHomingRocks = 0;
        int NumOfShootingRocks = 0;
        if(difficulty > 3)
        {
            NumOfHomingRocks = Random.Range(difficulty/2,difficulty);

            if(NumOfHomingRocks < difficulty)
            NumOfShootingRocks = difficulty - NumOfHomingRocks;
        }
        else
        {
            NumOfHomingRocks = difficulty;
        }
        

        SpawnWave(NumOfHomingRocks, NumOfShootingRocks);
    }

    void SpawnWave(int NumOfHomingRocks, int NumOfShootingRocks){
        int spawnedRocks = 0;
        for(int i=0; i<NumOfHomingRocks;i++){
            Invoke("SpawnHomingRock",spawnedRocks/5);
            spawnedRocks++;
        }
        for(int i=0; i<NumOfShootingRocks;i++){
            Invoke("SpawnShootingRock",spawnedRocks/5);
            spawnedRocks++;
        }
    }

    void SpawnShootingRock(){
        Vector2 SpawnPosition = new Vector2(Random.Range(-ScreenWidth/2 * 0.9f,ScreenWidth/2 * 0.9f),ScreenHeight/2 * Random.Range(1f,2f));
        GameObject SpawnedRock =  Instantiate(ShootingRock, SpawnPosition, Quaternion.identity);
        SpawnedRock.transform.SetParent(ParentObject.transform);
    }

    void SpawnHomingRock(){
        Vector2 SpawnPosition = new Vector2(Random.Range(-ScreenWidth/2 * 0.9f,ScreenWidth/2 * 0.9f),ScreenHeight/2 * Random.Range(1f,2f));
        GameObject SpawnedRock = Instantiate(HomingRock, SpawnPosition, Quaternion.identity);
        SpawnedRock.transform.SetParent(ParentObject.transform);
    }

}
