using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PedestrianController3 : MonoBehaviour
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
        distanceX = Car.GetComponent<CarController>().floatValues[5] / 128;
        distanceY = Car.GetComponent<CarController>().floatValues[6] / 128; // distanceY = distanceZ in unity space
        speedX = Car.GetComponent<CarController>().floatValues[14] / 256;
        speedY = Car.GetComponent<CarController>().floatValues[15] / 256;
        var carPosX = Car.transform.position.x;
        var carPosY = Car.transform.position.y;
        var carPosZ = Car.transform.position.z;
        Vector3 newPosition = new Vector3(distanceX, carPosY, distanceY);
        transform.position = Car.transform.position + newPosition;
    }
}