using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Renderer renderer, rendererChild;
    GameObject child1, child2;
    // Start is called before the first frame update
    void Start()
    {
        child2 = transform.GetChild(1).gameObject;
        child1 = transform.GetChild(0).gameObject;
        rendererChild = child1.GetComponent<MeshRenderer>();
        renderer = child2.GetComponent<MeshRenderer>();
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
