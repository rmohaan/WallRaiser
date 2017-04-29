using MesoketesBattle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MesoketesTests
{
    [TestClass]
    public class ReaderFactoryTests
    {
        [TestMethod]
        public void GetConsoleReaderTest()
        {
            var reader = ReaderFactory.GetReader("1");
            Assert.AreEqual(reader.GetType(), typeof(ConsoleReader));
        }

        [TestMethod]
        public void GetFileReaderTest()
        {
            var reader = ReaderFactory.GetReader("2");
            Assert.AreEqual(reader.GetType(), typeof(FileReader));
        }

        [TestMethod]
        public void GetStaticReaderTest()
        {
            var reader = ReaderFactory.GetReader("");
            Assert.AreEqual(reader.GetType(), typeof(StaticReader));
        }

        [TestMethod]
        public void GetStaticReaderReadInputTest()
        {
            var reader = ReaderFactory.GetReader("");
            Assert.AreEqual(reader.ReadInput(), "Day1$T1-N-x-5:T2-W-X-3;Day2$T1-S-X-2");
        }
    }
}
