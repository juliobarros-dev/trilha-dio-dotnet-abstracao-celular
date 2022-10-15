namespace AbstraindoCelular.Models
{
  public abstract class Smartphone
  {
    public string Numero { get; set; } = string.Empty;
    private string Modelo { get; set; } = string.Empty;
    private string IMEI { get; set; } = string.Empty;
    private int Memoria { get; set; }
    public List<Aplicativo> Aplicativos { get; set; } = new();

    public Smartphone(string numero, string modelo, string imei, int memoria)
    {
      Numero = numero;
      Modelo = modelo;
      IMEI = imei;
      Memoria = memoria;
    }

    public void Ligar(string numero)
    {
      Console.WriteLine($"Ligando para {numero}");
    }

    public void ReceberLigacao(string numero)
    {
      Console.WriteLine($"Recebendo ligação de {numero}");
    }

    public void MostrarConfiguracoes()
    {
      Console.WriteLine("Especificações do seu aparelho:");
      Console.WriteLine($"- Modelo: {Modelo}");
      Console.WriteLine($"- Numero: {Numero}");
      Console.WriteLine($"- IMEI: {IMEI}");
      Console.WriteLine($"- Memória disponível: {Memoria}");
    }
    public abstract void InstalarAplicativo(Aplicativo aplicativo);
    public abstract void DesinstalarAplicativoAsync(Aplicativo aplicativo);
    public void ListarAplicativos()
    {
      if (!Aplicativos.Any())
      {
        Console.WriteLine("Nenhum aplicativo instalado.");
        return;
      }

      foreach (var app in Aplicativos)
      {
        Console.WriteLine($"- {app.Nome}");
      }

      return;
    }
    public bool TemMemoria(int tamanho) => tamanho < Memoria;
    public void OcuparMemoria(int tamanho) => Memoria -= tamanho;
    public void RestaurarMemoria(int tamanho) => Memoria += tamanho;
    public string MostrarModelo() => Modelo;
  }
}
