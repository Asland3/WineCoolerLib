using Microsoft.VisualStudio.TestTools.UnitTesting;
using WineCoolerLib;
using System;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

//using Assert = NUnit.Framework.Assert;


namespace CoolerUnitTest;

[TestClass()]
public class Tests
{
    private Cooler _wineCooler;
    
    [TestInitialize]
    public void Setup()
    {
        _wineCooler = new Cooler(); 
    }
    
    
    [TestMethod]
    public void CoolerIsFull()
    {
        Assert.AreEqual(2, _wineCooler.CapacityOfBottles = 2);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => _wineCooler.CapacityOfBottles = 25);
    }

    [TestMethod]
    public void AddWine()
    {
        
    }
}