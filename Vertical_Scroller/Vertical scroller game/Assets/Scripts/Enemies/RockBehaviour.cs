using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : Enemy
{
    public override void Initialize()
    {
        SetVelocity(new Vector2(0,-2));
        base.Initialize();
    }
}
