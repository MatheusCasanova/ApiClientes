using ApiClientes.Services.Requests;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bogus.Extensions.Brazil;
using Newtonsoft.Json;
using System.Net.Http;
using ApiClientes.Tests.Helpers;
using FluentAssertions;
using System.Net;

namespace ApiClientes.Tests.TestCases
{
    /// <summary>
    /// classe de teste para os serviços de cliente da API
    /// </summary>
    public class ClientesTest
    {
        [Fact]
        public async void Post_Clientes_Return_Ok()
        {
            var faker = new Faker("pt_BR");

            #region Criando os dados da requisição

            var request = new ClientePostRequest
            {
                Nome = faker.Name.FullName(),
                Email = faker.Internet.Email(),
                Cpf = faker.Person.Cpf(),
                DataNascimento = faker.Date.Past()
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            #endregion

            #region Executando o serviço da API

            var client = new HttpClient();

            var response = await client.PostAsync($"{ApiHelper.Endpoint}/Clientes", content);

            #endregion

            #region Validar o resultado do teste

            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            #endregion
        }

        [Fact(Skip = "Não implementado.")]
        public void Put_Clientes_Return_Ok()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void Put_Clientes_Return_UnprocessableEntity()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void Delete_Clientes_Return_Ok()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void Delete_Clientes_Return_UnprocessableEntity()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void GetAll_Clientes_Return_Ok()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void GetById_Clientes_Return_Ok()
        {

        }
    }
}
