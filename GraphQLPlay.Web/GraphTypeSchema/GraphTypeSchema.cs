using System;
using System.Linq;
using GraphQL.Types;
using GraphQLPlay.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLPlay.GraphTypeSchema
{
    public class Clone
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Image ParentImage { get; set; }
    }

    public class CloneType : ObjectGraphType<Clone>
    {
        public CloneType()
        {
            Field(x => x.Id);
            Field(x => x.Name);

            Field<ObjectGraphType<ImageType>>(
                "parentImage",
                resolve: context => context.Source.ParentImage
            );
        }
    }

    public class Image
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
    public class ImageType : ObjectGraphType<Image>
    {
        public ImageType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }

    public class TopLevelQuery : ObjectGraphType
    {
        public TopLevelQuery(MyDbContext dbContext)
        {
            Field<ListGraphType<CloneType>>(
                "clones",
                resolve: context =>
                {
                    // Here we can check the user context that could be injected into the constructor,
                    // and only allow them to retrieve clones they can see.

                    var result = Enumerable.Select(dbContext.Clones.Include(c => c.ParentImage), cloneEf => new Clone
                    {
                        Id = cloneEf.Id.ToString(),
                        Name = cloneEf.Name,
                        ParentImage = new Image
                        {
                            Id = cloneEf.ParentImage.Id.ToString(),
                            Name = cloneEf.ParentImage.Name
                        }
                    });
                        
                    return result;
                }
            );
            Field<ListGraphType<ImageType>>("images", resolve: context =>
            {
                return dbContext.Images.Select(imageEf => new Image
                {
                    Id = imageEf.Id.ToString(),
                    Name = imageEf.Name
                });
            });
        }
    }
}