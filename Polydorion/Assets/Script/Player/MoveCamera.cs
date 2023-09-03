using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform camer;

    private void Update()
    {
        transform.position = camer.position;
    }
}
