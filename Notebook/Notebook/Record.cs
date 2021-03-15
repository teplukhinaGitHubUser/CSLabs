using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    class Record
    {
        public int ID { get; private set; }
        private static int counter=1;
        public string LastName { get;set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Birthday { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }

        public Record()
        {
            this.ID = counter;
            counter++;

        }

        public void CreateRecord(string lastName, string firstName, string middleName,string phone,string country,string birthday,string company,string position,string comment)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Phone = phone;
            this.Country = country;
            this.Birthday = birthday;
            this.Company = company;
            this.Position = position;
            this.Comment = comment;
        }



        public override string ToString()
        {
            return $"Номер записи: {ID}\nФамилия: {LastName}\nИмя: {FirstName}\nОтчество: {MiddleName}\nТелефон: {Phone}\nСтрана: {Country}\nДень рождения: {Birthday}\nОрганизация: {Company}\nДолжность: {Position}\nПрочие заметки: {Comment}";
        }

        public string GetShortInformation()
        {
            return $"№{ID} {LastName} {FirstName}  Телефон: {Phone}";
        }

    }
}
