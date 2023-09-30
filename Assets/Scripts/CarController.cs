using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CarController : MonoBehaviour
{
    private float startTime = 33.2415f;
    private float incrementTime = 0.05f;
    private int numOfRows = 428;
    private int rowIndex = 1;
    private float speed = 5.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    float[] floatValues = new float[20];

    // Start is called before the first frame update
    void Start()
    {
        // ReadCSVFile();
        ReadCSVLine(2);
        InvokeRepeating("incrementStartTime", 1.0f, 1.0f);

        for (int i = 0; i < floatValues.Length; i++)
        {
            Debug.Log(floatValues[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * floatValues[1]);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        // ReadCSVFile();
    }

    public void ReadCSVLine(int lineNumber)
    {
        string filePath = "DevelopmentData.xlsx - Sheet1.csv";

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lineNumber >= 0 && lineNumber < lines.Length)
            {
                string lineToRead = lines[lineNumber];
                string[] values = lineToRead.Split(',');

                // float[] floatValues = new float[values.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    if (float.TryParse(values[i], out float floatValue))
                    {
                        floatValues[i] = floatValue;
                    }
                    else
                    {
                        Debug.LogError("Error converting value to float at index " + i);
                        // Handle the error (e.g., provide a default value or skip the value)
                    }
                }

                // Now you have an array of float values
                // Do something with floatValues
                // for (int i = 0; i < floatValues.Length; i++)
                // {
                //     Debug.Log("Float value at index " + i + ": " + floatValues[i]);
                // }
            }
            else
            {
                Debug.LogError("Invalid line number: " + lineNumber);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }

    private void incrementStartTime()
    {
        startTime += incrementTime;
        // Debug.Log("startTime: " + startTime);
    }


}
