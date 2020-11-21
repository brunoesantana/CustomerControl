using CustomerControl.Business.Base;
using CustomerControl.Business.Interface;
using CustomerControl.CrossCutting.Dto.ViaCep;
using CustomerControl.CrossCutting.Filter;
using CustomerControl.CrossCutting.Helper;
using CustomerControl.Data.Interface;
using CustomerControl.Domain;
using RestSharp;
using System;
using System.Linq;
using System.Net;

namespace CustomerControl.Business.Service
{
    public class CustomerService : BaseService<Customer, CustomerFilter>, ICustomerService
    {
        private const string URL_CLIENT = "https://viacep.com.br/ws/";

        private readonly ApiHelper<ViaCepDTO> _apiHelper;

        public CustomerService(ICustomerRepository repository) : base(repository)
        {
            _apiHelper = new ApiHelper<ViaCepDTO>();
        }

        public override Guid Create(Customer dto)
        {
            var viaCepDto = GetViaCepInfo(dto.Cep);

            if (viaCepDto != null)
            {
                dto.Adress = viaCepDto.Logradouro;
                dto.Cep = viaCepDto.Cep;
                dto.City = viaCepDto.Localidade;
                dto.Complement = viaCepDto.Complemento;
                dto.Neighborhood = viaCepDto.Bairro;
                dto.State = viaCepDto.Uf;
            }

            return base.Create(dto);
        }

        public ViaCepDTO GetViaCepInfo(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return null;

            var url = $"{URL_CLIENT}{cep}/json";
            var response = _apiHelper.SendRequest(url, Method.GET);

            if (string.IsNullOrWhiteSpace(response.Content) || response.StatusCode != HttpStatusCode.OK || response.Data == null || !response.Data.Any())
                return null;

            return response.Data.FirstOrDefault();
        }
    }
}