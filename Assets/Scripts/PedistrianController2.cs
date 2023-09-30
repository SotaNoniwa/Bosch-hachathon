using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PedistrianController2 : MonoBehaviour
{
    private float distanceX;
    private float distanceY;
    private float speedX;
    private float speedY;
    public GameObject Car;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        // grab variable from CarController script
        Debug.Log(Car.GetComponent<CarController>().startTime);
        distanceX = Car.GetComponent<CarController>().floatValues[3] / 128;
        distanceY = Car.GetComponent<CarController>().floatValues[4] / 128; // distanceY = distanceZ in unity space
        speedX = Car.GetComponent<CarController>().floatValues[12] / 256;
        speedY = Car.GetComponent<CarController>().floatValues[13] / 256;
        var carPosX = Car.transform.position.x;
        var carPosY = Car.transform.position.y;
        var carPosZ = Car.transform.position.z;
        Vector3 newPosition = new Vector3(distanceX, carPosY, distanceY);
        transform.position = Car.transform.position + newPosition;
    }
}