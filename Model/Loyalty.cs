using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueMonsterOpenAPI.Model
{
    public class LoyaltyPoint
    {
        public string code { get; set; }
        public Error error { get; set; }
    }

    public class GetLoyaltyMembersResult
    {
        public List<LoyaltyMember> items { get; set; }
        public Error error { get; set; }
    }

    public class GetLoyaltyMemberResult
    {
        public LoyaltyMember item { get; set; }
        public Error error { get; set; }
    }

    public class LoyaltyMember
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string nric { get; set; }
        public Address address { get; set; }
        public string gender { get; set; }
        public string state { get; set; }
        public string birthDate { get; set; }
        public Int64 loyaltyPoint { get; set; }
        public Int64 credit { get; set; }
        public string countryCode { get; set; }
        public string phoneNumber { get; set; }
        public string profileImageUrl { get; set; }
        public bool hasPinCode { get; set; }
        public LoyaltyMemberTier memberTier { get; set; }
        public string status { get; set; }
        public string createdAt { get; set; }
        public Error error { get; set; }
    }

    public class LoyaltyMemberTier
    {
        public string label { get; set; }
        public Int64 minimumPoint { get; set; }
        public Int64 totalMember { get; set; }
        public string[] description { get; set; }
    }

    public class LoyaltyMemberPointHistories
    {
        public List<LoyaltyMemberPointHistory> items { get; set; }
        public Error error { get; set; }
    }

    public class LoyaltyMemberPointHistory
    {
        public string key { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public Int64 point { get; set; }
        public Int64 credit { get; set; }
        public Int64 creditBalance { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}
