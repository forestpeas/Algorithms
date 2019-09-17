namespace Algorithms.Strings
{
    public class KeyIndexedCounting
    {
        // Sort students by grade.
        // In this example, grade is the key.
        public static void Sort(Student[] students)
        {
            int grades = 5; // Assume there are only 5 grades: 0, 1, 2, 3, 4.
            Student[] aux = new Student[students.Length];
            int[] count = new int[grades + 1];

            // Compute frequency counts.
            for (int i = 0; i < students.Length; i++)
            {
                count[students[i].Grade + 1]++;
            }

            // Transform counts to indices.
            for (int i = 0; i < grades; i++)
            {
                count[i + 1] += count[i];
            }

            // Distribute the records.
            for (int i = 0; i < students.Length; i++)
            {
                aux[count[students[i].Grade]++] = students[i];
            }

            // Copy back.
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = aux[i];
            }
        }

        public class Student
        {
            public string Name { get; }

            public int Grade { get; }

            public Student(string name, int grade)
            {
                Name = name;
                Grade = grade;
            }
        }

    }
}
