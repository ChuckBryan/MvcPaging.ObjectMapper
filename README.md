MvcPaging IPagedListMapper for AutoMapper
---------------------

I am a big fan of the [MvcPaging Library] (https://github.com/martijnboland/MvcPaging) and [AutoMapper] (https://github.com/AutoMapper/AutoMapper).

When I tried to map an IEnumerable<T> to the IPagedList<T>, I found out that I needed to do a bit more work. It turns out this was a fairly common question, however:

1. Most of the answers used another Paging Library (however, the interfaces were nearly identical)
2. Jimmy Bogard (AutoMapper Author) recommended creating an IObjectMapper. 
3. Instructions on how to do this were scattered.

I found a great article by [bzbetty] (http://bzbetty.blogspot.com/2012/06/automapperactionfilter-vs-pagination.html) that helped immensly with the implementation. In fact, I started with 
his article and built my tests until I got it working with MvcPaging's PageList.

With this IObjectMapper, a standard AutoMapper Create Map statement can be defined:
```
Mapper.CreateMap<SourceClass, DestinationClass>();
```
and now AutoMapper will be able to Map to a PagedList<T>:
```
var _sources = new List<SourceClass> { new SourceClass { Id = 1, Name = "Source Class" } };
var _destination = Mapper.Map<PagedList<DestinationClass>>(sourcePagedList);
```

And, it's available on NuGet
```
PM> Install-Package MvcPaging.ObjectMapper
```