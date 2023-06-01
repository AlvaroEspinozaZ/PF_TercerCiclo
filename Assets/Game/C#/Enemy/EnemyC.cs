using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : MonoBehaviour
{
    [SerializeField] public float turnSpeed = 200f;
    [SerializeField] public float asd = 0;
    [SerializeField] public Rigidbody rgb;
    [SerializeField] private Quaternion qy = Quaternion.identity;
    [SerializeField] private Quaternion r = Quaternion.identity;
    [SerializeField] private float rot = 0;
    private float anguloSen;
    private float anguloCos;
    public bool _tevi=false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (_tevi)
        {
            //SiRota(asd);
        }
        else
        {
            //SiRota(asd);
        }
    }
    public void SiRota(float _isRotate)
    {
        rot += _isRotate * Time.deltaTime * turnSpeed;
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * rot * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * rot * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy;
        transform.rotation = r;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Te vi");
            //debes restar el transform del player con el ( target.trans-transform position ) y con esos dos vectores sacarle el angulo entre vectores y asi obtienes el angulo 
            rgb.velocity = (other.transform.position - transform.position) * 1;
            asd = (other.transform.position - transform.position).magnitude;
            //transform.Rotate();
            transform.LookAt(other.transform.position);
            //asd = other.GetComponent<Rigidbody>().rotation.y- rgb.rotation.y;
            _tevi = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _tevi = false;
        asd = 0;
    }
}
