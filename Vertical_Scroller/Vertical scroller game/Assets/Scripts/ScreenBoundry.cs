using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundry : MonoBehaviour
{
    private Camera _camera;
    public float ScreenWidth;
    public float ScreenHeight;
    public EdgeCollider2D ScreenEdge;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        ScreenWidth = 1 / (_camera.WorldToViewportPoint(new Vector3(1,1,0)).x - 0.5f);
        ScreenHeight = 1 / (_camera.WorldToViewportPoint(new Vector3(1,1,0)).y - 0.5f);
        SetBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBoundaries(){
        Vector2 pointA = new Vector2(ScreenWidth/2, ScreenHeight/2);
        Vector2 pointB = new Vector2(ScreenWidth/2, -ScreenHeight/2);
        Vector2 pointC = new Vector2(-ScreenWidth/2, -ScreenHeight/2);
        Vector2 pointD = new Vector2(-ScreenWidth/2, ScreenHeight/2);
        Vector2[] tempArray = new Vector2[] {pointA,pointB,pointC,pointD,pointA};
        ScreenEdge.points = tempArray;
    }

}
