using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamLookAtButton : MonoBehaviour
{
    public RotateRoad rr;
    public RotateRoad rr1;
    public GameObject player;
    public ChangeText changeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1)
        {

            changeText.Change("Press E to interact with organ.");
            if (Input.GetKeyDown(KeyCode.E))
            {
                rr.Rotate_road();
                rr1.Rotate_road();
            }
        }
        else
            changeText.Change("");
    }
    
}
