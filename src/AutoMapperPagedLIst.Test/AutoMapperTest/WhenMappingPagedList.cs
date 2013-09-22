using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NUnit.Framework;

namespace MvcPaging.AutoMapper.Test.AutoMapperTest
{
    public class WhenMappingPagedList : AAA
    {
        private IPagedList<DestinationClass> _destination;
        private IList<SourceClass> _sources;

        private const int PageIndex = 0;
        private const int PagedSize = 10;

        protected override void CleanUp()
        {
        }

        protected override void Act()
        {
            IPagedList<SourceClass> sourcePagedList = _sources.ToPagedList(PageIndex, PagedSize);

            _destination = Mapper.Map<PagedList<DestinationClass>>(sourcePagedList);
        }

        protected override void Arrange()
        {

            PagedListMapper.Register();

            Mapper.CreateMap<SourceClass, DestinationClass>();

            _sources = SourceClass.Builder(20);
        }

        [Test]
        public void ThenDesitinationObjectWillBeMapped()
        {
            Assert.IsTrue(PageIndex == _destination.PageIndex);
            Assert.IsTrue(PagedSize == _destination.PageSize);
            Assert.IsTrue(2 == _destination.PageCount);
            Assert.IsTrue(PagedSize == _destination.Count());

            CollectionAssert.IsNotEmpty(_destination);
            CollectionAssert.AllItemsAreInstancesOfType(_destination, typeof(DestinationClass));
        }
    }
}