using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls1 : MonoBehaviour
{
    private void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
                Debug.Log("touch " + i +" began");
            else if (t.phase == TouchPhase.Ended)
                Debug.Log("touch " + i + " ended");
            else if (t.phase == TouchPhase.Moved)
                Debug.Log("touch " + i + " is moving");
            i++;
        }
    }


}
