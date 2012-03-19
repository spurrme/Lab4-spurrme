using System;
using NUnit.Framework;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestFixture()]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[SetUp()]
		public void SetUp()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[Test()]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target =  ObjectMother.BMW();
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}
        [Test()]
        public void TestgetCarLocation()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            var target = new Car(3);
            target.Database = mockDatabase;
            String carLocation = target.getCarLocation(15);
            Assert.AreEqual(carLocation, mockDatabase.getCarLocation(15));

        }
        [Test()]
        public void TestMilage()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            Int32 testMiles = 678;
            mockDatabase.Miles = testMiles;
            var target = new Car(67);
            target.Database = mockDatabase;
            Int32 mileCount = target.Mileage;
            Assert.AreEqual(mileCount, testMiles);
        }

	}
}
