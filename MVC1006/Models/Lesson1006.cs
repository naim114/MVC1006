namespace MVC1006.Models
{
    public class Person
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool Vaccinated { get; set; }

        public double Bmi { 
            get {
                return Weight / Math.Pow(Height, 2);
            }
        }

        public string BmiClass {
            get {
                if (Bmi < 18.5)
                    return "Underweight";
                else if (Bmi < 25)
                    return "Good";
                else if (Bmi < 29)
                    return "Overweight";
                else
                    return "Obese";
            }
        }
    }
}
