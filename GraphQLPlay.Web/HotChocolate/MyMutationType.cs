using HotChocolate.Types;

namespace GraphQLPlay.HotChocolate
{
    public class MyMutationType : ObjectType<MyMutation>
    {
        protected override void Configure(IObjectTypeDescriptor<MyMutation> descriptor)
        {
            descriptor.Field(m => m.RenameClone(default, default))
                .Type<NonNullType<CloneType>>()
                .Argument("cloneId", a => a.Type<NonNullType<StringType>>())
                .Argument("newName", a => a.Type<NonNullType<StringType>>());
        }
    }
}