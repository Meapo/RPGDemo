using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float CreateTime = 5f;


    private void Update()
    {
        if (CreateTime <= 0)
        {
            Instantiate<GameObject>(enemy);
            CreateTime = 5f;
        }
        CreateTime -= Time.deltaTime;
    }
}
