using Api.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB) 
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadosDto dto) 
        {
            DateTime date = DateTime.Now;
            string dataConvert = Convert.ToString(dto.DataNascimento);
            string data = dataConvert.Substring(dataConvert.Length-13, 4);
            string dataAtualConvert = Convert.ToString(date);
            string dataAtual = dataAtualConvert.Substring(dataAtualConvert.Length - 13, 4);
            int anoNasc = Convert.ToInt32(data);
            int anoAtual = Convert.ToInt32(dataAtual);
            dto.Idade = anoAtual - anoNasc;
            var infectado = new Infectado(dto.DataNascimento,dto.Idade, dto.Sexo, dto.Latitude, dto.Longitude);
            _infectadosCollection.InsertOne(infectado);
            return StatusCode(201, "Infectado adicionado com sucesso");
        }
        [HttpGet]
        public ActionResult ObterInfectados() 
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            return Ok(infectados);
        }
        [HttpPut]
        public ActionResult AtualizarInfectado([FromBody] InfectadosDto dto) 
        {
            var infectado = new Infectado(dto.DataNascimento,dto.Idade, dto.Sexo, dto.Latitude, dto.Longitude);
            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.DataNascimento == dto.DataNascimento), Builders<Infectado>.Update.Set("sexo", dto.Sexo));
            return Ok("Atualizado com sucesso");
        }
        [HttpDelete("{dataNasc}")]
        public ActionResult DeletarInfectado(DateTime dataNasc)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.DataNascimento == dataNasc));
            return Ok("Atualizado com sucesso");
        }
    }
}
