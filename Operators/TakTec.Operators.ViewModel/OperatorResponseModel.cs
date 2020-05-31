using EthioArt.Backend.Models;
using EthioArt.Backend.Models.Responses;

namespace TakTec.Operators.ViewModel
{
    public class OperatorResponseModel : ResponseBase
    {
        public OperatorViewModel Operator { get; set; } = default!;
    }
}