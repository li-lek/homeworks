using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using testIN;

namespace Funct
{
    [TestClass]
    public class Convertto
    {
        [TestMethod]
        public void DicOpen()
        {
            bool result=false;
            using (StreamReader sr = new StreamReader("Dictionary.txt"))
            {
                if (sr.ReadToEnd() != null) result = true;
            }
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TextOpen()
        {
            bool result=false;
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                if (sr.ReadToEnd() != null) result = true;
            }
            Assert.AreEqual(true, result);
        }
    }
}
