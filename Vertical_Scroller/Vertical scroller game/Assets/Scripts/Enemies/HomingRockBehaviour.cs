using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRockBehaviour : Enemy
{
    public GameObject Bullet;
    public float BulletSpeed;


    public override void Initialize()
    {
        SetVelocity(new Vector2(0,-2));
        base.Initialize();
    }

        
    private void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, PlayerObject.transform.position,0.03f);
    }


}
