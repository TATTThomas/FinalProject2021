using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getKey : MonoBehaviour
{

    public GameObject player;
    public PlayerController pc;
    public death_Judge dj;
    public Text text;
    Vector3 playerPos;
    int sceneNum;
    public trap_sinMove cube1, cube2;

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
            text.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if (sceneNum == 1)
                {
                    if (pc.trapRoom)
                    {
                        dj.trapRebirthPoint = new Vector3(0, 0.01f, 150);
                        cube1.offset = 1.1f;
                        cube2.offset = 2.2f;
                    }
                    pc.keyInStage1++;
                    text.gameObject.SetActive(false);
                }
                if (sceneNum == 2)
                {
                    pc.keyInStage2++;
                    text.gameObject.SetActive(false);
                }
                Destroy(transform.gameObject);
            }
        }
        else
            text.gameObject.SetActive(false);
        if (pc.keyInStage1 == 2)
            pc.allKeyInStage1 = true;
        if (pc.keyInStage2 == 3)
            pc.allKeyInStage2 = true;
    }
}
