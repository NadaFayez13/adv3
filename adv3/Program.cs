namespace adv3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Student Grade Manager
            // Create a Collection with these grades: 85, 92, 78, 95, 88, 70, 100, 65
            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            //Print the collection, Count, first and last grade
            Console.WriteLine("Grades:");
            foreach (int grade in grades)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine($"Count: {grades.Count}");
            Console.WriteLine($"First Grade: {grades[0]}");
            Console.WriteLine($"Last Grade: {grades[^1]}");

            //Sort the grades ascending, then print
            grades.Sort();
            Console.WriteLine("Grades (Sorted):");
            foreach (int grade in grades)
            {
                Console.WriteLine(grade);
            }

            //Get the first grade above 90
            int firstAbove90 = grades.Find(n => n > 90);
            Console.WriteLine($"First Grade Above 90: {firstAbove90}");

            //Get all grades below 75 (failing grades)
            List<int> failingGrades = grades.FindAll(n => n < 75);
            Console.WriteLine("Failing Grades:");
            foreach (int grade in failingGrades)
            {
                Console.WriteLine(grade);
            }

            //Remove all failing grades (below 75)
            grades.RemoveAll(n => n < 75);
            Console.WriteLine("Grades (After Removing Failing):");
            foreach (int grade in grades)
            {
                Console.WriteLine(grade);
            }

            //Check if any grade equals 100
            bool hasA_Hundred = grades.Exists(n => n == 100);
            Console.WriteLine($"Is there any grade equal to 100? {hasA_Hundred}");

            //Create a List<string> where each grade becomes "Grade: X"
            List<string> gradeStrings = grades.ConvertAll(n => $"Grade: {n}");
            foreach (string gradeStr in gradeStrings)
            {
                Console.WriteLine(gradeStr);
            }
            #endregion

            #region Leaderboard
            //Create a leaderboard that automatically sorts players by score
            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>();

            //Add: 500="Ahmed", 200="Sara", 800="Ali", 350="Mona"
            leaderboard.Add(500, "Ahmed");
            leaderboard.Add(200, "Sara");
            leaderboard.Add(800, "Ali");
            leaderboard.Add(350, "Mona");

            // Print all entries (they should be sorted by score automatically)
            Console.WriteLine("Leaderboard:");
            foreach (KeyValuePair<int, string> player in leaderboard)
            {
                Console.WriteLine($"Score: {player.Key}, Player: {player.Value}");
            }

            //Access the first key and first value 
            var firstEntry = leaderboard.First();
            Console.WriteLine($"\nFirst Entry -> Score: {firstEntry.Key}, Player: {firstEntry.Value}");

            //Check if score 500 exists
            bool hasScore500 = leaderboard.ContainsKey(500);
            Console.WriteLine($"\nDoes score 500 exist? {hasScore500}");

            //Safely get the player with score 999
            if (leaderboard.TryGetValue(999, out string player999))
            {
                Console.WriteLine($"\nPlayer with score 999: {player999}");
            }
            else
            {
                Console.WriteLine("\nPlayer with score 999 not found (Safely handled).");
            }

            //Remove the player with score 200 and print the updated list
            leaderboard.Remove(200);
            Console.WriteLine("\nLeaderboard After Removing Score 200 ");
            foreach (KeyValuePair<int, string> player in leaderboard)
            {
                Console.WriteLine($"Score: {player.Key}, Player: {player.Value}");
            }


            #endregion


            #region  Browser History (Undo)
            // Create a Stack<string> for browser history and Push 5 URLs: "google.com", "github.com", "stackoverflow.com", "youtube.com", "claude.ai"
            Stack<string> browserhistory = new Stack<string>();
            browserhistory.Push("google.com");
            browserhistory.Push("github.com");
            browserhistory.Push("stackoverflow.com");
            browserhistory.Push("youtube.com");
            browserhistory.Push("claude.ai");

            //Use Peek to see the current page (top of stack)
            Console.WriteLine($"Current Page: {browserhistory.Peek()}");

            //Press "back" 3 times using Pop — print each page you leave
            string leftPage1 = browserhistory.Pop();
            Console.WriteLine($"Left page: {leftPage1}");

            string leftPage2 = browserhistory.Pop();
            Console.WriteLine($"Left page: {leftPage2}");

            string leftPage3 = browserhistory.Pop();
            Console.WriteLine($"Left page: {leftPage3}");

            //Print the current page after going back
            Console.WriteLine($"Current Page after going back: {browserhistory.Peek()}");

            //Try TryPop on an empty stack — what happens?
            browserhistory.Clear();
            if (browserhistory.TryPop(out string poppedPage))
            {
                Console.WriteLine($"Popped page: {poppedPage}");
            }
            else
            {
                Console.WriteLine("Stack is empty. Cannot pop.");
            }
            #endregion
        }
    }
}
