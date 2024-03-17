using CaseMSA.Application.DTOs.ViewModel;

namespace CaseMSA.Application.ServiceResponse
{
    public class Response
    {
        public string Mensagem { get; set; }
        public Object Dados { get; set; }
        public bool Sucesso { get; set; }

        public Response(Guid id)
        {
            Mensagem = "Requisição efetuada com sucesso!";
            Dados = id;
            Sucesso = true;
        }

        public Response(IEnumerable<MemberViewModel> viewModelList)
        {
            Mensagem = "Requisição efetuada com sucesso!";
            Dados = viewModelList;
            Sucesso = true;
        }

        public Response(MemberViewModel viewModelList)
        {
            Mensagem = "Requisição efetuada com sucesso!";
            Dados = viewModelList;
            Sucesso = true;
        }
    }
}
