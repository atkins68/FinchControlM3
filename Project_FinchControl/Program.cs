﻿using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu, adding and updating lights, sounds,
    //              and movement              
    // Application Type: Console
    // Author: Atkinson, Nathan
    // Dated Created: 2/23/2020
    // Last Modified: 3/4/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch myFinch = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(myFinch);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(myFinch);
                        break;

                    case "c":
                        DisplayDataRecorderMenuScreen(myFinch);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(myFinch);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(myFinch);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayLightAndSound(Finch myFinch)
        {
            int userValue;
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing and sound talent!");
            DisplayContinuePrompt();
            for (int lightSoundLevel = 255; lightSoundLevel > 0; lightSoundLevel--)
            {
                myFinch.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                myFinch.noteOn(lightSoundLevel * 100);
                myFinch.wait(10);
            }

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                myFinch.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                myFinch.noteOn(lightSoundLevel * 100);
                myFinch.wait(100);
                myFinch.setLED(0, 0, 0);
                myFinch.noteOff();
            }

            Console.WriteLine("Please select a sound level");
            Console.Write("Enter a numeric value for sound: ");
            userValue = Convert.ToInt32(Console.ReadLine());
            myFinch.noteOn(userValue);
            myFinch.wait(5000);
            myFinch.noteOff();




            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dance                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayDance(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now show off its moves!");
            DisplayContinuePrompt();

            myFinch.setMotors(255, 0);
            myFinch.wait(2000);
            myFinch.setMotors(0, 255);
            myFinch.wait(2000);
            myFinch.setMotors(0, 0);






            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mixing It Up                  *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayMixingItUp(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("\tThe Finch robot will now show off a variety of talents!");
            DisplayContinuePrompt();

            myFinch.noteOn(261);
            myFinch.wait(1000);
            myFinch.setMotors(200, 200);
            myFinch.setLED(50, 50, 50);
            myFinch.wait(1000);
            myFinch.noteOff();
            myFinch.setLED(0, 0, 0);
            myFinch.setMotors(0, 0);
            myFinch.noteOn(500);
            myFinch.wait(1000);
            myFinch.setMotors(-200, -200);
            myFinch.setLED(50, 50, 50);
            myFinch.wait(1000);
            myFinch.noteOff();
            myFinch.setLED(0, 0, 0);
            myFinch.setMotors(0, 0);


            DisplayMenuPrompt("Talent Show Menu");
        }
        #endregion

        #region DATA RECORDER

        static void DisplayDataRecorderMenuScreen(Finch myfinch)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            Finch myFinch = new Finch();


            

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, myfinch);
                        break;

                    case "d":
                        DataRecorderDisplayGetData(temperatures);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        static void DataRecorderDisplayGetData(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();

        }

        static void DataRecorderDisplayTable(double[] temperatures)
        {
            //
            // display table headers
            //
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15) 
                
            //"Average Temp".PadLeft(15)
                );
            Console.WriteLine(
                "...........".PadLeft(15) +
                "...........".PadLeft(15) 
               
            // "...........".PadLeft(15)
                );

            //
            // display table data
            //
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    temperatures[index].ToString("n2").PadLeft(15)
                    );

            }
        }

        /// <summary>
        /// Getting Data
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="myfinch"></param>
        /// <returns>collected data</returns>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch myfinch)
        {
            double[] temperatures = new double[numberOfDataPoints];
            
            DisplayScreenHeader("Get Data");

            Console.WriteLine($"Number of data points: {numberOfDataPoints}");
            Console.WriteLine($"Data point frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe Finch Robot is ready to begin recording the temperature data.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = myfinch.getTemperature();
                Console.WriteLine($"Reading {index + 1}: {temperatures[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                myfinch.wait(waitInSeconds);
            }

            DisplayContinuePrompt();
            DisplayScreenHeader("Get Data");

            Console.WriteLine();
            Console.WriteLine("\tTable of Temperatures");
            Console.WriteLine();
            DataRecorderDisplayTable(temperatures);



            DisplayContinuePrompt();

            return temperatures;
        }




        /// <summary>
        /// Get frequency of data points from user
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            string userResponse;

            DisplayScreenHeader("Data Point Frequency");

            Console.Write("\tFrequency of data points: ");
            userResponse = Console.ReadLine();
           
            
            //validate input

            if (!double.TryParse(userResponse, out dataPointFrequency))
            {
                Console.WriteLine("\tPlease enter a number");
            }
           
            
           
            double.TryParse(userResponse, out dataPointFrequency);

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        /// <summary>
        /// Get the number of data points from user
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;

            DisplayScreenHeader("Number of Data Points");

            Console.Write("\tNumber of data points: ");
            userResponse = Console.ReadLine();
          
            
            //validating input

            if (!int.TryParse(userResponse, out numberOfDataPoints))
            {
                Console.WriteLine("\tPlease enter a number");
            }
            

            int.TryParse(userResponse, out numberOfDataPoints);

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch myFinch)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            myFinch.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="myFinch">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch myFinch)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = myFinch.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            myFinch.setLED(0, 0, 0);
            myFinch.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}