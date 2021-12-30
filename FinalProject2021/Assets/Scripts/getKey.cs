using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getKey : MonoBehaviour
{

    public GameObject player;
    public PlayerController pc;
    Vector3 playerPos;
    int sceneNum;

    // Start is called before the first frame update
    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position + new Vector3(0, 1.85f, 0);
        if (Vector3.Distance(playerPos, transform.position) < 1)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (sceneNum == 0)
                    pc.keyInStage1++;
                if (sceneNum == 1)
                    pc.keyInStage2++;
                Destroy(transform.gameObject);
            }
        }
        if (pc.keyInStage1 == 2)
            pc.allKeyInStage1 = true;
        if (pc.keyInStage2 == 3)
            pc.allKeyInStage2 = true;
    }
}
