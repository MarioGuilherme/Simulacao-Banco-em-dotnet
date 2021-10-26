using System;

namespace DIO.Bank{
    public class Conta{
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome){
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valor){
            if(this.Saldo - valor < (this.Credito * -1)){
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valor;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            return true;
        }

        public void Depositar(double valor){
            this.Saldo += valor;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valor, Conta contaDestino){
            if(this.Sacar(valor)){
                contaDestino.Depositar(valor);
            }
        }

        public override string ToString(){
            string retorno = "";
            retorno += $"Tipo de Conta: {this.TipoConta} | ";
            retorno += $"Nome: {this.Nome} | ";
            retorno += $"Saldo: {this.Saldo} | ";
            retorno += $"Crédito: {this.Credito}\n";
            return retorno;
        }
    }
}