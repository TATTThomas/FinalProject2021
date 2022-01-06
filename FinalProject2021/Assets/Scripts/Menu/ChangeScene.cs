using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour, IPointerClickHandler
{
    public int index;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(index < 0)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(index);
        }
    }
}
