using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnBecameInvisible() {
    Destroy(gameObject);    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
