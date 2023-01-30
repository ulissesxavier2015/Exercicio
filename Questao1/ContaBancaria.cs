using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        public int _numero { get; set; }
        public string _titular { get; set; }
        public double _depositoInicial { get; set; }
        public double _saldo { get; set; }
        public ContaBancaria(int numero, string titular)
        {
            _numero = numero;
            _titular = titular;
            _depositoInicial= 0.0;
            _saldo = 0.0;
        }
        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            _numero = numero;
            _titular = titular;
            _depositoInicial = depositoInicial;
            _saldo += depositoInicial;
        }

        public void Deposito(double quantia)
        {
            _saldo += quantia;
        }
        public void Saque(double quantia)
        {
            _saldo -= quantia;
        }
        public string Consulta()
        {
            return $"Conta {_numero}, Titular: {_titular}, Saldo: $ {_saldo}";
        }
        }
    }
