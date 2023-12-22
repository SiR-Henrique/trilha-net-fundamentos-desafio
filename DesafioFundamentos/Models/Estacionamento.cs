using System.Diagnostics.Contracts;
using System.Security;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        List<String> veiculo = new List<string>();
        
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            String placa = Console.ReadLine();

            if (placa.Length == 7)
            {
            veiculo.Add(placa);
            Console.WriteLine($"O veiculo com a placa {placa} foi adicionado com sucesso");
            }
            else
            {
                Console.WriteLine("Placa invalida, veiculo não adicionado.");
            }
        }


        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
       
            do
            {
                if (placa.Length != 7)
                {
                    Console.WriteLine($"A placa {placa} não é válida. Deve ter 7 caracteres.");
                }
            } while (placa.Length != 7);

            if (veiculo.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas;
                bool valido = false;

                do
                {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out horas))
                    {
                        valido = true;
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Digite somente números inteiros.");
                    }
                } 
                while (!valido);

                decimal valorTotal = (precoInicial + (precoPorHora*horas));
                veiculo.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }


        public void ListarVeiculos()
        {
            if (veiculo.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var placa in veiculo)
                {
                    Console.WriteLine(placa);
                }
                
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
