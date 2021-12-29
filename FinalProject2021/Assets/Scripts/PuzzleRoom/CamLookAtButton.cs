using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAtButton : MonoBehaviour
{
    public ButtonController button;
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        // if raycast hits, it checks if it hit an object with the tag Button
        if (Physics.Raycast(transform.position, transform.forward + new Vector3(0, 0, -2), out hit, maxDistance) && hit.collider.gameObject.CompareTag("Player") || Physics.Raycast(transform.position, transform.forward + new Vector3(2, 0, -2), out hit, maxDistance) && hit.collider.gameObject.CompareTag("Player") || Physics.Raycast(transform.position, transform.forward + new Vector3(-2, 0, -2), out hit, maxDistance) && hit.collider.gameObject.CompareTag("Player"))
        {
            //Debug.Log("a");
            button.ChangeColor(Color.red);
        }
        else
        {
            button.ChangeColor(Color.white);
        }
    }
}
