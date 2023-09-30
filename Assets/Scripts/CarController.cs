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
    private float floatData;
    private float speed = 5.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private float firstObjectDistanceX;
    private float firstObjectDistanceY;
    private float secondObjectDistanceX;
    private float secondObjectDistanceY;
    private float thirdObjectDistanceX;
    private float thirdObjectDistanceY;
    private float fourthObjectDistanceX;
    private float fourthObjectDistanceY;
    private float vehicleSpeed; // duplicate to speed variable
    private float firstObjectSpeedX;
    private float firstObjectSpeedY;
    private float secondObjectSpeedX;
    private float secondObjectSpeedY;
    private float thirdObjectSpeedY;
    private float thirdObjectSpeedX;
    private float fourthObjectSpeedX;
    private float fourthObjectSpeedY;
    private float yawRate;
    private float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        // ReadCSVFile();
        ReadCSVLine(2);
        InvokeRepeating("incrementStartTime", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        // ReadCSVFile();
    }


    public static void ReadCSVLine(int lineNumber)
    {
        string filePath = "DevelopmentData.xlsx - Sheet1.csv";

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lineNumber >= 0 && lineNumber < lines.Length)
            {
                string lineToRead = lines[lineNumber];
                Debug.Log("Line " + lineNumber + ": " + lineToRead);
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

            // separate string by conma and store them to an array
            var data_values = data_string.Split(",");

            // This i represents the index of column
            for (int i = 1; i < data_values.Length; i++)
            {
                // convert string to float
                float.TryParse(data_values[i], out floatData);
                Debug.Log(floatData);

                switch (i)
                {
                    case 1:
                        firstObjectDistanceX = floatData;
                        break;
                    case 2:
                        firstObjectDistanceY = floatData;
                        break;
                    case 3:
                        secondObjectDistanceX = floatData;
                        break;
                    case 4:
                        secondObjectDistanceY = floatData;
                        break;
                    case 5:
                        thirdObjectDistanceX = floatData;
                        break;
                    case 6:
                        thirdObjectDistanceY = floatData;
                        break;
                    case 7:
                        fourthObjectDistanceX = floatData;
                        break;
                    case 8:
                        fourthObjectDistanceY = floatData;
                        break;
                    case 9:
                        vehicleSpeed = floatData;
                        break;
                    case 10:
                        firstObjectSpeedX = floatData;
                        break;
                    case 11:
                        firstObjectSpeedY = floatData;
                        break;
                    case 12:
                        secondObjectSpeedX = floatData;
                        break;
                    case 13:
                        secondObjectSpeedY = floatData;
                        break;
                    case 14:
                        thirdObjectSpeedX = floatData;
                        break;
                    case 15:
                        thirdObjectSpeedY = floatData;
                        break;
                    case 16:
                        fourthObjectSpeedX = floatData;
                        break;
                    case 17:
                        fourthObjectSpeedY = floatData;
                        break;
                    case 18:
                        yawRate = floatData;
                        break;
                    case 19:
                        timeStamp = floatData;
                        break;
                    default:
                        break;
                }

                if (startTime >= timeStamp)
                {
                    Debug.Log("timeStamp: " + timeStamp);
                    Debug.Log("timer: " + startTime);
                    break;
                }
                Debug.Log("yawRate: " + yawRate);
                // Debug.Log("timeStamp: " + timeStamp);
            }
        }
        rowIndex++;
    }

    private void incrementStartTime()
    {
        startTime += incrementTime;
        // Debug.Log("startTime: " + startTime);
    }


}
