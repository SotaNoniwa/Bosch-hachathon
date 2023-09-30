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

int main()
{
    ReadCSVFile();
}