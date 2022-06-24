using Domain;
using Newtonsoft.Json;
using Service.Intefaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service.Implementations
{
    public class ElevadorService : IElevadorService
    {
        List<Questionario> questionarios = new List<Questionario>();

        public ElevadorService()
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\Data\dados.json"))
            {
                var json = r.ReadToEnd();
                questionarios = JsonConvert.DeserializeObject<List<Questionario>>(json);
            }
        }
        public List<int> andarMenosUtilizado()
        {
            Dictionary<int, int> list = new Dictionary<int, int>();

            for (int i = 0; i <= 15; i++)
            {
                list.Add(i, questionarios.Where(w => w.Andar == i).Count());
            }

            var result = list.OrderBy(x => x.Value).Select(x => x.Key);
            return result.ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {
            var list = questionarios.GroupBy(g => g.Elevador).OrderByDescending(o => o.Count()).Select(s => s.Key).ToList();
            
            return list;
        }

        public List<char> elevadorMenosFrequentado()
        {
            var list = questionarios.GroupBy(g => g.Elevador).OrderBy(o => o.Count()).Select(s => s.Key).ToList();

            return list;
        }

        public float percentualDeUsoElevadorA()
        {
            var list = questionarios.Where(w => w.Elevador == 'A').Select(s => s.Elevador).Count();
            var pencentual = ((float)list / (float)questionarios.Count()) * 100;

            return pencentual;
        }

        public float percentualDeUsoElevadorB()
        {
            var list = questionarios.Where(w => w.Elevador == 'B').Select(s => s.Elevador).Count();
            var pencentual = ((float)list / (float)questionarios.Count()) * 100;

            return pencentual;
        }

        public float percentualDeUsoElevadorC()
        {
            var list = questionarios.Where(w => w.Elevador == 'C').Select(s => s.Elevador).Count();
            var pencentual = ((float)list / (float)questionarios.Count()) * 100;

            return pencentual;
        }

        public float percentualDeUsoElevadorD()
        {
            var list = questionarios.Where(w => w.Elevador == 'D').Select(s => s.Elevador).Count();
            var pencentual = ((float)list / (float)questionarios.Count()) * 100;

            return pencentual;
        }

        public float percentualDeUsoElevadorE()
        {
            var list = questionarios.Where(w => w.Elevador == 'E').Select(s => s.Elevador).Count();
            var pencentual = ((float)list / (float)questionarios.Count()) * 100;

            return pencentual;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var Frequencia = elevadorMaisFrequentado();

            var list = questionarios.Where(w => w.Elevador == Frequencia[0]).GroupBy(g => g.Turno).OrderByDescending(o => o.Count()).Select(s => s.Key).ToList();
            
            return list;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var list = questionarios.GroupBy(g => g.Turno).OrderByDescending(o => o.Count()).Select(s => s.Key).ToList();
            
            return list;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var Frequencia = elevadorMenosFrequentado();

            Dictionary<char, int> turnos = new Dictionary<char, int>();
            turnos.Add('M', questionarios.Where(w => w.Elevador == Frequencia[0] && w.Turno == 'M').Count());
            turnos.Add('V', questionarios.Where(w => w.Elevador == Frequencia[0] && w.Turno == 'V').Count());
            turnos.Add('N', questionarios.Where(w => w.Elevador == Frequencia[0] && w.Turno == 'N').Count());

            var list = turnos.OrderBy(x => x.Value).Select(x => x.Key).ToList();

            return list;
        }
    }
}
