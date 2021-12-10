using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
