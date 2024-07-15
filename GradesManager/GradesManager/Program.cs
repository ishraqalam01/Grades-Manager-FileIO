//Name: Ishraq Alam
//Date: April 30, 2024
//Title: A7IshraqAlam
//Purpose: To read data from 2 files, then display it through a menu. 
using System;
using System.Collections.Generic;
using System.IO; //enables file input / output
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace A7IshraqAlam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Variable Declaration and Input
            StreamReader re = File.OpenText("names.txt"); //open an existing file
            string strInput = null; //string to read a line from file
            string strUser; //Yogurt container for getting input
            string[] strUnsortedName; //Unsorted original array of names 
            int[] intUnsortedAge; //Unsorted original array of ages 
            int[] intUnsortedGrade; //Unsorted original array of grades 
            string[] strSortedName; //Sorted array of names 
            int[] intSortedAge; //Sorted array of ages 
            int[] intSortedGrade; //Sorted array of grades 
            int intTempGrade; //Temporary grade used when bubble sorting 
            string strTempName; //Temporary name used when bubble sorting 
            int intTempAge; //Temporary age used when bubble sorting 
            int intSum = 0; //Used for calculating average 
            double dblAverageGrade = 0; //Displaying average 
            int intMedianLocation; //Shows the median location 
            double dblMedianGrade;  //Displays the median grade 
            double dblAverageAge = 0; //Displays the average of the ages 
            string strEnteredName; //The name user enters when adding a new student 
            int intEnteredAge; //Age user enters when adding new student 
            int intEnteredGrade; //Grade user enters when adding new student 
            string[] strTempAddName; //Storing new student temporarily
            int[] intTempAddAge; //Storing new age temporarily 
            int[] intTempAddGrade; //Storing new grade temporarily 
            string strFileName; //The custom name of file user wants to save to 

            int intMenuOption; //The option from menu user wants to do 


            int intArraySize = 0; //To set the size of the array, this variable will be used to find how many inputs there are in the file 

            while ((strInput = re.ReadLine()) != null) //Loop continues reading that line until it reaches null (nothing to read)
            {
                intArraySize++; //array size increases 
            }

            re.Close(); //Closes the text file when it is done counting how many entries there are 


            //Sets sizes for all of the arrays 
            strUnsortedName = new string[intArraySize];
            intUnsortedAge = new int[intArraySize];
            intUnsortedGrade = new int[intArraySize];

            re = File.OpenText("names.txt"); //Reopens the file again 

            for (int i = 0; i < strUnsortedName.Length; i++) //Goes through all lines in the file
            {
                strInput = re.ReadLine(); //Reads the input from the line in the txt file
                strUnsortedName[i] = strInput.Substring(0, strInput.IndexOf(","));


                strInput = strInput.Substring(strInput.IndexOf(",") + 1, strInput.Length - strInput.IndexOf(",") - 1); //Finds the input AFTER the comma by starting at the comma and then deleting the text before the comma in substring.
                intUnsortedAge[i] = Int32.Parse(strInput); //Converts string to int

            }

            re.Close(); //Closes txt file

            StreamReader se = File.OpenText("grades.txt"); //Opens and reads the grades.txt file to get the grades 

            se = File.OpenText("grades.txt");

            for (int i = 0; i < intUnsortedGrade.Length; i++) //Goes through all lines in the text file 
            {
                strInput = se.ReadLine(); //Reads input line by line and turns into int
                intUnsortedGrade[i] = Int32.Parse(strInput);
            }

            se.Close(); //Closes grades.txt file 

            //Resets the size of sorted arrays 
            strSortedName = new string[strUnsortedName.Length];
            intSortedAge = new int[intUnsortedAge.Length];
            intSortedGrade = new int[intUnsortedGrade.Length];

            //Copies values from unsorted arrays into sorted arrays 
            for (int i = 0; i < strUnsortedName.Length; i++)
            {
                strSortedName[i] = strUnsortedName[i];
                intSortedAge[i] = intUnsortedAge[i];
                intSortedGrade[i] = intUnsortedGrade[i];

            }

            //Process and Output
            try
            {


                while (true)
                {


                    //Menu
                    Console.WriteLine(" ");
                    Console.Clear();
                    Console.WriteLine(" ");
                    Console.WriteLine("What would you like to do from the menu? Please choose the number corresponding to your decision. ");
                    Console.WriteLine("1. Show Unsorted List");
                    Console.WriteLine("2. Show Sorted List by Grade (HIGH - LOW)");
                    Console.WriteLine("3. Show Sorted List by Name (A-Z)");
                    Console.WriteLine("4. Student with the Highest Grade");
                    Console.WriteLine("5. Student with the Lowest Grade");
                    Console.WriteLine("6. Average Grade");
                    Console.WriteLine("7. Median Grade");
                    Console.WriteLine("8. Average Age");
                    Console.WriteLine("9. Add a new student");
                    Console.WriteLine("10. Save to a new file");
                    Console.WriteLine("11. Exit");
                    Console.WriteLine(" ");
                    strUser = Console.ReadLine();
                    intMenuOption = Int32.Parse(strUser);

                    if (intMenuOption == 1) //Unsorted list 
                    {
                        try
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("Name          |    Age          |   Grade");
                            Console.WriteLine("------------------------------------------");
                            for (int i = 0; i < strUnsortedName.Length; i++)
                            {

                                Console.WriteLine(String.Format("{0, -12}  | {1, -12}    | {2, 5}", strUnsortedName[i], intUnsortedAge[i], intUnsortedGrade[i])); //Outputs unsorted array in neat table 
                            }

                            Clear();

                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }

                    else if (intMenuOption == 2) //Sorted by HIGH - LOW grades
                    {
                        try
                        {
                            //Sets size of array for sorted arrays 
                            strSortedName = new string[strUnsortedName.Length];
                            intSortedAge = new int[intUnsortedAge.Length];
                            intSortedGrade = new int[intUnsortedGrade.Length];

                            for (int i = 0; i < strUnsortedName.Length; i++) //Copies information into sorted arrays from unsorted arrays 
                            {
                                strSortedName[i] = strUnsortedName[i];
                                intSortedAge[i] = intUnsortedAge[i];
                                intSortedGrade[i] = intUnsortedGrade[i];

                            }

                            //Applies bubble sort to rearrange by grade 
                            for (int i = 0; i < strUnsortedName.Length; i++)
                            {
                                for (int j = 0; j < strUnsortedName.Length - 1; j++)
                                {
                                    if (intSortedGrade[j] < intSortedGrade[j + 1]) //if the grade is smaller than the next grade, it changes the location 
                                    {
                                        //Changes location of grade 
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;

                                        //Changes name and age following the grade 
                                        strTempName = strSortedName[j];
                                        strSortedName[j] = strSortedName[j + 1];
                                        strSortedName[j + 1] = strTempName;

                                        intTempAge = intSortedAge[j];
                                        intSortedAge[j] = intSortedAge[j + 1];
                                        intSortedAge[j + 1] = intTempAge;

                                    }
                                }
                            }

                            //Outputs the information into formatted table 
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("Name          |    Age          |   Grade");
                            Console.WriteLine("------------------------------------------");
                            for (int i = 0; i < strUnsortedName.Length; i++)
                            {

                                Console.WriteLine(String.Format("{0, -12}  | {1, -12}    | {2, 5}", strSortedName[i], intSortedAge[i], intSortedGrade[i]));
                            }

                            Clear();

                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }

                    else if (intMenuOption == 3) //Sorted List by Name
                    {
                        try
                        {



                            //Sets values for array size for sorted arrays 
                            strSortedName = new string[strUnsortedName.Length];
                            intSortedAge = new int[intUnsortedAge.Length];
                            intSortedGrade = new int[intUnsortedGrade.Length];

                            //Copies values into sorted arrays for unsorted arrays 
                            for (int i = 0; i < strUnsortedName.Length; i++)
                            {
                                strSortedName[i] = strUnsortedName[i];
                                intSortedAge[i] = intUnsortedAge[i];
                                intSortedGrade[i] = intUnsortedGrade[i];

                            }

                            //Applies bubble sort to rearrange array 
                            for (int i = 0; i < strUnsortedName.Length; i++) //Loops until all values in array complete 
                            {
                                for (int j = 0; j < strUnsortedName.Length - 1; j++) //loops all except last array value 
                                {
                                    if (strSortedName[j].CompareTo(strSortedName[j + 1]) > 0) //If the name values are different 
                                    {
                                        //Rearranges name so that it follows first name 
                                        strTempName = strSortedName[j];
                                        strSortedName[j] = strSortedName[j + 1];
                                        strSortedName[j + 1] = strTempName;

                                        //Rearranges age following name 
                                        intTempAge = intSortedAge[j];
                                        intSortedAge[j] = intSortedAge[j + 1];
                                        intSortedAge[j + 1] = intTempAge;

                                        //Rearranges grade so that it follows first name 
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;




                                    }
                                }
                            }

                            //Outputs the information into formatted table 
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("Name          |    Age          |   Grade");
                            Console.WriteLine("------------------------------------------");
                            for (int i = 0; i < strUnsortedName.Length; i++)
                            {

                                Console.WriteLine(String.Format("{0, -12}  | {1, -12}    | {2, 5}", strSortedName[i], intSortedAge[i], intSortedGrade[i]));
                            }

                            Clear();

                        }

                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }

                    }


                    else if (intMenuOption == 4) //Student with highest grade 
                    {
                        try
                        {



                            //Sets size of array for sorted arrays 
                            strSortedName = new string[strUnsortedName.Length];
                            intSortedAge = new int[intUnsortedAge.Length];
                            intSortedGrade = new int[intUnsortedGrade.Length];

                            for (int i = 0; i < strUnsortedName.Length; i++) //Copies information into sorted arrays from unsorted arrays 
                            {
                                strSortedName[i] = strUnsortedName[i];
                                intSortedAge[i] = intUnsortedAge[i];
                                intSortedGrade[i] = intUnsortedGrade[i];

                            }

                            //Applies bubble sort to rearrange by grade 
                            for (int i = 0; i < strUnsortedName.Length; i++)
                            {
                                for (int j = 0; j < strUnsortedName.Length - 1; j++)
                                {
                                    if (intSortedGrade[j] < intSortedGrade[j + 1]) //if the grade is smaller than the next grade, it changes the location 
                                    {
                                        //Changes location of grade 
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;

                                        //Changes name and age following the grade 
                                        strTempName = strSortedName[j];
                                        strSortedName[j] = strSortedName[j + 1];
                                        strSortedName[j + 1] = strTempName;

                                        intTempAge = intSortedAge[j];
                                        intSortedAge[j] = intSortedAge[j + 1];
                                        intSortedAge[j + 1] = intTempAge;

                                    }
                                }
                            }

                            Console.WriteLine("The student with the highest grade of " + intSortedGrade[0] + "% is " + strSortedName[0] + " who is " + intSortedAge[0] + " years old."); //Outputs the highest grade 

                            Clear();
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    else if (intMenuOption == 5) //Student with lowest grade 
                    {
                        try
                        {



                            //Sets size of array for sorted arrays 
                            strSortedName = new string[strUnsortedName.Length];
                            intSortedAge = new int[intUnsortedAge.Length];
                            intSortedGrade = new int[intUnsortedGrade.Length];

                            for (int i = 0; i < strUnsortedName.Length; i++) //Copies information into sorted arrays from unsorted arrays 
                            {
                                strSortedName[i] = strUnsortedName[i];
                                intSortedAge[i] = intUnsortedAge[i];
                                intSortedGrade[i] = intUnsortedGrade[i];

                            }

                            //Applies bubble sort to rearrange by grade 
                            for (int i = 0; i < strUnsortedName.Length; i++)
                            {
                                for (int j = 0; j < strUnsortedName.Length - 1; j++)
                                {
                                    if (intSortedGrade[j] < intSortedGrade[j + 1]) //if the grade is smaller than the next grade, it changes the location 
                                    {
                                        //Changes location of grade 
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;

                                        //Changes name and age following the grade 
                                        strTempName = strSortedName[j];
                                        strSortedName[j] = strSortedName[j + 1];
                                        strSortedName[j + 1] = strTempName;

                                        intTempAge = intSortedAge[j];
                                        intSortedAge[j] = intSortedAge[j + 1];
                                        intSortedAge[j + 1] = intTempAge;

                                    }
                                }
                            }

                            Console.WriteLine("The student with the lowest grade of " + intSortedGrade[intSortedGrade.Length - 1] + "% is " + strSortedName[strSortedName.Length - 1] + " who is " + intSortedAge[intSortedAge.Length - 1] + " years old."); //Outputs lowest grade 

                            Clear();

                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }


                    else if (intMenuOption == 6) //Average grade 
                    {

                        try
                        {


                            for (int i = 0; i < intUnsortedGrade.Length; i++) //Adds all the grades together using intSum as a counter in a loop 
                            {
                                intSum = intSum + intUnsortedGrade[i];
                            }

                            dblAverageGrade = (double)intSum / (double)intUnsortedGrade.Length; //Calculates the average, casting values as double temporarily 
                            dblAverageGrade = Math.Round(dblAverageGrade, 2); //Rounds average to 2 decimals 
                            intSum = 0; //Resets sum to 0 if user changes values and tries to find average again 

                            Console.WriteLine("The average of the grades is " + dblAverageGrade + "%"); //Displays average 

                            Clear();

                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    else if (intMenuOption == 7) //Median grade 
                    {

                        try
                        {



                            //Sets size of array for sorted arrays 
                            strSortedName = new string[strUnsortedName.Length];
                            intSortedAge = new int[intUnsortedAge.Length];
                            intSortedGrade = new int[intUnsortedGrade.Length];

                            for (int i = 0; i < strUnsortedName.Length; i++) //Copies information into sorted arrays from unsorted arrays 
                            {
                                strSortedName[i] = strUnsortedName[i];
                                intSortedAge[i] = intUnsortedAge[i];
                                intSortedGrade[i] = intUnsortedGrade[i];

                            }

                            //Applies bubble sort to rearrange by grade 
                            for (int i = 0; i < strUnsortedName.Length; i++)
                            {
                                for (int j = 0; j < strUnsortedName.Length - 1; j++)
                                {
                                    if (intSortedGrade[j] < intSortedGrade[j + 1]) //if the grade is smaller than the next grade, it changes the location 
                                    {
                                        //Changes location of grade 
                                        intTempGrade = intSortedGrade[j];
                                        intSortedGrade[j] = intSortedGrade[j + 1];
                                        intSortedGrade[j + 1] = intTempGrade;

                                        //Changes name and age following the grade 
                                        strTempName = strSortedName[j];
                                        strSortedName[j] = strSortedName[j + 1];
                                        strSortedName[j + 1] = strTempName;

                                        intTempAge = intSortedAge[j];
                                        intSortedAge[j] = intSortedAge[j + 1];
                                        intSortedAge[j + 1] = intTempAge;

                                    }
                                }
                            }


                            if (intSortedGrade.Length % 2 == 0) //If there are an even number of entries in the array
                            {
                                intMedianLocation = intSortedGrade.Length / 2; //The location of one of the median locations is the number of values divided by 2

                                dblMedianGrade = (intSortedGrade[intMedianLocation - 1] + intSortedGrade[intMedianLocation]) / 2; //The other location is 1 less than that (since location count starts at 0)
                                dblMedianGrade = Math.Round(dblMedianGrade, 2); //Calculates median by adding 2 middle values and dividing by 2, then rounding to 2 decimals 

                                Console.WriteLine("The median grade is " + dblMedianGrade + "%"); //Outputs median and the students who have them. 
                                Console.WriteLine("Since there are two students, the median is an average of the grades of " + strSortedName[intMedianLocation - 1] + " and " + strSortedName[intMedianLocation]);

                            }

                            else //If there are an odd number of entries in the array 
                            {
                                intMedianLocation = (intSortedGrade.Length + 1) / 2; //The median location would be 1 less than 1 added to the length then divided by 2 (starts at location 0)

                                dblMedianGrade = intSortedGrade[intMedianLocation - 1];

                                Console.WriteLine("The median grade is " + dblMedianGrade + "%"); //Displays the median and the student who has it 
                                Console.WriteLine("This grade belongs to " + strSortedName[intMedianLocation - 1]);
                            }

                            Clear();
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    else if (intMenuOption == 8) //Average age
                    {

                        try
                        {



                            for (int i = 0; i < intUnsortedAge.Length; i++) //Adds all the ages together using intSum as a counter in a loop 
                            {
                                intSum = intSum + intUnsortedAge[i];
                            }

                            dblAverageAge = (double)intSum / (double)intUnsortedAge.Length; //Calculates the average, casting values as double temporarily 
                            dblAverageAge = Math.Round(dblAverageAge, 2); //Rounds average to 2 decimals 
                            intSum = 0; //Resets sum to 0 if user changes values and tries to find average again 

                            Console.WriteLine("The average of the ages is " + dblAverageAge + "years"); //Displays average 

                            Clear();
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }


                    else if (intMenuOption == 9)
                    {
                        try
                        {


                            //Asks user for name, age and grade of new added student 
                            Console.WriteLine("What is the name of the student you would like to add?");
                            strUser = Console.ReadLine();
                            strEnteredName = strUser;

                            Console.WriteLine("What is the age of the student you would like to add?");
                            strUser = Console.ReadLine();
                            intEnteredAge = Int32.Parse(strUser);

                            Console.WriteLine("What is the grade of the student you would like to add?");
                            strUser = Console.ReadLine();
                            intEnteredGrade = Int32.Parse(strUser);

                            //Adding Name
                            strTempAddName = new string[strUnsortedName.Length + 1]; //Set size of temp array to 1 more 

                            for (int i = 0; i < strTempAddName.Length - 1; i++) //Copies information into new array 
                            {
                                strTempAddName[i] = strUnsortedName[i];
                            }

                            strTempAddName[strTempAddName.Length - 1] = strEnteredName; //The last value in temp array is set to the new name the user enters 

                            strUnsortedName = new string[strTempAddName.Length]; //Resets size of original array

                            for (int i = 0; i < strUnsortedName.Length; i++) //Copies values from temp array into original resized array 
                            {
                                strUnsortedName[i] = strTempAddName[i];
                            }

                            //Adding Age
                            intTempAddAge = new int[intUnsortedAge.Length + 1]; //Set size of temp array to 1 more 

                            for (int i = 0; i < intTempAddAge.Length - 1; i++) //Copies information into new array 

                            {
                                intTempAddAge[i] = intUnsortedAge[i];
                            }

                            intTempAddAge[intTempAddAge.Length - 1] = intEnteredAge; //The last value in temp array is set to the new age the user enters 

                            intUnsortedAge = new int[intTempAddAge.Length]; //Resets size of original array

                            for (int i = 0; i < intUnsortedAge.Length; i++) //Copies information into new array 
                            {
                                intUnsortedAge[i] = intTempAddAge[i];
                            }

                            //Adding Grade
                            intTempAddGrade = new int[intUnsortedGrade.Length + 1]; //Set size of temp array to 1 more 

                            for (int i = 0; i < intTempAddGrade.Length - 1; i++) //Copies information into new array 

                            {
                                intTempAddGrade[i] = intUnsortedGrade[i];
                            }

                            intTempAddGrade[intTempAddGrade.Length - 1] = intEnteredGrade; //The last value in temp array is set to the new grade the user enters 

                            intUnsortedGrade = new int[intTempAddGrade.Length]; //Resets size of original array

                            for (int i = 0; i < intUnsortedGrade.Length; i++) //Copies information into new array 
                            {
                                intUnsortedGrade[i] = intTempAddGrade[i];
                            }

                            Console.WriteLine("Successfully added!");

                            Clear();
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    else if (intMenuOption == 10) //Save as new txt file
                    {
                        try
                        {



                            while (true)
                            {
                                Console.WriteLine("What would you like your new, saved file to be called? NOTE: It cannot be called names.txt or grades.txt. Please include .txt at the end of the file name. "); //Asks user for new file name
                                strUser = Console.ReadLine();
                                strFileName = strUser;

                                if (strFileName != "names.txt" || strFileName != "grades.txt") //File can't be names.txt or grades.txt 
                                {
                                    FileInfo t = new FileInfo(strFileName); //Creates new file with the name the user entered 
                                    StreamWriter FileText = t.CreateText(); //Enables writing on new file 

                                    for (int i = 0; i < strSortedName.Length; i++) //Writes values into txt file so that it is sorted. If user did not touch menu, the sorted should be the same as unsorted. 
                                    {
                                        FileText.WriteLine(strSortedName[i] + "," + intSortedAge[i] + "," + intSortedGrade[i]);

                                    }

                                    FileText.Close(); //Closes the file

                                    Console.WriteLine("File has been created! "); //Informs user file was created on system console. 

                                    break;
                                }

                                else
                                {
                                    Console.WriteLine("Please choose a different file name."); //if file name is names.txt or grades.txt
                                    Console.WriteLine(" ");
                                }

                            }

                            Clear();

                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }


                    else if (intMenuOption == 11) //Exits menu and program
                    {
                        break;
                    }


                    else //If invalid menu option is entered 
                    {
                        Console.WriteLine("That is not an option from the menu.");
                    }

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey(); //Ends program 

        }

        public static void Clear() //For cleaner interface 
        {
            Console.WriteLine(" ");
            Console.WriteLine("Please type anything to go back to the menu.");
            Console.ReadKey();
        }
    }
}
