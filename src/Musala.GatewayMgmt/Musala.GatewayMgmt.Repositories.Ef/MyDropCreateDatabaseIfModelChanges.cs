using System.Data.Entity;

namespace Musala.GatewayMgmt.Repositories.Ef
{
    /// <summary>
    /// A custom implementation of GatewayMgmtContext that creates a new contact person with address details.
    /// </summary>
    public class MyDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<GatewayMgmtContext>
    {
        /// <summary>
        /// Creates a new contact person.
        /// </summary>
        /// <param name="context">The context to which the new seed data is added.</param>
        protected override void Seed(GatewayMgmtContext context)
        {
            //var person = new Person
            //{
            //    FirstName = "David",
            //    LastName = "Barrera",
            //    DateOfBirth = new DateTime(1984, 10, 02),
            //    Type = PersonType.Friend,
            //    HomeAddress = CreateAddress(),
            //    WorkAddress = CreateAddress()
            //};
            //context.People.Add(person);
        }
    }
}
