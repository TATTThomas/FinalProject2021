using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public Vector3 teleportPosition;
    public GameObject player;
    public PlayerController pc;
    private float ftime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - transform.position.x < 1 && player.transform.position.x - transform.position.x > -1 && player.transform.position.z - transform.position.z > -1 && player.transform.position.z - transform.position.z < 1 && player.transform.position.y - transform.position.y > -0.5 && player.transform.position.y - transform.position.y < 2)
        {
            ftime += Time.deltaTime;
            if (ftime >= 2f)
            {
                Teleport();
                ftime = 0f;
            }
        }
        else
        {
            ftime = 0f;
        }
    }
    
    void Teleport()
    {
        if (transform.name == "IntoTrapRoomPortal")
        {
            pc.trapRoom = true;
        }
        if (transform.name == "OutTrapRoomPortal")
        {
            pc.trapRoom = false;
        }
        if (transform.name == "endPortal")
        {
            if (pc.allKeyInStage1)
                SceneManager.LoadScene(2);
            else
                player.transform.position = teleportPosition;
        }
        if (transform.name == "endPortal_stage2")
        {
            if (pc.allKeyInStage2)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(3);
            }
        }
        else
            player.transform.position = teleportPosition;
    }
}
