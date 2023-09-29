using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CarController : MonoBehaviour
{
    private float startTime = 33.2415f;
    private float incrementTime = 0.05f;
    public float delayAmout;
    private float speed = 5.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        ReadCSVFile();
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= delayAmout)
        {
            startTime = 0f;
            startTime
        }

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }

    void ReadCSVFile()
    {
        // reading file from location
        StreamReader strReader = new StreamReader("DevelopmentData.xlsx - Sheet1.csv");
        bool endOfFile = false;

        while (!endOfFile)
        {
            string data_string = strReader.ReadLine();

            if (data_string == null)
            {
                endOfFile = true;
                break;
            }

            // string to variable
            var data_values = data_string.Split(",");

            // for (int i = 1; i < data_values.Length; i++)
            // {
            //     Debug.Log("Value: " + data_values[i].ToString());
            // }
        }
    }
}
