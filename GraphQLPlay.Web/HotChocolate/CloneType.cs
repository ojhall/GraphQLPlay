using GraphQLPlay.Data;
using HotChocolate.Types;

namespace GraphQLPlay.HotChocolate
{
    public class CloneType : ObjectType<CloneEf>
    {
        protected override void Configure(IObjectTypeDescriptor<CloneEf> descriptor)
        {
            descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
            descriptor.Field(c => c.Name).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.ParentImage).Type<NonNullType<ImageType>>();
        }
    }
}