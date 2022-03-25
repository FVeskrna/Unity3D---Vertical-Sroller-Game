using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private ScoreSystem ScoreSystem;

    private void OnBecameInvisible() {
    Destroy(gameObject);    
    }

    void Start()
    {
        ScoreSystem = GameObject.Find("GameManager").GetComponent<ScoreSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            ScoreSystem.health--;
        }
    }
}
