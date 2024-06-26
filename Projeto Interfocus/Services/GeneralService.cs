using ProjetoInterfocus.Entidades;

namespace ProjetoInterfocus.Services{
    public class GeneralService{
        public static float SomarDividas(Cliente cliente){
            float soma = 0;
            foreach(var divida in cliente.DividasDoCliente){
                if(divida.Situacao == false){
                    soma += divida.Valor;
                }
            }
            cliente.TotalEmAberto = soma;
            return soma;
        }
    }
}