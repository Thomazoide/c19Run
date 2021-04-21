using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoParallax : MonoBehaviour
{
    private Transform camTransform;
    public float efectoP = .5f;
    private Vector3 uposCam;
    private void Start(){
        camTransform = Camera.main.transform;
        uposCam = camTransform.position;
    }
    private void Update(){
        Vector3 deltamove = camTransform.position - uposCam;
        transform.position += deltamove * efectoP;
        uposCam = camTransform.position;
    }
}
