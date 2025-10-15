using System.Runtime.InteropServices;
using Multiplicacao.models;

namespace Multiplicacao.controller;

class PedidoControle
{
    private static readonly List<Pedido> _pedidos = [];

    public static void ChamaExercicio(int numeroEx)
    {
        switch (numeroEx)
        {
            case 1: Ex01(); break;
            case 2: Ex02(); break;
            case 3: Ex03(); break;
            case 4: Ex04(); break;
            case 5: Ex05(); break;
            case 6: Ex06(); break;
            case 7: Ex07(); break;
            case 8: Ex08(); break;
            case 9: Ex09(); break;
            case 10: Ex10(); break;
            case 11: Ex11(); break;
            case 12: Ex12(); break;
            case 13: Ex13(); break;
            case 14: Ex14(); break;
            case 15: Ex15(); break;
        }
    }
    public static void AdicionaNaLista(Pedido pedido)
    {
        _pedidos.Add(pedido);
    }
    private static void Ex01()
    {
        // var pedido = _pedidos.MaxBy(p => p.ValorTotal);
        decimal valorMaximo = _pedidos.Max(p => p.ValorTotal);
        Console.WriteLine($"😺 -> Valor máximo de pedido: {valorMaximo:c}");
    }
    private static void Ex02()
    {
        //var vendedoresDistintos = _pedidos.DistinctBy(n => n.NomeVendedor).Count();
        var vendedoresDistintos2 = _pedidos.Select(n => n.NomeVendedor).Distinct().Count();
        Console.WriteLine($"😺 -> Temos {vendedoresDistintos2} vendedores distintos na loja");
    }
    private static void Ex03()
    {
        var pedidosPorMes = _pedidos.GroupBy(p => new { p.DataPedido.Month, p.DataPedido.Year, NomeMes = p.DataPedido.ToString("MMM") }).Select(g => new
        {
            g.Key,
            Count = g.Count()
        }).OrderBy(a => a.Key.Year).ThenBy(b => b.Key.Month);
        Console.WriteLine("😺 -> Número de pedidos mensais!");
        foreach (var mes in pedidosPorMes)
        {
            Console.WriteLine($"|{mes.Key.NomeMes}/{mes.Key.Year}: {mes.Count:00} pedidos");
            Console.WriteLine("|__________________________________________________________");
        }
    }
    private static void Ex04()
    {
        // Primeiro
        var Top5CategoriasMaisVendidas = _pedidos.GroupBy(c => c.CategoriaProduto).Select(n => new
        {
            n.Key,
            QtdPedidos = n.Count(),
            ProdutosVendidos = n.Sum(q => q.Quantidade)
        }).OrderByDescending(q => q.QtdPedidos).Take(5).ToList();

        Console.WriteLine("😺 -> Categorias com mais pedidos:");

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"|{i + 1}. {Top5CategoriasMaisVendidas[i].Key} - {Top5CategoriasMaisVendidas[i].QtdPedidos} pedidos e {Top5CategoriasMaisVendidas[i].ProdutosVendidos} produtos individuais vendidos");
            Console.WriteLine("|_________________________________________________________________________________");
        }
        Console.WriteLine("\n=============================================================================================\n");

        // Segundo
        var Top5ProdutosMaisVendidos = _pedidos.GroupBy(p => p.Produto).Select(n => new
        {
            n.Key,
            QtdPedidos = n.Count(),
            ProdutosVendidos = n.Sum(q => q.Quantidade),
            QtdVendas = n.Count()
        }).OrderByDescending(a => a.QtdPedidos).Take(5).ToList();

        Console.WriteLine("😺 -> Produtos com mais pedidos:");

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"|{i + 1}. {Top5ProdutosMaisVendidos[i].Key} - {Top5ProdutosMaisVendidos[i].QtdVendas} pedidos com {Top5ProdutosMaisVendidos[i].ProdutosVendidos} produtos individuais vendidos");
            Console.WriteLine("|___________________________________________________________");
        }
        Console.WriteLine("\n=============================================================================================\n");

        //Terceiro
        var Top3CidadesComMaisPedidos = _pedidos.GroupBy(c => c.Cidade).Select(n => new
        {
            n.Key,
            QtdPedidos = n.Count(),
            VendasIndiv = n.Sum(q => q.Quantidade)
        }).OrderByDescending(q => q.QtdPedidos).Take(3).ToList();

        Console.WriteLine("😺 -> Cidades com mais pedidos:");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"|{i + 1}. {Top3CidadesComMaisPedidos[i].Key} - {Top3CidadesComMaisPedidos[i].QtdPedidos} pedidos com {Top3CidadesComMaisPedidos[i].VendasIndiv} vendas individuais");
            Console.WriteLine("|__________________________________________________________________________________");
        }
    }
    private static void Ex05()
    {
        var ClientesUnicos = _pedidos.Select(n => n.NomeCliente).Distinct().Count();
        var ClientesMaisGastadores = _pedidos.GroupBy(c => c.NomeCliente).Select(n => new
        {
            NomeCliente = n.Key,
            ValorTotal = n.Sum(v => v.ValorTotal),
            Qtd = n.Count()
        }).OrderByDescending(v => v.ValorTotal).Take(5);
        int i = 1;
        Console.WriteLine($"😺 -> Temos {ClientesUnicos} clientes!\nOs mais gastadores são:");
        foreach (var c in ClientesMaisGastadores)
        {
            Console.WriteLine($"|{i}. {c.NomeCliente} - {c.ValorTotal:c} - {c.Qtd}");
            i++;
            Console.WriteLine("|_____________________________________________");
        }

    }
    private static void Ex06()
    {
        var EstadosMaisPedidosPorMes = _pedidos.GroupBy(g => new
        {
            g.DataPedido.Month,
            g.DataPedido.Year,
            g.Estado,
            NomeMes = g.DataPedido.ToString("MMMM")
        }).Select(n => new
        {
            n.Key,
            Quantidade = n.Count()
        }).OrderByDescending(q => q.Quantidade).Take(5);
        int i = 1;
        Console.WriteLine("😺 -> Estados com mais pedidos por mês:");
        foreach (var e in EstadosMaisPedidosPorMes)
        {
            Console.WriteLine($"|{i}. {e.Key.NomeMes}/{e.Key.Year} - {e.Key.Estado} - {e.Quantidade}");
            Console.WriteLine("|________________________________________________________________________");
            i++;
        }


    }
    private static void Ex07()
    {
        var MediaPorCategoria = _pedidos.GroupBy(c => c.CategoriaProduto).Select(n => new
        {
            n.Key,
            MediaValor = n.Average(v => v.ValorTotal)
        }).OrderByDescending(m => m.MediaValor);
        Console.WriteLine("😺 -> Media de valor por categoria");
        foreach (var media in MediaPorCategoria)
        {
            Console.WriteLine($"|{media.Key}: R${media.MediaValor.ToString("F2")}");
            Console.WriteLine("|___________________________________________________________");
        }
    }
    private static void Ex08()
    {
        var dataAtual = _pedidos.Max(d => d.DataPedido);
        var vendedorComMaisPedido3Meses = _pedidos.Where(d => d.DataPedido <= dataAtual && d.DataPedido >= dataAtual.AddMonths(-3)).Select(n => new
        {
            n.NomeVendedor,
            ValorTotal = n.ValorTotal
        }).MaxBy(v => v.ValorTotal);
        Console.WriteLine($"😺 -> O vendedor com mais vendas é o {vendedorComMaisPedido3Meses.NomeVendedor} com {vendedorComMaisPedido3Meses.ValorTotal:c}");
    }
    private static void Ex09()
    {
        var MediaPedidos = _pedidos.GroupBy(n => n.NomeCliente).Select(n => new
        {
            Nome = n.Key,
            Media = n.Average(q => q.Quantidade)
        }).OrderByDescending(m => m.Media).ThenBy(n => n.Nome).ToList();
        Console.WriteLine("😺 -> Média de quantidade de produtos vendidos por pedido para cada cliente");
        foreach (var media in MediaPedidos)
        {
            Console.WriteLine($"|{media.Nome}: {media.Media} produtos por pedido");
            Console.WriteLine("|________________________________________________________________");
        }
    }
    private static void Ex10()
    {
        var maisVendidos = _pedidos.GroupBy(p => p.Produto).Select(n => new
        {
            Produto = n.Key,
            Quantidade = n.Sum(q => q.Quantidade),
            Valor = n.Sum(v => v.ValorTotal)
        }).OrderByDescending(q => q.Quantidade).ThenByDescending(v => v.Valor).Take(10);
        Console.WriteLine("😺 -> Top 10 produtos mais vendidos em termos de quantidade e o valor total arrecadado por esses produtos");
        foreach (var mv in maisVendidos)
        {
            Console.WriteLine($"|{mv.Produto}: {mv.Quantidade} unidades - {mv.Valor:c}");
            Console.WriteLine("|______________________________________________________________");
        }

    }
    private static void Ex11()
    {
        var anoMax = _pedidos.Max(d => d.DataPedido);
        var anoMin = anoMax.AddYears(-1);
        var pedidosTri = _pedidos.Where(d => d.DataPedido <= anoMax && d.DataPedido >= anoMin).GroupBy(t => (t.DataPedido.Month - 1) / 3 + 1).Select(n => new
        {
            Trimestre = n.Key,
            QtdPedidos = n.Count()
        }).OrderBy(t => t.Trimestre).ToList();
        int i = 1;
        Console.WriteLine("😺 -> Números de pedidos realizados no último ano divididos por trimestre:");
        foreach (var trimestre in pedidosTri)
        {
            Console.WriteLine($"|{i}ºTrimestre: {trimestre.QtdPedidos} pedidos");
            Console.WriteLine("|______________________________________________________");
            i++;
        }
    }
    private static void Ex12()
    {
        var CidadeVend = _pedidos.GroupBy(c => c.Cidade).Select(n => new
        {
            n.Key,
            TotVendas = n.Sum(v => v.ValorTotal),
            TotPedidos = n.Count()
        }).MaxBy(v => v.TotVendas);
        Console.WriteLine($"😺 -> A cidade com mais vendas é {CidadeVend.Key} com {CidadeVend.TotVendas:c} e {CidadeVend.TotPedidos} pedidos distintos");
    }
    private static void Ex13()
    {
        var mediaValor = _pedidos.Average(m => m.ValorTotal);
        var vendedoresAbaixo = _pedidos.GroupBy(v => v.NomeVendedor).Select(n => new
        {
            Nome = n.Key,
            Media = n.Average(v => v.ValorTotal)
        }).Where(v => v.Media < mediaValor).OrderBy(n => n.Media);
        Console.WriteLine($"😺 -> Vendedores abaixo da média da empresa ({mediaValor:c})");
        foreach (var vendedor in vendedoresAbaixo)
        {
            Console.WriteLine($"| {vendedor.Nome} - {vendedor.Media:c}");
            Console.WriteLine("|___________________________________________________________");
        }
    }
    private static void Ex14()
    {
        var produtoCaroCategoria = _pedidos.GroupBy(c => c.CategoriaProduto)
                                           .Select(n => new
                                           {
                                               Categoria = n.Key,
                                               Produto = n.MaxBy(v => v.ValorTotal / v.Quantidade)
                                           }).OrderByDescending(v => v.Produto.ValorTotal);
        Console.WriteLine("😺 -> O produto de maior valor unitário por categoria");
        foreach (var produto in produtoCaroCategoria)
        {
            var valor = produto.Produto.ValorTotal / produto.Produto.Quantidade;
            Console.WriteLine($"|{produto.Categoria} -> {produto.Produto.Produto}: {valor:c}");
            Console.WriteLine("|______________________________________________________");
        }
    }
    private static void Ex15()
    {
        var eletronicosValorEstado = _pedidos.Where(c => c.CategoriaProduto.Equals("Eletrônicos")).GroupBy(e => e.Estado).Select(n => new
        {
            Estado = n.Key,
            ValorTotal = n.Sum(v => v.ValorTotal)
        }).OrderByDescending(v => v.ValorTotal);
        Console.WriteLine("😺 -> Estados que mais arrecadaram com eletrônicos");
        foreach (var estado in eletronicosValorEstado)
        {
            Console.WriteLine($"| {estado.Estado} - {estado.ValorTotal:c}");
            Console.WriteLine("|_________________________________________________");
        }
    }
}