using System.Runtime.Serialization;

namespace Ecommerce.Domain
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Payment processed")]
        Completed,
        [EnumMember(Value = "Product shipped")]
        Shipped,
        [EnumMember(Value = "There was an error in the payment")]
        Error
    }
}
