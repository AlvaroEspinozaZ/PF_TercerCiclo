using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorC : MonoBehaviour
{
    public float velocityMovement = 5;
    public float velocityRotatio = 200;
    private Animator anim;
    public float x, y;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0,x*Time.deltaTime*velocityRotatio,0);
        transform.Translate(0,0,y*Time.deltaTime*velocityMovement);

        anim.SetFloat("Velx", x);
        anim.SetFloat("Vely", y);
    }
}
