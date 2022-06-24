using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/Elevador")]
    [ApiController]
    public class ElevadorController : ControllerBase
    {
        private IElevadorService _service;
        public ElevadorController(IElevadorService Service)
        {
            _service = Service;
        }

        [HttpGet("AndarMenosUtilizado")]
        public List<int> AndarMenosUtilizado()
        {
            return _service.andarMenosUtilizado();
        }

        [HttpGet("ElevadorMaisFrequentado")]
        public List<char> ElevadorMaisFrequentado()
        {
            return _service.elevadorMaisFrequentado();
        }

        [HttpGet("ElevadorMenosFrequentado")]
        public List<char> ElevadorMenosFrequentado()
        {
            return _service.elevadorMenosFrequentado();
        }

        [HttpGet("PercentualDeUsoElevadorA")]
        public float PercentualDeUsoElevadorA()
        {
            return _service.percentualDeUsoElevadorA();
        }

        [HttpGet("PercentualDeUsoElevadorB")]
        public float PercentualDeUsoElevadorB()
        {
            return _service.percentualDeUsoElevadorB();
        }

        [HttpGet("PercentualDeUsoElevadorC")]
        public float PercentualDeUsoElevadorC()
        {
            return _service.percentualDeUsoElevadorC();
        }

        [HttpGet("PercentualDeUsoElevadorD")]
        public float PercentualDeUsoElevadorD()
        {
            return _service.percentualDeUsoElevadorD();
        }

        [HttpGet("PercentualDeUsoElevadorE")]
        public float PercentualDeUsoElevadorE()
        {
            return _service.percentualDeUsoElevadorE();
        }

        [HttpGet("PeriodoMaiorFluxoElevadorMaisFrequentado")]
        public List<char> PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            return _service.periodoMaiorFluxoElevadorMaisFrequentado();
        }

        [HttpGet("PeriodoMaiorUtilizacaoConjuntoElevadores")]
        public List<char> PeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            return _service.periodoMaiorUtilizacaoConjuntoElevadores();
        }

        [HttpGet("PeriodoMenorFluxoElevadorMenosFrequentado")]
        public List<char> PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            return _service.periodoMenorFluxoElevadorMenosFrequentado();
        }
    }
    
}
