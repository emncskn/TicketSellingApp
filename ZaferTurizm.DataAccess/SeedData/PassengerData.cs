using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    public class PassengerData
    {
        public static readonly Passenger Data01 = new Passenger() { Id = 1, Name = "Pelin", Surname="Su",Gender=Gender.Female
            ,NationalNumber="1234" };
        public static readonly Passenger Data02 = new Passenger() { Id = 2, Name = "Berke", Surname = "Can", Gender = Gender.Male, NationalNumber = "4567" };
        public static readonly Passenger Data03 = new Passenger() { Id = 3, Name = "Erva", Surname = "As", Gender = Gender.Female, NationalNumber = "7890" };
        public static readonly Passenger Data04 = new Passenger() { Id = 4, Name = "Andaç", Surname = "Sazel", Gender = Gender.Male, NationalNumber = "1478" };
        public static readonly Passenger Data05= new Passenger() { Id = 5, Name = "Reyhan", Surname = "Avşar", Gender = Gender.None, NationalNumber = "2589" };
        public static readonly Passenger Data06 = new Passenger() { Id = 6, Name = "Sema", Surname = "Ket", Gender = Gender.Female, NationalNumber = "7536" };
        public static readonly Passenger Data07 = new Passenger() { Id = 7, Name = "Semah", Surname = "Kert", Gender = Gender.Female, NationalNumber = "7556" };
    }
}
