using HotChocolate.Types;

namespace GraphQLPlay.HotChocolate
{
    public class MyQueryType : ObjectType<MyQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<MyQuery> descriptor)
        {
            descriptor.Field(t => t.Clones())
                .Type<ListType<CloneType>>();
            descriptor.Field(t => t.Images())
                .Type<ListType<ImageType>>();
        }
    }
}