using CustomerControl.CrossCutting.Dto.ViaCep;
using CustomerControl.CrossCutting.Helper;
using NUnit.Framework;
using RestSharp;
using System.Linq;

namespace Herpers.Test
{
    public class ApiHelperTest
    {
        private const string CEP_REQUEST = "19063747";
        private const string CEP = "19063-747";
        private const string LOGRADOURO = "Rua Maria Angela de Oliveira Esterque";
        private const string COMPLEMENTO = "";
        private const string BAIRRO = "Jardim Santa Fé";
        private const string LOCALIDADE = "Presidente Prudente";
        private const string UF = "SP";

        private readonly string URL_CLIENT = $"https://viacep.com.br/ws/{CEP_REQUEST}/json";
        private readonly string ERROR_URL_CLIENT = $"https://viacep.com.br/ws/123456789/json";
        private ApiHelper<ViaCepDTO> _apiHelper;

        [SetUp]
        public void Setup()
        {
            _apiHelper = new ApiHelper<ViaCepDTO>();
        }

        [Test]
        public void Deve_retornar_dados_corretamente_se_parametro_estiver_correto()
        {
            var responseList = _apiHelper.SendRequest(URL_CLIENT, Method.GET);
            var responseItem = responseList.Data.FirstOrDefault();

            Assert.IsNotNull(responseItem);
            Assert.AreEqual(responseItem.Cep, CEP);
            Assert.AreEqual(responseItem.Logradouro, LOGRADOURO);
            Assert.AreEqual(responseItem.Complemento, COMPLEMENTO);
            Assert.AreEqual(responseItem.Bairro, BAIRRO);
            Assert.AreEqual(responseItem.Localidade, LOCALIDADE);
            Assert.AreEqual(responseItem.Uf, UF);
        }

        [Test]
        public void Deve_retornar_nulo_se_parametro_estiver_incorreto()
        {
            var responseList = _apiHelper.SendRequest(ERROR_URL_CLIENT, Method.GET);
            var responseItem = responseList.Data.FirstOrDefault();

            Assert.IsNull(responseItem);
        }
    }
}