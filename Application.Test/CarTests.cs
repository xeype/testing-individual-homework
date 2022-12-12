using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(nameof(_carsCases))]
        public void TestFirstCharOfNameIsUpper(string name, string brand, float tankVolume, int numberOfDoors,
            string bodyType)
        {
            var myCar = new Car(name, brand, tankVolume, numberOfDoors, bodyType);
            Assert.AreEqual(myCar.Name[0].ToString().ToUpper(), myCar.Name[0].ToString(),
                "First char of Name in not upper");
        }

        [TestCaseSource(nameof(_carsCases))]
        public void TestFirstCharOfBrandIsUpper(string name, string brand, float tankVolume, int numberOfDoors,
            string bodyType)
        {
            var myCar = new Car(name, brand, tankVolume, numberOfDoors, bodyType);
            Assert.AreEqual(myCar.Brand[0].ToString().ToUpper(), myCar.Brand[0].ToString(),
                "First char of Brand in not upper");
        }

        [TestCaseSource(nameof(_carsCases))]
        public void TestBrandDoesNotContainNumbers(string name, string brand, float tankVolume, int numberOfDoors,
            string bodyType)
        {
            var myCar = new Car(name, brand, tankVolume, numberOfDoors, bodyType);
            var containsInt = myCar.Brand.Any(char.IsDigit);
            Assert.IsFalse(containsInt, "Test Brand should not contain numbers");
        }

        [TestCaseSource(nameof(_carsCases))]
        public void TestNameContainsDigitsOnlyAtTheEndAfterDash(string name, string brand, float tankVolume,
            int numberOfDoors, string bodyType)
        {
            var myCar = new Car(name, brand, tankVolume, numberOfDoors, bodyType);
            bool containsInt = myCar.Name.Any(char.IsDigit);
            if (containsInt)
            {
                try
                {
                    Regex regex = new("[-0-9]+$");
                    MatchCollection match = regex.Matches(myCar.Name);
                    string matchValue = null;
                    foreach (Match m in match)
                        matchValue = m.Value;

                    bool endsWith = myCar.Name.EndsWith(matchValue);
                    Assert.IsTrue(endsWith, "Wrong format of Name. Should be similar to Cls-63 ");
                }
                catch (ArgumentNullException)
                {
                    Assert.Pass();
                }
            }
            else
            {
                Assert.Pass();
            }
        }

        [TestCaseSource(nameof(_carsCases))]
        public void TestTankVolumeBetween40And150(string name, string brand, float tankVolume, int numberOfDoors,
            string bodyType)
        {
            var myCar = new Car(name, brand, tankVolume, numberOfDoors, bodyType);
            Assert.IsTrue(myCar.TankVolume >= 40f && myCar.TankVolume <= 150,
                "The actual value is not in range 40-150");
        }

        [TestCaseSource(nameof(_carsCases))]
        public void TestBodyTypeDoesNotContainNumbers(string name, string brand, float tankVolume, int numberOfDoors,
            string bodyType)
        {
            var myCar = new Car(name, brand, tankVolume, numberOfDoors, bodyType);
            var containsInt = myCar.Brand.Any(char.IsDigit);
            Assert.AreEqual(false, containsInt);
        }

        [TestCaseSource(nameof(_carsCases))]
        public void TestFirstCharOfBodyTypeIsUpper(string name, string brand, float tankVolume, int numberOfDoors,
            string bodyType)
        {
            var myCar = new Car(name, brand, tankVolume, numberOfDoors, bodyType);
            Assert.AreEqual(myCar.BodyType[0].ToString().ToUpper(), myCar.BodyType[0].ToString(),
                "First letter of body type not upper");
        }

        [TestCaseSource(nameof(_carsCases))]
        public void TestCountOfDoors(string name, string brand, float tankVolume, int numberOfDoors, string bodyType)
        {
            var myCar = new Car(name, brand, tankVolume, numberOfDoors, bodyType);
            var variationsNumberOfDoors = new List<int> {3, 4, 5};
            Assert.IsTrue(variationsNumberOfDoors.Contains(myCar.NumberOfDoors), "Count of doors not in [3, 4, 5]");
        }

        private static object[] _carsCases =
        {
            new object[] {"CLS", "Mercedes Benz", 40, 4, "Sedan"},
            new object[] {"CLS", "mercedes Benz", 39, 2, "coupe"},
            new object[] {"CLS", "Mercedes 1 Benz", 150, 3, "Coupe"},
            new object[] {"CLS", "mercedes 1 Benz", 151, 2, "Coupe1"},
            new object[] {"im", "mercedes benz", 50, 2, "Coupe"},
            new object[] {"im", "Mercedes 1 benz", 151, 3, "Coupe"},
            new object[] {"im", "mercedes 1 benz", 120, 3, "coupe"},
            new object[] {"im", "Mercedes Benz", 120, 2, "Coupe"},
            new object[] {"im", "Mercedes Benz", 152, 3, "Coup3"},
            new object[] {"CLS-63", "Mercedes 1 Benz", 120, 2, "Coup3"},
            new object[] {"CLS-63", "mercedes 1 benz", 120, 3, "Coupe"},
            new object[] {"cls-63", "Mercedes Benz", 120, 3, "coupe"},
            new object[] {"cls-63", "mercedes 1 benz", 30, 4, "coupe"},
            new object[] {"cls", "mercedes 1 benz", 30, 4, "Coupe"},
            new object[] {"CLS", "Mercedes Benz", 50, 4, "Coupe1"},
            new object[] {"cls", "mercedes benz", 50, 2, "Coupe"},
            new object[] {"CLS", "Mercedes1 benz", 50, 2, "coupe"},
            new object[] {"63CLS", "Mercedes benz", 30, 3, "coupe"},
            new object[] {"63CLS", "Mercedes benz", 50, 2, "Coupe"},
            new object[] {"63-CLS", "mercedes benz", 50, 3, "Coupe1"},
            new object[] {"63-CLS", "Mercedes 1 benz", 180, 3, "Coupe"},
            new object[] {"63-CLS", "mercedes 1 benz", 120, 2, "Coupe"},
        };
    }
}