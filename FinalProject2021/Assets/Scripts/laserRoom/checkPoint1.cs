using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint1 : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            player.GetComponent<death_Judge>().rebirthPoint = new Vector3(-15, 2.5f, 15);
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
