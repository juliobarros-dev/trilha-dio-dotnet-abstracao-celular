namespace AbstraindoCelular.Models
{
  public class Nokia : Smartphone
  {
    public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
    {
    }

    public override void InstalarAplicativo(Aplicativo app)
    {
      Console.WriteLine($"\nIniciando instalação de {app.Nome} em seu Nokia.");

      if (!TemMemoria(app.Tamanho))
      {
        Console.WriteLine($"\nMemoria insuficiente para instalar {app.Nome}");
        return;
      }

      OcuparMemoria(app.Tamanho);
      Aplicativos.Add(app);

      Console.WriteLine($"\n{app.Nome} instalado com sucesso!");
      return;
    }

    public override void DesinstalarAplicativoAsync(Aplicativo app)
    {
      Console.WriteLine("\n Desinstalando...");

      Aplicativos.Remove(app);
      RestaurarMemoria(app.Tamanho);

      Console.WriteLine($"{app.Nome} desinstalado.");
      return;
    }
  }
}
