﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyFirstAPIRequest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Request.MyFirstGet();
        }
    }
}
