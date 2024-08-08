using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlMov : MonoBehaviour
{
    public float speed = 1f;

    private void Update() {
        float movement = Input.GetAxis("Vertical");
        transform.position+=new Vector3(0,movement,0)*speed*Time.deltaTime;
        float movemon = Input.GetAxis("Horizontal");
        transform.position+=new Vector3(movemon,0,0)*speed*Time.deltaTime;
    }
}
