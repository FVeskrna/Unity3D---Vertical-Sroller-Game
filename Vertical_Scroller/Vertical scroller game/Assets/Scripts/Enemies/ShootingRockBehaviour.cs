using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRockBehaviour : Enemy
{
    private Camera _camera;
    private GameObject Player;
    private float ScreenWidth;
    private float ScreenHeight;
    Vector2 position;
    private bool CanShoot;

    public GameObject Bullet;
    public float BulletSpeed;


    public override void Initialize()
    {
        _camera = Camera.main;
        ScreenWidth = 1 / (_camera.WorldToViewportPoint(new Vector3(1,1,0)).x - 0.5f);
        ScreenHeight = 1 / (_camera.WorldToViewportPoint(new Vector3(1,1,0)).y - 0.5f);
        Player = GameObject.Find("Player");
        InvokeRepeating("ShootAndMove",0,3f);
        base.Initialize();
    }

    private void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, position,0.03f);
    }

    private void ShootAndMove(){
        if(CanShoot)
        Shoot();

        Invoke("ChangePosition",0.2f);
    }

    void Shoot(){
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        GameObject _bullet =  Instantiate(Bullet,transform);
        _bullet.transform.parent = null;
        _bullet.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
        Rigidbody2D _bulletRB = _bullet.GetComponent<Rigidbody2D>();
        Vector2 PlayerPosition = Player.transform.position;
        Vector2 AimDirection = PlayerPosition - _bulletRB.position;
        float aimAngle = Mathf.Atan2(AimDirection.y,AimDirection.x) * Mathf.Rad2Deg - 90f;
        _bulletRB.rotation = aimAngle;
        _bulletRB.AddForce(direction * BulletSpeed, ForceMode2D.Impulse);
        _bullet.transform.SetParent(EnemyParentObject.transform);

    }

    void ChangePosition(){
        position = new Vector2(Random.Range(-ScreenWidth/2,ScreenWidth/2),Random.Range(-ScreenHeight/2,ScreenHeight/2));
        CanShoot = true;
    }
}
