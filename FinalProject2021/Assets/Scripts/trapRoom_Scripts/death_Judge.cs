using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_Judge : MonoBehaviour
{
    public bool wall, wallTrap, floor, ceilingTrap;
    bool startTimer;
    int counter;
    int trapNum;
    public Vector3 rebirthPoint, trapRebirthPoint;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        startTimer = true;
        trapNum = 0;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "wallTrap")
        {
            wallTrap = false;
            trapNum--;
        }
        if (collision.transform.name == "specificWall")
        {
            wall = false;
        }
        if (transform.position.y > 0.1f)
        {
            floor = false;
        }
        if (collision.transform.name == "ceilingTrapCube")
        {
            ceilingTrap = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "ceilingTrapCube" && transform.position.x - collision.transform.position.x < 1.2 && transform.position.x - collision.transform.position.x > -1.2 && transform.position.z - collision.transform.position.z < 1.2 && transform.position.z - collision.transform.position.z > -1.2)
        {
            ceilingTrap = true;
        }
        if (collision.transform.name == "wallTrap")
        {
            wallTrap = true;
            trapNum++;
        }
        if (collision.transform.name == "specificWall")
        {
            wall = true;
        }
        if (collision.transform.name == "floor")
        {
            floor = true;
        }
        if ((wall && wallTrap) || trapNum >= 2 || collision.transform.name == "laser" || (ceilingTrap && floor) || collision.transform.name == "dead")
        {
            StartCoroutine(timer());
        }
    }


    IEnumerator timer()
    {
        pc.dead = true;
        yield return new WaitForSeconds(2);
        pc.dead = false;
        if (pc.trapRoom)
        {
            transform.position = trapRebirthPoint;
        }
        else
        {
            transform.position = rebirthPoint;
        }

    }


    // Update is called once per frame
    void Update()
    {
    }
}
