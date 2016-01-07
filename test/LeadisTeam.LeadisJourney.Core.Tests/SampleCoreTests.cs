using Xunit;

namespace LeadisTeam.LeadisJourney.Core.Tests {
	public class SampleCoreTests {
		[Fact]
		public void TestAdd() {
			Assert.Equal(10, Add(4,6));
		}

		private static int Add(int a, int b) {
			return a + b;
		}
	}
}
