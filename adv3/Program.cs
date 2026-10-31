using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            #region Phone Book
            // Create a Collection  with 4 contacts (name → phone number)
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            phoneBook.Add("nada", "123456789");
            phoneBook.Add("sara", "2345678901");
            phoneBook.Add("serag", "3456789012");
            phoneBook.Add("mona", "4567890123");

            //Add a new contact using [] syntax (add or update)
            phoneBook["walaa"] = "2099887766";

            //Try adding a duplicate using .Add() — catch the exception and print the error
            try
            {
                phoneBook.Add("nada", "01111111111");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error caught: {ex.Message}");
            }

            //Try adding a duplicate using .TryAdd() — print whether it succeeded
            bool isAdded = phoneBook.TryAdd("sara", "01222222222");
            Console.WriteLine($"Did TryAdd succeed for 'Sara'? {isAdded}");

            //Search for a contact that doesn’t exist
            if (phoneBook.TryGetValue("Omar", out string phoneNumber))
            {
                Console.WriteLine($"Found: {phoneNumber}");
            }
            else
            {
                Console.WriteLine("Contact 'Omar' not found.");
            }

            //Get a contact with a fallback of "Not Found"
            string searchedContact = phoneBook.TryGetValue("Noura", out string foundNum) ? foundNum : "Not Found";
            Console.WriteLine($"Search result for 'Noura': {searchedContact}");

            //Print all Keys on one line, then all Values on another line
            Console.WriteLine("\nPhone Book Keys (Names)");
            Console.WriteLine(string.Join(", ", phoneBook.Keys));

            Console.WriteLine("Phone Book Values (Numbers)");
            Console.WriteLine(string.Join(", ", phoneBook.Values));


            #endregion

            #region Unique Email Validator
            // Create a HashSet<string> with a case-insensitive comparer: new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            //Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com", "Sara@Test.Com"
            emails.Add("nada@test.com");
            emails.Add("NADA@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            //Print Count — how many are actually stored? Explain why.
            Console.WriteLine($"Count of unique emails: {emails.Count}");

            //Create two sets: Set A = {1,2,3,4,5} and Set B = {4,5,6,7,8}
            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            //Print the result of: UnionWith, IntersectWith, ExceptWith

            // UnionWith
            HashSet<int> unionResult = new HashSet<int>(setA);
            unionResult.UnionWith(setB);
            Console.WriteLine($"UnionWith: {string.Join(", ", unionResult)}");

            // IntersectWith 
            HashSet<int> intersectResult = new HashSet<int>(setA);
            intersectResult.IntersectWith(setB);
            Console.WriteLine($"IntersectWith: {string.Join(", ", intersectResult)}");

            // ExceptWith 
            HashSet<int> exceptResult = new HashSet<int>(setA);
            exceptResult.ExceptWith(setB);
            Console.WriteLine($"ExceptWith (Set A - Set B): {string.Join(", ", exceptResult)}");

            // Use IsSubsetOf to check if {1,2} is a subset of Set A

            HashSet<int> subSet = new HashSet<int> { 1, 2 };
            bool isSubset = subSet.IsSubsetOf(setA);
            Console.WriteLine($"Is {{1,2}} a subset of Set A? {isSubset}");

            #endregion

            #region Print Queue Simulator
            // Create a Queue<string> and enqueue 5 documents: "Report.pdf", "Invoice.pdf", "Letter.docx", "Resume.pdf", "Photo.jpg"
            Queue<string> printQueue = new Queue<string>();
            printQueue.Enqueue("Report.pdf");
            printQueue.Enqueue("Invoice.pdf");
            printQueue.Enqueue("Letter.docx");
            printQueue.Enqueue("Resume.pdf");
            printQueue.Enqueue("Photo.jpg");

            //Print the queue contents and Count
            Console.WriteLine("--- Print Queue Contents ---");
            foreach (string doc in printQueue)
            {
                Console.WriteLine(doc);
            }
            Console.WriteLine($"Total Documents in Queue (Count): {printQueue.Count}");

            //Use Peek to see which document will print next (without removing)
            Console.WriteLine($"Next document to print (Peek): {printQueue.Peek()}");

            //Process the queue: Dequeue each document and print "Printing: [name]"
            Console.WriteLine("\n--- Processing Print Queue ---");
            while (printQueue.Count > 0)
            {
                string currentDoc = printQueue.Dequeue();
                Console.WriteLine($"Printing: {currentDoc}");
            }

            //Try TryDequeue on the now-empty queue — what happens?
            bool isDequeued = printQueue.TryDequeue(out string dequeuedDoc);
            Console.WriteLine($"\nDid TryDequeue succeed on empty queue? {isDequeued}");
            Console.WriteLine($"Dequeued document: {dequeuedDoc ?? "Queue is empty"}");

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
