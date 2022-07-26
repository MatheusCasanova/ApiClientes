using ApiClientes.Infra.Data.Entities;
using ApiClientes.Infra.Data.Interfaces;
using ApiClientes.Services.Requests;
using ApiClientes.Services.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //atributo
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //construtor para injeção de dependência
        public ClientesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(ClientePostRequest request)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(request);
                cliente.IdCliente = Guid.NewGuid();

                var retorno = ValidarCliente(cliente.Email, cliente.Cpf, cliente.DataNascimento);

                var exceptions = new List<Exception>();

                if (retorno.Count > 0)
                {
                    foreach (var ex in retorno)
                    {
                        exceptions.Add(new Exception(ex));
                    }

                    throw new AggregateException("Erro(s): ", exceptions);
                }
                else
                {                   
                    _unitOfWork.ClienteRepository.Inserir(cliente);

                    var response = _mapper.Map<ClienteResponse>(cliente);

                    return StatusCode(201, response);
                }
                                                    
            }
            catch(AggregateException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClientePutRequest request)
        {
            try
            {
                var cliente = _unitOfWork.ClienteRepository.ObterPorId(request.IdCliente);                

                if (cliente == null)
                    return StatusCode(422, new { message = "Cliente não encontrado, verifique o ID informado." });

                var clienteEmailBanco = _unitOfWork.ClienteRepository.ObterPorEmail(request.Email);
                var clienteCpfBanco = _unitOfWork.ClienteRepository.ObterPorCpf(request.Cpf);

                if (clienteEmailBanco != null && cliente.IdCliente != clienteEmailBanco.IdCliente)
                    return StatusCode(422, new { message = "E-mail já está cadastrado para outro cliente." });

                if (clienteCpfBanco != null && cliente.IdCliente != clienteCpfBanco.IdCliente)
                    return StatusCode(422, new { message = "CPF já está cadastrado para outro cliente." });

                if (!ValidarIdade(request.DataNascimento))
                    return StatusCode(422, new { message = "O Cliente é menor de idade." });
                              
                _mapper.Map(request, cliente);

                _unitOfWork.ClienteRepository.Alterar(cliente);

                var response = _mapper.Map<ClienteResponse>(cliente);

                return StatusCode(200, response);                               
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(Guid idCliente)
        {
            try
            {
                var cliente = _unitOfWork.ClienteRepository.ObterPorId(idCliente);

                if (cliente == null)
                    return StatusCode(422, new { message = "Cliente não encontrado, verifique o ID informado." });

                _unitOfWork.ClienteRepository.Excluir(cliente);

                var response = _mapper.Map<ClienteResponse>(cliente);

                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var clientes = _unitOfWork.ClienteRepository.Consultar();
                var lista = _mapper.Map<List<ClienteResponse>>(clientes);

                if (lista.Count > 0)
                    return StatusCode(200, lista);
                else
                    return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(Guid idCliente)
        {
            try
            {
                var cliente = _unitOfWork.ClienteRepository.ObterPorId(idCliente);

                if (cliente != null)
                {
                    var response = _mapper.Map<ClienteResponse>(cliente);
                    return StatusCode(200, response);
                }
                else
                    return StatusCode(204);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private List<string> ValidarCliente(string email, string cpf, DateTime dataNascimento)
        {
            List<string> erros = new List<string>();

            if (_unitOfWork.ClienteRepository.ObterPorEmail(email) != null)
                erros.Add("E-mail já cadastrado.");

            if (_unitOfWork.ClienteRepository.ObterPorCpf(cpf) != null)
                erros.Add("CPF já cadastrado.");

            if (!ValidarIdade(dataNascimento))
                erros.Add("O Cliente é menor de idade.");

            return erros;
        }

        private bool ValidarIdade(DateTime dataNascimento)
        {

            if (DateTime.Now.Year - dataNascimento.Year > 18)
                return true;

            if (DateTime.Now.Year - dataNascimento.Year < 18)
                return false;

            if (DateTime.Now.Month - dataNascimento.Month < 0)
                return false;

            if (DateTime.Now.Day - dataNascimento.Day < 0)
                return false;

            return true;
        }
    }
}
