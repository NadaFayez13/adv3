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
        }
    }
}
