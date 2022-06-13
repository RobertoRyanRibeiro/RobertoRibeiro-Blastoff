// See https://aka.ms/new-console-template for more information
using Blog.Data;
using Blog.Models;

using (var context = new BlogDataContext())
{
    //var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
    //context.Tags.Add(tag);
    //context.SaveChanges();

    var tag = context.Tags.FirstOrDefault(x=>x.Id==2);
    tag.Name = ".Net";
    tag.Slug = "dotnet";
    context.Update(tag);
    context.SaveChanges();
}