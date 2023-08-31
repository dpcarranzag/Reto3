using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
  public float velX = 0.01f;
 public float movX;
 public float inputX;


 // Use this for initialization
 void Start () {

 }


 void Update () {

float inputX = Input.GetAxis("Horizontal");


if (inputX>0) {
 movX = transform.position.x + (inputX * velX);
 transform.position = new Vector3 (movX, transform.position.y, 0);
 transform.localScale = new Vector3(1, 1, 1);


 }


if (inputX<0) {
 movX = transform.position.x + (inputX * velX);
 transform.position = new Vector3 (movX, transform.position.y, 0);
 transform.localScale = new Vector3(- 1, 1, 1);
}



 }



}
