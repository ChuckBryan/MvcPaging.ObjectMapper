using NUnit.Framework;

namespace MvcPaging.ObjectMapper.Test
{
    public abstract class AAA
    {
        [SetUp]
        public void MainSetup()
        {
            Arrange();
            Act();
        }

        [TearDown]
        protected void MainTeardown()
        {
            CleanUp();
        }

        protected abstract void CleanUp();

        protected abstract void Act();

        protected abstract void Arrange();
    }
}
