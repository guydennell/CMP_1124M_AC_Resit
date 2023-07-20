namespace CMP1124M_A_C_AO1
{
    public class Testing
    {
        public Testing()
        {
            while (true)
            {
            private static readonly string directory = @"..\..\..\Roadfiles\";

            // Initialising all 6 roads
            public static readonly List<int> Share_1_256 = InitShare("Share_1_256.txt");
            public static readonly List<int> Share_1_2048 = InitShare("Share_1_2048.txt");
            public static readonly List<int> Share_2_256 = InitShare("Share_2_256.txt");
            public static readonly List<int> Share_2_2048 = InitShare("Share_2_2048.txt");
            public static readonly List<int> Share_3_256 = InitShare("Share_3_256.txt");
            public static readonly List<int> Share_3_2048 = InitShare("Share_3_2048.txt");
    
            public static List<int> InitShare(string filepath)
            {
                /*
                 * InitShare function
                 * Reads text file of given filepath and converts
                 * to an int array
                 */
                string[] lines = File.ReadAllLines(directory + filepath);
                int[] road = lines.Select(int.Parse).ToArray();
    
                List<int> ShareList = new();
                for (int i = 0; i < road.Length; i++)
                {
                    roadList.Add(Share[i]);
                }
                return ShareList;
            } 
        }
    }

                Console.WriteLine(); //gives the user the functionality to do everything the program should be able to do
                Console.WriteLine("Pick a functionality: ");
                Console.WriteLine("a) Functionality 1 - Read Files to Arrays");
                Console.WriteLine("b) Functionality 2 - Display Ascending and Descending values (256)");
                Console.WriteLine("c) Functionality 3 & 4 - Search Array for a value (displays closest value if not found)");
                Console.WriteLine("d) Functionality 5 - Repeat functionalities 2 & 4 with Share (2048)");
                Console.WriteLine("e) Functionality 6 - Repeat functionalities 2 & 4 with Merged Share (256)");
                Console.WriteLine("f) Functionality 7 - Repeat functionalities 2 & 4 with Merged Share (2048)");
                Console.WriteLine();
                string answer = Console.ReadLine();
                answer = answer.ToUpper();
                switch (answer) //runs the chosen program
                {
                    case "A":
                        Console.WriteLine("Already Complete!");
                        break;
                    case "B":
                        Functionality2(Share_1_256, Share_2_256, Share_3_256);
                        break;
                    case "C":
                        Console.Write("Pick a value to search for: ");
                        int value = Convert.ToInt16(Console.ReadLine());
                        Functionality3(Sorts.BubbleSortAscending(Share_1_256), value);
                        break;
                    case "D":
                        Functionality5(Share_1_2048, Share_2_2048, Share_3_2048);
                        break;
                    case "E":
                        Functionality6(Share_1_256, Share_3_256, 10);
                        break;
                    case "F":
                        Functionality6(Share_1_2048, Share_3_2048, 50);
                        break;
                    default:
                        Console.WriteLine("Please Enter A Valid Option!");
                        break;
                }

            }
        }

        public static void Functionality2(int[] list1, int[] list2, int[] list3)
        {
            Console.WriteLine("Share_1_256:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list1), 10);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list1), 10);

            Console.WriteLine("Share_2_256:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list2), 10);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list2), 10);

            Console.WriteLine("Share_3_256:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list3), 10);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list3), 10);
        } //runs the 2nd functionality of the assessment

        public static void Functionality3(int[] list, int key)
        {
            if (Search.LinearSearch(list, key, false).Length > 0)
            {
                PrintList(Search.LinearSearch(list, key, true), 1);
                return;
            }
            Console.WriteLine("Error: No Value Found");
        } //runs the 3rd functionality of the assessment

        public static void Functionality5(int[] list1, int[] list2, int[] list3)
        {
            Console.WriteLine("Share_1_2048:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list1), 50);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list1), 50);

            Console.WriteLine("Share_2_2048:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list2), 50);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list2), 50);

            Console.WriteLine("Share_3_2048:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list3), 50);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list3), 50);

            Console.Write("Pick a value to search for in Share_3_2048: ");
            int key = Convert.ToInt16(Console.ReadLine());
            list3 = Sorts.RadixSortAscending(list3);
            PrintList(Search.LinearSearch(list3, key, true), 1);
        }//runs the 5th functionality of the assessment

        public static void Functionality6(int[] list1, int[] list2, int increment)
        {
            int[] NEW_share = Mergeshare(list1, list2);
            Console.WriteLine("NEW Share:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.QuickSortAscending(NEW_share), increment);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.InsertionSortDescending(NEW_share), increment);

            Console.Write("Pick a value to search for: "); 
            int key = Convert.ToInt16(Console.ReadLine());
            NEW_share = Sorts.RadixSortAscending(NEW_share);
            PrintList(Search.LinearSearch(NEW_share, key, true), 1);
        } //runs the 6th functionality of the assessment

        public static int[] FileToArray(string filePath)
        {
            var list = new List<int>();
            var data = File.ReadAllLines(filePath); //reads all the lines from the file
            foreach (var s in data)
            {
                list.Add(Convert.ToInt32(s)); //adds the lines to a list and converts them to integers
            }
            return list.ToArray(); //converts the list to an array and returns it
        } //converts the given file into and array

        public static void TestFileAscending(int[] FileArray)
        {
            if (Sorts.BubbleSortAscending(FileArray) == Sorts.QuickSortAscending(FileArray)
                & Sorts.QuickSortAscending(FileArray) == Sorts.RadixSortAscending(FileArray)
                & Sorts.RadixSortAscending(FileArray) == Sorts.InsertionSortAscending(FileArray))
            { Console.WriteLine("SUCCESS!"); }
        } //Tests that all the Ascending sorts work correctly

        public static void TestFileDescending(int[] FileArray)
        {
            if (Sorts.BubbleSortDescending(FileArray) == Sorts.QuickSortDescending(FileArray)
                & Sorts.QuickSortDescending(FileArray) == Sorts.RadixSortDescending(FileArray)
                & Sorts.RadixSortDescending(FileArray) == Sorts.InsertionSortDescending(FileArray))
            { Console.WriteLine("SUCCESS!"); }
        } //Tests that all the descending sorts work correctly

        public static void PrintList(int[] list, int increment)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (i % increment == 0) //checks that the increment has been met so it can write the value
                { Console.WriteLine($"{list[i]}"); }
            }
            Console.WriteLine();
        } //function to display a given array with a given increment

        public static int[] Mergeshare(int[] list1, int[] list2)
        {
            return list1.Concat(list2).ToArray();
        } //function to merge 2 given arrays
    }
}
