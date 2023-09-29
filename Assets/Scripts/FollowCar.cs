using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public GameObject car;
    private Vector3 offset = new Vector3(0, 4, -10);

    void LateUpdate()
    {
        transform.position = car.transform.position + offset;
    }
}
