using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update

    void Start()
    {
        text = transform.GetChild(0).GetComponent<Text>();
    }

    public void Change(string s)
    {
        text.text = s;
    }

    // Update is called once per frame
    void Update()
    {

    }
}