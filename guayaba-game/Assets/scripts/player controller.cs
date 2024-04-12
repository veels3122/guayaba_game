using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    //player
    Transform tr;
    Rigidbody rb;

    public float walkSpeed = 200;

    public float jumpForce = 50;

    public bool OnGround = true;
    public bool Jumping;

    public GameObject triggerJump;

    //camara 3D
    public Transform cameraShoulder;  //eje de la camara
    public Transform cameraHolder; //posicion y rotacion de camara segun el personaje
    private Transform cam;

    private float rotY = 0f;

    public float RotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;

    //animations

    Animator anim;

    private Vector2 animSpeed;





    // Start is called before the first frame update
    void Start()
    {
        tr = this.transform;
        rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();

        cam = Camera.main.transform;


    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
        ActionControl();
        CameraControl();
        AnimControl();
        
    }

    public void MoveControl()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");
        float deltaT = Time.deltaTime;

        animSpeed = new Vector2(deltaX, deltaY);
        Vector3 side = walkSpeed * deltaX * deltaT * tr.right;
        Vector3 forward = walkSpeed * deltaY * deltaT * tr.forward;

        Vector3 direction = side + forward;
        direction.y = rb.velocity.y;


        

    }
    public void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotY += mouseY * RotationSpeed * deltaT;

        float rotX = mouseX * RotationSpeed * deltaT;

        tr.Rotate(0, rotX, 0);

        rotY = Mathf.Clamp(rotY, minAngle, maxAngle);

        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        cameraShoulder.localRotation = localRotation;

        cam.SetPositionAndRotation(Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT), Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT));

   
    }
    public void AnimControl()
    {
        anim.SetBool("ground", OnGround);

        anim.SetFloat("X", animSpeed.x);
        anim.SetFloat("Y", animSpeed.y);

    }
    public void ActionControl()
    {
        //salto
        Jumping = Input.GetKey(KeyCode.Space);

        if (OnGround)
        {
            if (Jumping)
            {
                rb.AddForce(transform.up * jumpForce);
            }

        }


    }
}
