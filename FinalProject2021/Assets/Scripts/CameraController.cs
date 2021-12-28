using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float sensitivity;
    public Vector3 movingDir;
    public Quaternion faceDir;
    Vector3 five = new Vector3(0, 0, -5);
    public Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        movingDir = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        faceDir = transform.rotation;
        //movingDir = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.forward;
        distance = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * five;
        movingDir = -(transform.position - player.transform.position);
        movingDir = new Vector3(movingDir.x, 0, movingDir.z);
        movingDir = movingDir.normalized;
    }



    void FixedUpdate()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        transform.RotateAround(player.transform.position, -Vector3.up, rotateHorizontal * sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        //transform.RotateAround(Vector3.zero, transform.right, rotateVertical * sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player
    }
}

