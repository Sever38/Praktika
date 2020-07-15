using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1.ViewModel;

namespace UnitTestProject1
{
	[TestClass]
	public class WpfApp1Tests
	{
		[TestMethod]
		public void TestMethod1()
		{
			var pcvm = new PCVM();
			var result = pcvm.StatusConnection();
			Assert.IsTrue(result);
		}		
	}
}
