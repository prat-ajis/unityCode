using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logController : MonoBehaviour
{
    public float logSpeed;

    void Update()
    {
        transform.Translate(Vector2.left * logSpeed * Time.deltaTime);
    }
}
