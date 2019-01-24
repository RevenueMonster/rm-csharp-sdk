using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueMonsterOpenAPI.Model
{
    public class IssueVoucher
    {
        public string code { get; set; }
        public string qrUrl { get; set; }
    }

    public class IssueVoucherResult{
        public IssueVoucher item { get; set; }
        public string code { get; set; }
        public Error error { get; set; }
    }

    public class VoidVoucherResult
    {
        public Voucher item { get; set; }
        public string code { get; set; }
        public Error error { get; set; }
    }

    public class GetVoucherByCodeResult
    {
        public Voucher item { get; set; }
        public string code { get; set; }
        public Error error { get; set; }
    }

    public class GetVoucherBatchesResult
    {
        public List<Voucher> items { get; set; }
        public string code { get; set; }
        public Error error { get; set; }
    }

    public class GetVoucherBatchByKeyResult
    {
        public Voucher item { get; set; }
        public string code { get; set; }
        public Error error { get; set; }
    }

    public class Voucher
    {
        public string id { get; set; }
        public string key { get; set; }
        public string label { get; set; }
        public string redemptionRuleKey { get; set; }
        public string voucherBatchKey { get; set; }
        public string type { get; set; }
        public Int64 quantity { get; set; }
        public Int64 balanceQuantity { get; set; }
        public Int64 usedQuantity { get; set; }
        public Int64 amount { get; set; }
        public Int64 discountRate { get; set; }
        public Int64 minimumSpendAmount { get; set; }
        public string origin { get; set; }
        public string imageUrl { get; set; }
        public string memberProfile { get; set; }
        public string assignedAt { get; set; }
        public string payload { get; set; }
        public string qrUrl { get; set; }
        public string code { get; set; }
        public bool isShipping { get; set; }
        public Address address { get; set; }
        public Expiry expiry { get; set; }
        public string usedAt { get; set; }
        public string redeemedAt { get; set; }
        public bool isDeviceRedeem { get; set; }
        public string status { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}
