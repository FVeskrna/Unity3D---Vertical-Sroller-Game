using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject Bullet;
    public float TimeBetweenShots;
    public float BulletSpeed;
    private bool CanShoot;

    // Start is called before the first frame update
    void Start()
    {
        CanShoot = true;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(CanShoot && Input.GetKey(KeyCode.Mouse0) ){
            shoot();
            CanShoot = false;
            Invoke("CanShootAgain",TimeBetweenShots);
        }
    }
    void CanShootAgain() => CanShoot = true;

    void shoot(){
        GameObject _bullet =  Instantiate(Bullet,barrel);
        Rigidbody2D _bulletRB = _bullet.GetComponent<Rigidbody2D>();
        _bulletRB.rotation = GetComponent<PlayerMovement>().aimAngle;
        _bulletRB.AddForce(barrel.up * BulletSpeed, ForceMode2D.Impulse);
    }
}
