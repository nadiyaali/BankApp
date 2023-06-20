

using BankLibrary;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var account = new BankAccount("Test", 1000);

            //Assert.True(true);

                Assert.Throws<InvalidOperationException>(() => { account.MakeWithdrawal(2000, DateTime.Now, "Testing for overdraw"); });
         }

        [Fact]
        public void Test2() 
        {
            var account = new BankAccount("Test", 1000);
            Assert.Throws<ArgumentOutOfRangeException>(() => { account.MakeWithdrawal(-1000, DateTime.Now, "Testing for negative amount"); });

        }

        [Fact]
        public void Test3()
        {
            var account = new BankAccount("Test", 1000);
            Assert.Throws<ArgumentOutOfRangeException>(() => { account.MakeDeposit(-1000, DateTime.Now, "Testing for negative amount"); });

        }


    }
}