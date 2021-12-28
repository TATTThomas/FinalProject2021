using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_Judge : MonoBehaviour
{
    bool wall, floor, wallTrap, ceilingTrap;
    public Vector3 rebirthPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.name == "ceilingTrap")
        {
            transform.position = rebirthPoint;
        }
        if (collision.transform.name == "wallTrap")
        {
            wallTrap = true;
        }
        if (collision.transform.name == "wall")
        {
            wall = true;
        }
        if (wall && wallTrap)
        {
            transform.position = rebirthPoint;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "wallTrap")
        {
            wallTrap = false;
        }
        if (collision.transform.name == "wall")
        {
            wall = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
