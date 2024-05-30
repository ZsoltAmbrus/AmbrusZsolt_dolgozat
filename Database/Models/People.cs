using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Database.Models
{
    public class People : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string age;
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }

        private string position;
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged();
            }
        }

        private string hobby;
        public string Hobby
        {
            get { return hobby; }
            set
            {
                hobby = value;
                OnPropertyChanged();
            }
        }

        public People()
        {
            Id = 0;
        }

        public People(string name, string age, string city, string position, string hobby)
        {
            Name = name;
            Age = age;
            City = city;
            Position = position;
            Hobby = hobby;
        }

        public People(string sor)
        {
            string[] t = sor.Split(';');
            Name = t[0];
            Age = t[1];
            City = t[2];
            Position = t[3];
            Hobby = t[4];
        }

        public override string? ToString()
        {
            return $"{Name}, neve a(z) {City} városban lakik, {Position}-ként dolgozik, {Age} éves, hobbija: {Hobby}.";
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
