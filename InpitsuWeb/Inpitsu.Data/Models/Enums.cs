using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public enum TypeCard
    {
        Humo,
        Uzcard,
        Mastercard,
        Visa,
        UnionPay,
        MasterCobage
    }
    public enum TypePaySystem
    {
        Humo,
        Uzcard,
        Mastercard,
        Visa,
        UnionPay
    }
    public enum Status
    {
        Create,
        Activate,
        Deactivate,
        Deleted,
        Refusal
    }
    public enum StatusApplication
    {
        NotApprove,
        Approve,
        ClientFail,
        Success,
        Rejection
    }
    public enum StatusDelivery
    {
        ToEmission,
        ToRelease,
        ToDelivery,
        OnTheWay,
        Delivered,
        Refusal
    }
}
