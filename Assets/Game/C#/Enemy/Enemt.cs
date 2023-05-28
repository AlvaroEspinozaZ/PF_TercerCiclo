using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemt : MonoBehaviour
{
    [SerializeField] Rigidbody rgb;
    [SerializeField] Transform playa;
    public float velocityMovement = 5;
    public float velocityRotatio = 200;
    private Animator anim;
    public float x, y;
    public bool perseguir=true;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!perseguir)
        {            
            rgb.velocity = (playa.position - transform.position) * velocityMovement;
            //transform.Rotate(0, (playa.position.x ) * Time.deltaTime * velocityRotatio, 0);
            transform.Translate(0, 0, (playa.position.y - transform.position.y) * Time.deltaTime * velocityMovement);
        }
        else
        {            
            }


        anim.SetFloat("Velx", x);
        anim.SetFloat("Vely", y);
    }
}
