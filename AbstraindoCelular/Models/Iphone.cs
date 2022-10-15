namespace AbstraindoCelular.Models
{
  public class Iphone : Smartphone
  {
    public Iphone(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
    {
    }

    public override async void InstalarAplicativo(Aplicativo app)
    {
      Console.WriteLine($"Iniciando instalação de {app.Nome} em seu iPhone.");
      Console.Write("\n Analisando");

      for (int index = 1; index <= 3; index++)
      {
        await Task.Delay(1000);
        Console.Write(". ");
      }

      if (!TemMemoria(app.Tamanho))
      {
        Console.WriteLine($"\nMemoria insuficiente para instalar {app.Nome}");
        return;
      }

      Console.Write("\n Instalando ");
      for (int index = 1; index <= 3; index++)
      {
        await Task.Delay(1000);
        Console.Write(". ");
      }

      OcuparMemoria(app.Tamanho);
      Aplicativos.Add(app);

      Console.WriteLine($"\n{app.Nome} instalado com sucesso!");
      return;
    }

    public override async void DesinstalarAplicativoAsync(Aplicativo app)
    {
      Console.Write("\n Deinstalando");
      for (int index = 1; index <= 3; index++)
      {
        await Task.Delay(1000);
        Console.Write(". ");
      }

      Aplicativos.Remove(app);
      RestaurarMemoria(app.Tamanho);

      Console.WriteLine($"{app.Nome} desinstalado.");
      return;
    }
  }
}
