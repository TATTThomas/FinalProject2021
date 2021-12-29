using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_Judge : MonoBehaviour
{
    bool wall, wallTrap;
    int trapNum;
    public Vector3 rebirthPoint;

    // Start is called before the first frame update
    void Start()
    {
        trapNum = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "ceilingTrap")
        {
            transform.position = rebirthPoint;
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
        if ((wall && wallTrap) || trapNum >= 2)
        {
            transform.position = rebirthPoint;
        }
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
    }

    // Update is called once per frame
    void Update()
    {
    }
}
