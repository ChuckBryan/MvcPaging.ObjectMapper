MvcPaging IPagedListMapper for AutoMapper
===================

I am a big fan of the MvcPaging Library (https://github.com/martijnboland/MvcPaging) and AutoMapper (https://github.com/AutoMapper/AutoMapper).

When I tried map an IEnumerable<T> to the IPagedList<T>, I found out that I needed to do a bit more work. It turns out this was a fairly common question, but
there were two challenges:

1. Most of the answers used another Paging Library (however, the interfaces were nearly identical)
2. Jimmy Bogard (AutoMapper Author) recommended creating an IObjectMapper. Instructions on how to do this were fairly scattered.

I found a great article at http://bzbetty.blogspot.com/2012/06/automapperactionfilter-vs-pagination.html that helped me with implementing my solution. In fact, I started with 
his article and then built my tests until I got them working satisfactorily.

With this IObjectMapper, I can write a standard AutoMapper Create Map statement:
Mapper.CreateMap<SourceClass, DestinationClass>();

and then use that to map to a Paged List:
```
var _sources = new List<SourceClass> { new SourceClass { Id = 1, Name = "Source Class" } };
var _destination = Mapper.Map<PagedList<DestinationClass>>(sourcePagedList);
```
