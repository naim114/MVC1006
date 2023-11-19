namespace MVC1006.AssignedValues
{
    public class PosLaju
    {
        public string[] weightCategories = {
            "< 0.50kg",
            "< 0.75kg",
            "< 1.00kg",
            "< 1.25kg",
            "< 1.50kg",
            "< 1.75kg",
            "< 2.00kg",
            "< 2.50kg",
            "< 3.50kg",
        };
        public string[] zones = { "West Malaysia", "Sabah", "Sarawak" };
        public double[,] rates = {
            {6, 8.5, 9},
            {7, 10.5, 12},
            {8.5, 12.5, 14.5},
            {10, 14.5, 17.0},
            {11, 16.5, 20.0},
            {12, 18.5, 22.5},
            {14, 20.5, 25.0},
            {21, 34.5, 41.0},
            {24, 39.0, 46.0},
        };
    }

    public class SoftwareHouse
    {
        public string[] employees = { "Sarah", "Hafiz", "Amin" };

        public string[][] skills =
        {
            new string[]  {"C#", "VB", "Java", "PHP"},
            new string[]  {"Python", "R"},
            new string[]  {"React", "Ionic", "Flutter"},
        };
    }

    public class CourseGrade
    {
        public string[] students = { "Sarah", "Hafiz", "Amin" };

        public string[][,] courses =
        {
            new string[,] {
                { "C#", "A"},
                { "VB", "B+" },
                { "Java", "B" },
                { "PHP", "A-" },
            },

            new string[,] {
                { "Python", "B"},
                { "R", "A-" },
            },

            new string[,] {
                { "React", "C+"},
                { "Ionic", "B" },
                { "Flutter", "A" },
            },
        };
    }
}
