using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        ReadCSVFile();
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

    void ReadCSVFile()
    {
        // reading file from location
        StreamReader strReader = new StreamReader("DevelopmentData.xlsx - Sheet1.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
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
                        fourthObjectSpeedX = floatData;
                        break;
                    case 16:
                        fourthObjectSpeedY = floatData;
                        break;
                    case 17:
                        yawRate = floatData;
                        break;
                    case 18:
                        timeStamp = floatData;
                        break;
                    default:
                        break;
                }
            }
        }
        rowIndex++;
    }

    void ReadCSVFile2(int lineIndex)
    {
        // reading file from location
        using (StreamReader strReader = new StreamReader("DevelopmentData.xlsx - Sheet1.csv"))
        {
            int currentRowIndex = 0;
            bool endOfFile = false;

            while (!endOfFile)
            {
                string data_string = strReader.ReadLine();

                if (data_string == null)
                {
                    endOfFile = true;
                    break;
                }

                // Increment the current row index
                currentRowIndex++;

                // Check if the current row matches the desired rowIndex
                if (currentRowIndex == lineIndex)
                {
                    // Separate the string by comma and store them in an array
                    var data_values = data_string.Split(",");

                    for (int i = 1; i < data_values.Length; i++)
                    {
                        // Convert string to float
                        float.TryParse(data_values[i], out floatData);
                        Debug.Log(floatData);

                        // Use a switch statement or other logic to assign values based on the column index (i)
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
                                fourthObjectSpeedX = floatData;
                                break;
                            case 16:
                                fourthObjectSpeedY = floatData;
                                break;
                            case 17:
                                yawRate = floatData;
                                break;
                            case 18:
                                timeStamp = floatData;
                                break;
                            default:
                                break;
                        }
                    }
                    break; // Stop reading after finding the desired row
                }
            }
        }
        rowIndex++;
    }

    // void ReadCSVFile3(int lineNumber)
    // {
    //     var lines = File.ReadLines("DevelopmentData.xlsx - Sheet1.csv");
    //     string line = lines.ElementAtOrDefault(lineNumber);
    //     Debug.Log(line);
    // }
    private void incrementStartTime()
    {
        startTime += incrementTime;
        Debug.Log("startTime: " + startTime);
    }


}
