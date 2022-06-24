using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float hor;
    float vert;
    [SerializeField] float speed;

    string direction = "up";

    void Start()
    {
        Debug.Log(transform.rotation);
    }

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if(Mathf.Abs(hor)>Mathf.Abs(vert)){
            if(hor>0){
                direction = "right";
                SetRotationZ(270);
                }
            if(hor<0){
                direction = "left";
                SetRotationZ(90);
                }
        }
        else{
            if(vert>0){
                direction = "up";
                SetRotationZ(0);
                }
            if(vert<0){
                direction = "down";
                SetRotationZ(180);
                }
        }

        transform.position += new Vector3
            (hor*Time.deltaTime*speed,
            vert*Time.deltaTime*speed,
            0);

        // Debug.Log(direction);
        // Debug.Log(hor);
        // Debug.Log(vert);
    }

    public void SetRotationZ(int rotationValue){
        Quaternion goal = Quaternion.Euler(0, 0, rotationValue);
        if(transform.rotation == goal){return;}

        Vector3 difference = new Vector3(0, 0, rotationValue-transform.rotation.eulerAngles.z);

        Debug.Log(transform.rotation.eulerAngles);
        transform.Rotate(difference);
    }
}
