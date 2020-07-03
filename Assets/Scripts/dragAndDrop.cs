using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndDrop : MonoBehaviour
{
    private bool isDraggin;

    public void OnMouseDown()
    {
        isDraggin = true;
    }
    public void OnMouseUp()
    {
        isDraggin = false;

    }

     void Update()
    {
        if (isDraggin)
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousPos);
        }
    }
}
