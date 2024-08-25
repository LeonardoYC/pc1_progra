using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pc1_progra.Models
{

        public class Operar_Bolsa
    {
        public string nomInversor { get; set; }
        public string emailInversor { get; set; }
        public DateTime fechOperacion { get; set; }
        public List<string> nomInst { get; set; }
        public decimal montoAbonar { get; set; }
        public decimal igv { get; set; }
        public decimal precioInt { get; set; }
        public decimal montoTotal { get; set; }
        public decimal comision { get; set; }
        public decimal totalPagar { get; set; }
        public decimal diferencia { get; set; }

        public void CalcularMontoTotal()
        {
            precioInt = 0m;

            if (nomInst != null)
            {
                foreach (var inst in nomInst)
                {
                    switch (inst)
                    {
                        case "S&P 500":
                            precioInt += 500m;
                            break;
                        case "Dow Jones":
                            precioInt += 300m;
                            break;
                        case "Bonos US":
                            precioInt += 120m;
                            break;
                    }
                }
            }

            comision = precioInt >= 300m ? 1m : 3m;


            igv = precioInt * 0.18m;


            montoTotal = precioInt + igv + comision;


            diferencia = montoAbonar > montoTotal ? montoAbonar - montoTotal : 0;

            totalPagar = montoAbonar - montoTotal;
        }


        public List<Operar_Bolsa> GetInstrumentosSeleccionados()
        {
            var resultados = new List<Operar_Bolsa>();
            var precios = new Dictionary<string, decimal>
            {
                { "S&P 500", 500m },
                { "Dow Jones", 300m },
                { "Bonos US", 120m }
            };

            foreach (var instrumento in nomInst ?? new List<string>())
            {
                if (precios.TryGetValue(instrumento, out var precio))
                {
                    decimal igv = precio * 0.18m;
                    decimal comision = precio >= 300m ? 1m : 3m;
                    var montoTotal = precio + igv + comision;

                    var diferencia = montoAbonar > montoTotal ? montoAbonar - montoTotal : 0;

                    resultados.Add(new Operar_Bolsa
                    {
                        nomInst = new List<string> { instrumento },
                        igv = igv,
                        precioInt = precio,
                        comision = comision,
                        montoTotal = montoTotal,
                        diferencia = diferencia,
                        totalPagar = montoAbonar - montoTotal,
                        fechOperacion = fechOperacion
                    });
                }
            }

            return resultados;
        }
    }

}
