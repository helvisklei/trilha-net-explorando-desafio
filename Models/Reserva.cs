using System.Reflection;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados; 
            
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar a capacidade é maior ou igual ao número de hóspedes sendo recebido            
            if (Suite.Capacidade >= hospedes.Count )
            {
                Hospedes = hospedes;
            }
            else
            {  
                 // Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido                                
                Console.WriteLine($"Não Há suites disponiveis para essa quantidade de pessoas {hospedes.Count}");
                throw new Exception($"A capacidade máxima da suite é para {Suite.Capacidade} pessoas");            
            }    
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite; 
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)            
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {                     
            decimal valor = 0;
            
           valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Os dias reservados forem maior ou igual a 10, conceder um desconto de 10%            
            if (DiasReservados >= 10)
            {
                valor = valor - (valor * 0.1M);
            }

            return valor;
        }

    }
}