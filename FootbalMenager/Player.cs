namespace FootbalMenager
{
    class Player
    {
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public int age { get; private set; }
        public double weight { get; private set; }

        public Player(string firstName, string lastName, int age, double weight)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.weight = weight;
        }

        public override string ToString()
        {
            return ("Name: " + firstName + "   " + "Surename : " + lastName + "   " + " Age: " + age + " years old " + "   " + " Weight: " + weight + "lb");
        }

    }
}