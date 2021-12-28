using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, jumpForce;
    bool runforword, runback, runright, runleft, idel, runfr, runfl, runbr, runbl, jump;
    Animator animator;
    public CameraController cameraCont;
    public Vector3 movingDir;
    public Quaternion faceDir;
    public GameObject cm;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        runforword = runback = runleft = runright = false;
        idel = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cm.transform.position = new Vector3(cm.transform.position.x, transform.position.y + 2, cm.transform.position.z);
        movingDir = cameraCont.movingDir;
        faceDir = cameraCont.faceDir;

        idel = true;
        runforword = runback = runleft = runright = false;
        if (Input.GetKey(KeyCode.D))
        {
            runright = true;
            runforword = false;
            runback = false;
            runleft = false;
            idel = false;
            runfr = runfl = runbl = runbr = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cm.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); 
            transform.position += Quaternion.Euler(0, 90, 0) * movingDir * Time.deltaTime * moveSpeed;
            cm.transform.position += Quaternion.Euler(0, 90, 0) * movingDir * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            idel = false;
            runleft = true;
            runforword = false;
            runback = false;
            runright = false;
            runfr = runfl = runbl = runbr = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cm.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.position += Quaternion.Euler(0, -90, 0) * movingDir * Time.deltaTime * moveSpeed;
            cm.transform.position += Quaternion.Euler(0, -90, 0) * movingDir * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            idel = false;
            runright = false;
            runback = false;
            runleft = false;
            runforword = true;
            runfr = runfl = runbl = runbr = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cm.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.position += movingDir * Time.deltaTime * moveSpeed;
            cm.transform.position += movingDir * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            idel = false;
            runforword = false;
            runright = false;
            runleft = false;
            runback = true;
            runfr = runfl = runbl = runbr = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cm.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.position += Quaternion.Euler(0, 180, 0) * movingDir * Time.deltaTime * moveSpeed;
            cm.transform.position += Quaternion.Euler(0, 180, 0) * movingDir * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            runfr = true;
            idel = false;
            runforword = false;
            runright = false;
            runleft = false;
            runback = false;
            runfl = runbl = runbr = false;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            runfl = true;
            idel = false;
            runforword = false;
            runright = false;
            runleft = false;
            runback = false;
            runfr = runbl = runbr = false;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            runbr = true;
            idel = false;
            runforword = false;
            runright = false;
            runleft = false;
            runback = false;
            runfl = runbl = runfr = false;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            runbl = true;
            idel = false;
            runforword = false;
            runright = false;
            runleft = false;
            runback = false;
            runfl = runfr = runbr = false;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            runfr = false;
            idel = true;
            runforword = false;
            runright = false;
            runleft = false;
            runback = false;
            runfl = runbl = runbr = false;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            runfr = false;
            idel = true;
            runforword = false;
            runright = false;
            runleft = false;
            runback = false;
            runfl = runbl = runbr = false;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            runfr = false;
            idel = true;
            runforword = false;
            runright = false;
            runleft = false;
            runback = false;
            runfl = runbl = runbr = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        if (!IsGround())
        {
            jump = true;
        }
        else
        {
            jump = false;
        }


        animator.SetBool("RunForword", runforword);
        animator.SetBool("RunBack", runback);
        animator.SetBool("RunRight", runright);
        animator.SetBool("RunLeft", runleft);
        animator.SetBool("RunBR", runbr);
        animator.SetBool("RunBL", runbl);
        animator.SetBool("RunFR", runfr);
        animator.SetBool("RunFL", runfl);
        animator.SetBool("Idel", idel);
        animator.SetBool("Jump", jump);
    }

    void Jump()
    {
        if (IsGround())
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    bool IsGround()
    {
        bool isGround = Physics.Raycast(transform.position, Vector3.down, 0.06861908f);
        return isGround;
    }

}
