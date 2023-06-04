using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemt : MonoBehaviour
{
    public float life = 200;
    public float x, y;
    public bool perseguir=true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {      
    }
    public void UpdateLife(float damage)
    {
        life -= damage;
    }
}
