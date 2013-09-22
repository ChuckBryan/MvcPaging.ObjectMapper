using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Mappers;
using NUnit.Framework;

namespace MvcPaging.AutoMapper.Test.AutoMapperTest
{
    public class WhenRegisteringObjectMapper : AAA
    {
        private IEnumerable<IObjectMapper> _allMappers;

        protected override void CleanUp()
        {
        }

        protected override void Act()
        {
            _allMappers = MapperRegistryOverride.AllMappers();
        }

        protected override void Arrange()
        {
            PagedListMapper.Register();
        }

        [Test]
        public void ThenCustomObjectMapperWillBeListedFirst()
        {
            var firstMapper = _allMappers.FirstOrDefault();

            Assert.IsNotNull(firstMapper);
            Assert.IsTrue(firstMapper.GetType() == typeof(PagedListMapper));
        }
    }
}