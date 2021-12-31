using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public Vector3 teleportPosition;
    public GameObject player;
    bool teleporting = false;
    public PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - transform.position.x < 1 && player.transform.position.x - transform.position.x > -1 && player.transform.position.z - transform.position.z > -1 && player.transform.position.z - transform.position.z < 1 && player.transform.position.y - transform.position.y > -0.5 && player.transform.position.y - transform.position.y < 2 && !teleporting)
        {
            teleporting = true;
            StartCoroutine(Teleport());
        }
        else
        {
            teleporting = false;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2);
        if (teleporting)
        {
            if (transform.name == "endPortal")
            {
                if (pc.allKeyInStage1)
                    SceneManager.LoadScene(1);
                else
                    player.transform.position = teleportPosition;
            }
            if (transform.name == "endPortal_stage2")
            {
                if (pc.allKeyInStage2)
                    SceneManager.LoadScene(2);
            }
            else
                player.transform.position = teleportPosition;
        }
        teleporting = false;
    }
}
