using System;

namespace SprintSubTaskCreator
{
    class Program
    {
        static int[] additionalHours = new int[] { 0, 0, 0, 0 };
        static int[] additionalMinutes = new int[] { 0, 0, 0, 0 };
        static int noOf1Pointers = 0;
        static int noOf2Pointers = 0;
        static int noOf3Pointers = 0;
        static int noOf5Pointers = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter total number of hours: ");
            int totalHours = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter total number of Story points: ");
            int totalStoryPoints = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter total number of 1 pointers: ");
            noOf1Pointers = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter total number of 2 pointers: ");
            noOf2Pointers = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter total number of 3 pointers: ");
            noOf3Pointers = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter total number of 5 pointers: ");
            noOf5Pointers = Int32.Parse(Console.ReadLine());


            int roundedHoursPerStoryPoint = totalHours / totalStoryPoints;
            int extraHours = totalHours % totalStoryPoints;

            int[] hoursStoryPointWise = new int[] { roundedHoursPerStoryPoint * 1, roundedHoursPerStoryPoint * 2, roundedHoursPerStoryPoint *3, roundedHoursPerStoryPoint *5};

            PrintIt(hoursStoryPointWise, noOf1Pointers, noOf2Pointers, noOf3Pointers, noOf5Pointers);

            Console.WriteLine("Your remaining hours = " + extraHours);

            Console.WriteLine("Total 1 pointers = " + noOf1Pointers);

            Console.WriteLine("Total 2 pointers = " + noOf2Pointers);

            Console.WriteLine("Total 3 pointers = " + noOf3Pointers);

            Console.WriteLine("Total 5 pointers = " + noOf5Pointers);

            if (extraHours > 0)
            {
                Console.WriteLine("Want my help to divide the remaining hours? y/n");
                if (Console.ReadLine() == "y")
                {
                    bool repeat = true;
                    while (repeat)
                    {
                        if (DivideExtraHours(extraHours))
                        {
                            PrintIt(hoursStoryPointWise, noOf1Pointers, noOf2Pointers, noOf3Pointers, noOf5Pointers);
                            Console.WriteLine("Want to try again dividing the remaining hours? y/n");
                            if (Console.ReadLine() != "y"){
                                repeat = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Try doing manually then.");
                        }
                    }
                }
            }

            Console.WriteLine("Congrats!! you are ready to start your sprint!!!!");

        }

        public static bool DivideExtraHours(int initialExtraHours)
        {
            double extraHours = initialExtraHours;

            Console.WriteLine("Your remaining hours = " + extraHours);
            Console.WriteLine("How would you like to divide these?");

            Console.WriteLine("Enter additional hours for 1 pointers : ");
            additionalHours[0] = Int32.Parse(Console.ReadLine());
            
            extraHours = extraHours - additionalHours[0]*noOf1Pointers;
            
            Console.WriteLine("Enter additional minutes for 1 pointers : ");
            additionalMinutes[0] = Int32.Parse(Console.ReadLine());
            
            extraHours = extraHours - (((double)additionalMinutes[0] / 60) * noOf1Pointers);
            
            Console.WriteLine("Enter additional hours for 2 pointers : ");
            additionalHours[1] = Int32.Parse(Console.ReadLine());
            
            extraHours = extraHours - additionalHours[1]*noOf2Pointers;
            
            Console.WriteLine("Enter additional minutes for 2 pointers : ");
            additionalMinutes[1] = Int32.Parse(Console.ReadLine());
            
            extraHours = extraHours - (((double)additionalMinutes[1] / 60) * noOf2Pointers);
            
            Console.WriteLine("Enter additional hours for 3 pointers : ");
            additionalHours[2] = Int32.Parse(Console.ReadLine());
            
            extraHours = extraHours - additionalHours[2]*noOf3Pointers;
            
            Console.WriteLine("Enter additional minutes for 3 pointers : ");
            additionalMinutes[2] = Int32.Parse(Console.ReadLine());
            
            extraHours = extraHours - (((double)additionalMinutes[2] / 60) * noOf3Pointers);
            
            Console.WriteLine("Enter additional hours for 5 pointers : ");
            additionalHours[3] = Int32.Parse(Console.ReadLine());
            
            extraHours = extraHours - additionalHours[3]*noOf5Pointers;
            
            Console.WriteLine("Enter additional minutes for 5 pointers : ");
            additionalMinutes[3] = Int32.Parse(Console.ReadLine());
            
            extraHours = extraHours - (((double)additionalMinutes[3] / 60) * noOf5Pointers);
            if (extraHours > 0)
            {
                Console.WriteLine("Hours are still left...Try again? y/n");
                if (Console.ReadLine() == "y")
                {
                    return DivideExtraHours(initialExtraHours);
                }
                return false;
            }
            else if(extraHours == 0)
            {
                Console.WriteLine("Hours completed. Wanna repeat? y/n");
                if (Console.ReadLine() == "y")
                {
                    return DivideExtraHours(initialExtraHours);
                }
                return true;
            }
            else
            {
                Console.WriteLine("Hours exceeded. Try again? y/n");
                if (Console.ReadLine() == "y")
                {
                    return DivideExtraHours(initialExtraHours);
                }
                return false;
            }

        }

        public static void PrintIt(int[] hoursStoryPointWise, int noOf1Pointers, int noOf2Pointers, int noOf3Pointers, int noOf5Pointers)
        {
            Console.WriteLine();

            Console.WriteLine("1 SP: "
                                + noOf1Pointers
                                + " Tickets------Time per ticket = "
                                + (hoursStoryPointWise[0] + additionalHours[0]) 
                                + " h " 
                                + additionalMinutes[0] + " m "
                                + " ------ Total time for 1 SP = "
                                + (hoursStoryPointWise[0] + additionalHours[0] + ((double)additionalMinutes[0]/60)) * noOf1Pointers + "h");
            Console.WriteLine("Analysis: 1 h 0 m");
            Console.WriteLine("Coding: " + (hoursStoryPointWise[0] - 2 + additionalHours[0]) + " h " + (double)additionalMinutes[0] + " m");
            Console.WriteLine("Re-coding: 0 h 15 m");
            Console.WriteLine("Bug Fixing: 0 h 30 m");
            Console.WriteLine("Code Review: 0 h 15 m");

            Console.WriteLine("2 SP: "
                                + noOf2Pointers
                                + " Tickets------Time per ticket = "
                                + (hoursStoryPointWise[1] + additionalHours[1])
                                + " h "
                                + additionalMinutes[1] + " m "
                                + " ------ Total time for 2 SP = "
                                + (hoursStoryPointWise[1] + additionalHours[1] + ((double)additionalMinutes[1] / 60)) * noOf2Pointers + "h");
            Console.WriteLine("Analysis: 2 h 0 m");
            Console.WriteLine("Coding: " + (hoursStoryPointWise[1] - 3 + additionalHours[1]) + " h " + (double)additionalMinutes[1] + " m");
            Console.WriteLine("Re-coding: 0 h 15 m");
            Console.WriteLine("Bug Fixing: 0 h 30 m");
            Console.WriteLine("Code Review: 0 h 15 m");

            Console.WriteLine("3 SP: "
                                + noOf3Pointers
                                + " Tickets------Time per ticket = "
                                + (hoursStoryPointWise[2] + additionalHours[2])
                                + " h "
                                + additionalMinutes[2] + " m "
                                + " ------ Total time for 3 SP = "
                                + (hoursStoryPointWise[2] + additionalHours[2] + ((double)additionalMinutes[2] / 60)) * noOf3Pointers + "h");
            Console.WriteLine("Analysis: 2 h 0 m");
            Console.WriteLine("Coding: " + (hoursStoryPointWise[2] - 3 + additionalHours[2]) + " h " + (double)additionalMinutes[2] + " m");
            Console.WriteLine("Re-coding: 0 h 15 m");
            Console.WriteLine("Bug Fixing: 0 h 30 m");
            Console.WriteLine("Code Review: 0 h 15 m");

            Console.WriteLine("5 SP: "
                                + noOf5Pointers
                                + " Tickets------Time per ticket = "
                                + (hoursStoryPointWise[3] + additionalHours[3])
                                + " h "
                                + additionalMinutes[3] + " m "
                                + " ------ Total time for 5 SP = "
                                + (hoursStoryPointWise[3] + additionalHours[3] + ((double)additionalMinutes[3] / 60)) * noOf5Pointers + "h");
            Console.WriteLine("Analysis: 3 h 0 m");
            Console.WriteLine("Coding: " + (hoursStoryPointWise[3] - 4 + additionalHours[3]) + " h " + (double)additionalMinutes[3] + " m");
            Console.WriteLine("Re-coding: 0 h 15 m");
            Console.WriteLine("Bug Fixing: 0 h 30 m");
            Console.WriteLine("Code Review: 0 h 15 m");

            Console.WriteLine();
        }
    }
}
