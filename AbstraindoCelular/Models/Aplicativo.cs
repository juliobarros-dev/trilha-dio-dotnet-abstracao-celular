namespace AbstraindoCelular.Models
{
  public class Aplicativo
  {
    public string Nome { get; set; } = string.Empty;
    public int Tamanho { get; set; }
    public List<string> ModelosCompativeis { get; set; } = new();

    public Aplicativo(string nome, int tamanho, List<string> modelosCompativeis)
    {
      Nome = nome;
      Tamanho = tamanho;
      ModelosCompativeis = modelosCompativeis;
    }
  }
}
