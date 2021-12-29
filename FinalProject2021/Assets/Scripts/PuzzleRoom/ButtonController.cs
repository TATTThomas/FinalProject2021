using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Renderer renderer, rendererChild;
    GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        child = transform.GetChild(0).gameObject;
        rendererChild = child.GetComponent<MeshRenderer>();
        //renderer.material.color = Color.red;
    }

    public void ChangeColor(Color color)
    {
        renderer.material.color = color;
        rendererChild.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
