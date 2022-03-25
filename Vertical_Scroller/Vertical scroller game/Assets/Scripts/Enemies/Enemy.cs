using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool CanBeDestroyed;
    public GameObject Explosionparticles;
    private ScoreSystem ScoreSystem;
    [SerializeField] private int Reward;

    [HideInInspector] public GameObject EnemyParentObject;

    public GameObject PlayerObject;
    // Start is called before the first frame update
    public void Start()
    {
        EnemyParentObject = GameObject.Find("ParentObject");
        PlayerObject = GameObject.Find("Player");
        ScoreSystem = GameObject.Find("GameManager").GetComponent<ScoreSystem>();
        Initialize();
    }

    public virtual void Initialize(){
        float _scale = Random.Range(0.4f,0.6f);
        transform.localScale = new Vector3(_scale,_scale,_scale);
        Invoke("ToggleCanBeDestroyed",5);
    }

    public virtual void SetVelocity(Vector2 velocity){
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public virtual void setreward(int amount){
        Reward = amount;
    }

    public virtual void setparticles(GameObject particles){
        Explosionparticles = particles;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 7){
            DestroyEnemy();
            Destroy(other.gameObject);
            ScoreSystem.AddPoints(5);
            ScoreSystem.AddCurrency(Reward);
        }
        else if(other.gameObject.tag == "Player"){
            DestroyEnemy();
            ScoreSystem.health--;
        }
    }

    public void OnBecameInvisible() {
        if(CanBeDestroyed)
        Destroy(gameObject);
    }

    public void ToggleCanBeDestroyed() => CanBeDestroyed = !CanBeDestroyed;

    public void DestroyEnemy(){
        GameObject Particles = Instantiate(Explosionparticles,transform.position,Quaternion.identity);
        Particles.transform.SetParent(EnemyParentObject.transform);
        Destroy(gameObject);
    }
}
