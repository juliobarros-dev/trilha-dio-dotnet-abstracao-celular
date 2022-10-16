using AbstraindoCelular.Models;
using System;
using System.Text;
// TODO: Realizar os testes com as classes Nokia e Iphone

Nokia nokia = new("11941526374", "Super Nokia Tijolão", "HUWN3UH4S", 128);
Iphone iPhone = new("11936251496", "iPhone XL", "JANMSIJHE2", 256);

List<Smartphone> smartphones = new List<Smartphone>();

smartphones.Add(nokia);
smartphones.Add(iPhone);

List<Aplicativo> appStore = new();

appStore.Add(new Aplicativo("WhatsApp", 20, new List<string>() { "iPhone", "Nokia" }));
appStore.Add(new Aplicativo("Telegram", 30, new List<string>() { "iPhone" }));
appStore.Add(new Aplicativo("FIFA", 300, new List<string>() { "iPhone", "Nokia" }));
appStore.Add(new Aplicativo("Instagram", 50, new List<string>() { "iPhone", "Nokia" }));

bool showMenu = true;

while (showMenu)
{
  Console.WriteLine("BEM-VINDO!");
  Console.WriteLine("\nEscolha a opção desejada\n");

  int menuIndex = 1;
  foreach (var smartphone in smartphones)
  {
    Console.WriteLine($"{menuIndex} - {smartphone.MostrarModelo()}");
    menuIndex++;
  }

  Console.WriteLine($"3 - Ver AppStore");
  Console.WriteLine("\n0 - Para encerrar a aplicação.");
  Console.WriteLine();

  try
  {
    int inputOption = int.Parse(Console.ReadLine());

  switch (inputOption)
  {
    case 1:
      var cellphone = smartphones[0];
      Console.Clear();
      CellphoneMenu(cellphone, appStore);
      break;
    case 2:
        cellphone = smartphones[1];
        Console.Clear();
        CellphoneMenu(cellphone, appStore);
      break;
    case 3:
      Console.Clear();
      Console.WriteLine("LOJA DE APLICATIVOS");
      Console.WriteLine("\n Aplicativos disponíveis");
      AppStore(appStore);
      Console.WriteLine("\nPressione ENTER para retornar ao menu anterior");
      Console.ReadLine();
      Console.Clear();
      break;
    case 0:
      showMenu = false;
      break;
    default:
      Console.WriteLine("Opção inválida, aperte ENTER para continuar");
      Console.ReadLine();
      break;
  }

  }
  catch (Exception)
  {
    Console.Clear();
  }

  if (!showMenu)
  {
    Console.Clear();
    Console.WriteLine("Sistema encerrado.");
    return;
  }
}

void AppStore(List<Aplicativo> apps)
{
  int index = 1;

  foreach (var app in apps)
  {
    StringBuilder stringBuilder = new StringBuilder();

    Console.WriteLine($"\n{app.Nome.ToUpper()}");
    Console.WriteLine($"-- Tamanho {app.Tamanho}");

    foreach (var modelo in app.ModelosCompativeis)
    {
      stringBuilder.Append($"{modelo}, ");
    }

    Console.Write($"-- Modelos compatíveis: {stringBuilder.ToString().TrimEnd(new[] {' ', ','})}");

    Console.WriteLine();
    index++;
  }
}

void CellphoneMenu(Smartphone cellphone, List<Aplicativo> apps)
{
  bool showMenu = true;

  while (showMenu)
  {
    Console.WriteLine($"Escolhar o que deseja fazer com seu {cellphone.MostrarModelo()}\n");

    Console.WriteLine($"1 - Mostrar configurações");
    Console.WriteLine($"2 - Ver aplicativos instalados");
    Console.WriteLine($"3 - Instalar aplicativo");
    Console.WriteLine($"4 - Desinstalar aplicativo");

    Console.WriteLine("\n0 - Voltar ao Menu anterior");

    try
    {
      int inputOption = int.Parse(Console.ReadLine());

      switch (inputOption)
      {
        case 1:
          Console.Clear();
          cellphone.MostrarConfiguracoes();
          Console.WriteLine("\nPressione ENTER para retornar ao menu anterior");
          Console.ReadLine();
          Console.Clear();
          break;
        case 2:
          Console.Clear();
          cellphone.ListarAplicativos();
          Console.WriteLine("\nPressione ENTER para retornar ao menu anterior");
          Console.ReadLine();
          Console.Clear();
          break;
        case 3:
          Console.Clear();
          Console.Write("Digite o nome do aplicativo que deseja instalar: ");
          string inputApp = Console.ReadLine();
          Aplicativo app = apps.FirstOrDefault(x => x.Nome.ToLower().Contains(inputApp.ToLower()));

          while (app == null && inputApp != "0")
          {
            Console.WriteLine("Aplicativo não encontrado");
            Console.Write("Digite o nome do aplicativo que deseja instalar ou 0 para cancelar a instalação: ");
            inputApp = Console.ReadLine();
            app = apps.FirstOrDefault(x => x.Nome.ToLower().Contains(inputApp.ToLower()));
          }

          if (inputApp == "0") break;

          cellphone.InstalarAplicativo(app);

          Console.WriteLine("\nPressione ENTER para retornar ao menu anterior");
          Console.ReadLine();
          Console.Clear();
          break;
        case 4:
          Console.Clear();
          if (!cellphone.Aplicativos.Any())
          {
            Console.WriteLine("Nenhum aplicativo instalado.");
            Console.WriteLine("\nPressione ENTER para retornar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
            break;
          }

          Console.Write("Digite o nome do aplicativo que deseja desinstalar: ");
          string uninstallApp = Console.ReadLine();
          Aplicativo uninstallingApp = cellphone.Aplicativos.FirstOrDefault(x => x.Nome.ToLower().Contains(uninstallApp.ToLower()));

          while (uninstallingApp == null && uninstallApp != "0")
          {
            Console.WriteLine("Aplicativo não encontrado");
            Console.Write("Digite o nome do aplicativo que deseja desinstalar ou 0 para cancelar: ");
            uninstallApp = Console.ReadLine();
            uninstallingApp = cellphone.Aplicativos.FirstOrDefault(x => x.Nome.ToLower().Contains(uninstallApp.ToLower()));
          }

          if (uninstallApp == "0") break;

          cellphone.DesinstalarAplicativoAsync(uninstallingApp);
          Console.WriteLine("\nPressione ENTER para retornar ao menu anterior");
          Console.ReadLine();
          Console.Clear();
          break;
        case 0:
          showMenu = false;
          Console.Clear();
          break;
        default:
          Console.WriteLine("Opção inválida, aperte ENTER para continuar");
          Console.ReadLine();
          Console.Clear();
          break;
      }
    }
    catch (Exception)
    {
      Console.Clear();
    }

    if (!showMenu)
    {
      return;
    }
  }
}