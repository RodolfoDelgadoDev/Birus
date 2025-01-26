using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, 0, 14 *   Time.deltaTime);    
    }
}
