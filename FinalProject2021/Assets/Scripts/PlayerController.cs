using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, jumpForce;
    bool runforward, runback, runright, runleft, idle, runfr, runfl, runbr, runbl, jump;
    Animator animator;
    public CameraController cameraCont;
    public Vector3 movingDir;
    public Quaternion faceDir;
    public GameObject cm;
    Rigidbody rb;
    Vector3 five = new Vector3(0, 0, -3);
    Vector3 moving;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        runforward = runback = runleft = runright = false;
        idle = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cm.transform.position = transform.position + Quaternion.Euler(0, cm.transform.rotation.eulerAngles.y, 0) * five + Vector3.up*2;
        //cm.transform.position = new Vector3(cm.transform.position.x, transform.position.y + 2, cm.transform.position.z);
        movingDir = cameraCont.movingDir;
        faceDir = cameraCont.faceDir;

        moving = Vector3.zero;

        resetAnimation();
        idle = true;
        if (Input.GetKey(KeyCode.D))
        {
            resetAnimation();
            runright = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cm.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            moving += Quaternion.Euler(0, 90, 0) * movingDir * Time.deltaTime * moveSpeed;
            //rb.MovePosition(transform.position + Quaternion.Euler(0, 90, 0) * movingDir * Time.deltaTime * moveSpeed);
            //cm.transform.position = transform.position + Quaternion.Euler(0, cm.transform.rotation.eulerAngles.y, 0) * five + Vector3.up * 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            resetAnimation();
            runleft = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cm.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            moving += Quaternion.Euler(0, -90, 0) * movingDir * Time.deltaTime * moveSpeed;
            //rb.MovePosition(transform.position + Quaternion.Euler(0, -90, 0) * movingDir * Time.deltaTime * moveSpeed);
            //cm.transform.position = transform.position + Quaternion.Euler(0, cm.transform.rotation.eulerAngles.y, 0) * five + Vector3.up * 2;
        }
        if (Input.GetKey(KeyCode.W))
        {
            resetAnimation();
            runforward = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cm.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            moving += movingDir * Time.deltaTime * moveSpeed;
            //rb.MovePosition(transform.position + movingDir * Time.deltaTime * moveSpeed);
            //cm.transform.position = transform.position + Quaternion.Euler(0, cm.transform.rotation.eulerAngles.y, 0) * five + Vector3.up * 2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            resetAnimation();
            runback = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cm.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            moving += Quaternion.Euler(0, 180, 0) * movingDir * Time.deltaTime * moveSpeed;
            //rb.MovePosition(transform.position + Quaternion.Euler(0, 180, 0) * movingDir * Time.deltaTime * moveSpeed);
            //cm.transform.position = transform.position + Quaternion.Euler(0, cm.transform.rotation.eulerAngles.y, 0) * five + Vector3.up * 2;
        }
        if(Physics.Raycast(transform.position + new Vector3(0, 0.6f, 0), moving.normalized, 0.5f))
        {
            Debug.Log("a");
            moving -= moving * 0.9f;
        }

        //rb.MovePosition(transform.position + moving);
        transform.position += moving;

        if(Physics.Raycast(transform.position + new Vector3(0, 1.92f, 0), cm.transform.position - (transform.position + new Vector3(0, 1.92f, 0)) + movingDir, 3))
        {
            Debug.Log("b");
            cm.transform.position = transform.position + new Vector3(0, 1.92f, 0);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            resetAnimation();
            runfr = true;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            resetAnimation();
            runfl = true;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            resetAnimation();
            runbr = true;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            resetAnimation();
            runbl = true;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            resetAnimation();
            if (Input.GetKey(KeyCode.A))
                runleft = true;
            else if (Input.GetKey(KeyCode.D))
                runright = true;
            else
                idle = true;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            resetAnimation();
            if (Input.GetKey(KeyCode.W))
                runforward = true;
            else if (Input.GetKey(KeyCode.S))
                runback = true;
            else
                idle = true;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            resetAnimation();
            idle = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(IsGround())
                Jump();
        }

        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.down, Color.red, 0.01f, true);
        if (IsGround())
        {
            jump = false;
        }
        else if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.26861890f) && hit.collider.gameObject.CompareTag("Stairs"))
        {
            jump = false;
        }
        else
        {
            jump = true;
        }


        animator.SetBool("RunForword", runforward);
        animator.SetBool("RunBack", runback);
        animator.SetBool("RunRight", runright);
        animator.SetBool("RunLeft", runleft);
        animator.SetBool("RunBR", runbr);
        animator.SetBool("RunBL", runbl);
        animator.SetBool("RunFR", runfr);
        animator.SetBool("RunFL", runfl);
        animator.SetBool("Idel", idle);
        animator.SetBool("Jump", jump);
    }

    void resetAnimation()
    {
        runfr = false;
        idle = false;
        runforward = false;
        runright = false;
        runleft = false;
        runback = false;
        runfl = false;
        runbl = false;
        runbr = false;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    bool IsGround()
    {
        bool isGround = Physics.Raycast(transform.position, Vector3.down, 0.16861890f);
        return isGround;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + (moving) * 2);
    }

}
