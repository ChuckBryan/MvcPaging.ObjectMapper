using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Mappers;
using NUnit.Framework;

namespace MvcPaging.ObjectMapper.Test.AutoMapperTest
{
    public class WhenRegisteringObjectMapper : AAA
    {
        private IEnumerable<IObjectMapper> _allMappers;
        private int _countOfDefaultMappers;

        protected override void CleanUp()
        {
        }

        protected override void Act()
        {
            _allMappers = MapperRegistry.Mappers;
        }

        protected override void Arrange()
        {
            _countOfDefaultMappers = MapperRegistry.Mappers.Count();
            PagedListMapper.Register();
        }

        [Test]
        public void ThenCustomObjectMapperWillBeListedFirst()
        {
            var firstMapper = _allMappers.FirstOrDefault();

            Assert.IsNotNull(firstMapper);
            Assert.IsTrue(firstMapper.GetType() == typeof(PagedListMapper));
        }

        [Test]
        public void TheMapperCollectionWillContainMoreThanTheCustomMapper()
        {
            Assert.IsTrue(_allMappers.Count() == _countOfDefaultMappers + 1);
        }
    }
}