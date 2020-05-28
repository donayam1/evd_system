using EthioArt.Backend.Models;
namespace TakTec.Operators.ViewModel
{
    public class OperatorResponseModel:EthioArt.Backend.Models.Responses.ResponseBase
    {
       public OperatorViewModel operatorVM {get;set;}=default;
    }
}