using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private ScoreSystem ScoreSystem;
    public float _MovementSpeed;
    public Camera MainCamera;
    private Rigidbody2D Rigidbody2D;
    private float _CurrentSpeed;

    private float _MovementX;
    private float _MovementY;
    private Vector2 _Movement;

    [HideInInspector] public float aimAngle;

    private void Start() {
        ScoreSystem = GameObject.Find("GameManager").GetComponent<ScoreSystem>();
        Rigidbody2D = this.GetComponent<Rigidbody2D>();
        _CurrentSpeed = _MovementSpeed;
    }
    void FixedUpdate(){
        MovementPosition();
        MovementRotation();


        if(Input.GetKey(KeyCode.LeftShift)){
            Warp();
        }
    }

    void MovementPosition(){
        _MovementX = Input.GetAxisRaw("Horizontal");
        _MovementY = Input.GetAxisRaw("Vertical");
        _Movement = new Vector2(_MovementX,_MovementY).normalized;
        Rigidbody2D.velocity = _Movement * _CurrentSpeed;
    }

    void MovementRotation(){
        Vector2 mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 AimDirection = mousePos - Rigidbody2D.position;
        aimAngle = Mathf.Atan2(AimDirection.y,AimDirection.x) * Mathf.Rad2Deg - 90f;
        Rigidbody2D.rotation = aimAngle;
    }

    void Warp()
    {
        _CurrentSpeed = _MovementSpeed * 10;
        Invoke("ReturnToNormalMovementSpeed",0.1f);
    }

    void ReturnToNormalMovementSpeed() => _CurrentSpeed = _MovementSpeed;


}
