using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class Logica
    {
        List<string> lines;
        int countLine = 0;
        List<string> columns;
        string vendedor = "";
        string codigo = "";
        decimal valor = 0;
        int quantidade = 0;
        float ignore = 0;
        DateTime data = DateTime.Now;
        List<VendaTO> result = new List<VendaTO>();
        VendaTO venda = new VendaTO();

        /// <summary>
        /// Metodo recebe um numero em texto usando separador . como separador de milhar e , como separador decimal
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        internal decimal ConverteStringParaDecimal(string numeroString)
        {
            decimal decimalFormatado = 0;

            return decimalFormatado = decimal.Parse(numeroString);
        }

        /// <summary>
        /// Metodo recebe uma data em texto no formato dd/MM/yyyy e retorna a data convertida
        /// </summary>
        /// <param name="dataString"></param>
        /// <returns></returns>
        internal DateTime ConverteStringParaData(string dataString)
        {
            DateTime dataFormatado = DateTime.Now;
            return dataFormatado = DateTime.Parse(dataString);
        }

        /// <summary>
        /// Vendedor Gustavo
        /// Código Produto	quantidade    valor total 	     Data venda
        /// ARA-1012	    17 UN          R$ 3.642,17 	         08/04/2021
        /// </summary>
        /// <param name="produtosString"></param>
        /// <returns></returns>
        internal List<VendaTO> ConverteStringParaVendas(string produtosString)
        {
            lines = produtosString.Split('\n').ToList();
            foreach (var line in lines)
            {
                if (line != "" && line != "        ")
                {
                    countLine++;
                    columns = line.Split(' ')
                   .Select(column => column.Replace('\r', ' ').Replace("\t", "").Trim())
                   .Where(column => !string.IsNullOrWhiteSpace(column))
                   .ToList();

                    if (columns.Count == 2)
                    {
                        vendedor = columns[1];
                    }

                    if (columns.Count == 6)
                    {
                        codigo = columns[0];
                        if (float.TryParse(columns[1], out ignore))
                        {
                            valor = decimal.Parse(columns[4]);
                            quantidade = int.Parse(columns[1]);
                            data = DateTime.Parse(columns[5]);
                            VendaTO venda = new VendaTO
                            {
                                Vendedor = vendedor,
                                Codigo = codigo,
                                Quantidade = quantidade,
                                Valor = valor,
                                Data = data
                            };
                            result.Add(venda);
                        }
                    }
                }
            }
            return result;
        }

        internal int ConvertStringParaInt(string value)
        {
            int valueInt = 0;
            valueInt = int.Parse(value);
            return valueInt;
        }
    }
}
