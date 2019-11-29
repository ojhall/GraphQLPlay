using GraphQLPlay.Data;
using HotChocolate.Types;

namespace GraphQLPlay.HotChocolate
{
    public class ImageType : ObjectType<ImageEf>
    {
        protected override void Configure(IObjectTypeDescriptor<ImageEf> descriptor)
        {
            descriptor.Field(i => i.Id).Type<NonNullType<IdType>>();
            descriptor.Field(i => i.Name).Type<NonNullType<StringType>>();
        }
    }
}