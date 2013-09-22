using System.Collections.Generic;

namespace AutoMapperPagedList.Test.AutoMapperTest
{
    public class DestinationClass
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class SourceClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static IList<SourceClass> Builder(int numberOfItems)
        {
            var items = new List<SourceClass>();

            for (int i = 0; i < numberOfItems; i++)
            {
                items.Add(new SourceClass {Id = i, Name = "Source Class" + i});
            }

            return items;
        }
    }
}