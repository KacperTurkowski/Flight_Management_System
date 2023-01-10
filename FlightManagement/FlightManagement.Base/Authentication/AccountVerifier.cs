using FlightManagement.Data.Models;

namespace FlightManagement.Base.Authentication
{
    public class AccountVerifier
    {
        private readonly Lazy<List<CrewMember>> _crewMembers;

        public AccountVerifier()
        {
            _crewMembers = new Lazy<List<CrewMember>>(new CrewMemberRepository().GetMembersToApplication());
        }
        public CrewMember? Verify(string login, string password)
        {
            return _crewMembers.Value.SingleOrDefault(x => x.CrwEmail == login && x.CrwPassword == password);
        }
    }
}
