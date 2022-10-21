using Calc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    [TestClass]
    public class CalcTest
    {
        //[AssemblyInitialize] - pred vsemi testy v projektu
        //[ClassInitialize] - pred vsemi testy ve tride
        //[TestInitialize] - pred kazdou testovaci metodou
        //[TestCleanup] - po kazde testovaci metode
        //[ClassCleanup] - po vsech testech ve tride
        //[AssemblyCleanup] - po vsech testech v projektu
        Kalkulacka k;
        [TestInitialize]
        public void Init() 
        {
            k = new Kalkulacka();
        }
        
        [TestMethod]
        public void Secti1a1Jsou2()
        {
            //Kalkulacka k = new Kalkulacka();
            int actual = k.Secti(1, 1);
            Assert.AreEqual(2, actual);
        }
        [TestMethod]
        public void SectiMinus3aMinus5jeMinus8() 
        {
            //Kalkulacka k = new Kalkulacka();
            int actual = k.Secti(-3, -5);
            Assert.AreEqual(-8, actual);
        }
        [TestMethod]
        public void Secti3aMinus8jeMinus5() 
        {
            //Kalkulacka k = new Kalkulacka();

            Assert.AreEqual(-5,k.Secti(3, -8));
        }
    }
}