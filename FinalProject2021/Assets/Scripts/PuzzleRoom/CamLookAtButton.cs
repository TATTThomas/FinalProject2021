using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAtButton : MonoBehaviour
{
    public RotateRoad rr;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - transform.position.x < 1 && player.transform.position.x - transform.position.x > -1 && player.transform.position.z - transform.position.z > -1 && player.transform.position.z - transform.position.z < 1 && player.transform.position.y - transform.position.y > -1 && player.transform.position.y - transform.position.y < 1)
        {
            Debug.Log("r");
            if (Input.GetKeyDown(KeyCode.E))
            {
                rr.Rotate_road();
            }
        }
    }
    
}
