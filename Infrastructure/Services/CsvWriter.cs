using System;
using System.IO;
using System.Text;
using TesteFullStackPleno.Core.Entities;

namespace TesteFullStackPleno.Infrastructure.Services
{
    public static class CsvWriter
    {
        public static void Write(Comportamento comportamento)
        {
            var csvBuilder = new StringBuilder();

            var fileName = DateTime.Now.ToShortDateString().Replace('/', ' ') + ".csv";

            var columnOne = comportamento.Id;
            var columnTwo = comportamento.Nome;
            var columnThree = comportamento.Ip;
            var columnFour = comportamento.Browser;
            var columnFive = string.IsNullOrWhiteSpace(comportamento.Parametros) ? "null" : comportamento.Parametros;

            var linha = $"{columnOne}, {columnTwo}, {columnThree}, {columnFour}, {columnFive}";

            csvBuilder.Append(linha);

            File.AppendAllLines(fileName, new string[] { csvBuilder.ToString() });
        }
    }
}
