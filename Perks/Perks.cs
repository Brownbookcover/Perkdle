namespace Perks
{
    public class Perk
    {
        public Perk(string name, string role, string character, List<string> type, int year)
        {
            Name=name;
            Role=role;
            Character=character;
            Type=type;
            Year=year;
        }
        public string Name { get; set; }

        public string Role { get; set; }

        public string Character { get; set; }

        public List<string> Type { get; set; }

        public int Year { get; set; }
    }
}