namespace Multiplicacao.models;

public class Pedido
{
    public Pedido(string codigoPedido, DateTime dataPedido, string nomeCliente, string produto, int quantidade, decimal valorTotal, string nomeVendedor, string cidade, string estado, string codigoProduto, string categoriaProduto)
    {
        SetCodigoPedido(codigoPedido);
        SetDataPedido(dataPedido);
        SetNomeCliente(nomeCliente);
        SetProduto(produto);
        SetQuantidade(quantidade);
        SetValorTotal(valorTotal);
        SetNomeVendedor(nomeVendedor);
        SetCidade(cidade);
        SetEstado(estado);
        SetCodigoProduto(codigoProduto);
        SetCategoriaProduto(categoriaProduto);
    }

    public string CodigoPedido { get; protected set; }
    public DateTime DataPedido { get; protected set; }
    public string NomeCliente { get; protected set; }
    public string Produto { get; protected set; }
    public int Quantidade { get; protected set; }
    public decimal ValorTotal { get; protected set; }
    public string NomeVendedor { get; protected set; }
    public string Cidade { get; protected set; }
    public string Estado { get; protected set; }
    public string CodigoProduto { get; protected set; }
    public string CategoriaProduto { get; protected set; }


    public void SetCodigoPedido(string codigoPedido)
    {
        if (string.IsNullOrWhiteSpace(codigoPedido))
            throw new ArgumentNullException("Código do Pedido");
        CodigoPedido = codigoPedido;
    }
    public void SetDataPedido(DateTime dataPedido)
    {
        if (dataPedido > DateTime.Now)
            throw new ArgumentException("A data deve ser menor que a data atual");
        DataPedido = dataPedido;
    }
    public void SetNomeCliente(string nomeCliente)
    {
        if (string.IsNullOrWhiteSpace(nomeCliente))
            throw new ArgumentNullException("Nome do cliente");
        NomeCliente = nomeCliente;
    }
    public void SetProduto(string produto)
    {
        if (string.IsNullOrWhiteSpace(produto))
            throw new ArgumentNullException("Produto");
        Produto = produto;
    }
    public void SetQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException("A quantidade deve ser, no mínimo, zero");
        Quantidade = quantidade;
    }
    public void SetValorTotal(decimal valorTotal)
    {
        if (valorTotal < 0)
            throw new ArgumentOutOfRangeException("O valor total não pode ser menor que 0");
        ValorTotal = valorTotal;
    }
    public void SetNomeVendedor(string nomeVendedor)
    {
        if (string.IsNullOrWhiteSpace(nomeVendedor))
            throw new ArgumentNullException("Nome do vendedor");
        NomeVendedor = nomeVendedor;
    }
    public void SetCidade(string cidade)
    {
        if (string.IsNullOrWhiteSpace(cidade))
            throw new ArgumentNullException("Cidade");
        Cidade = cidade;
    }
    public void SetEstado(string estado)
    {
        if (string.IsNullOrWhiteSpace(estado))
            throw new ArgumentNullException("Estado");
        Estado = estado;
    }
    public void SetCodigoProduto(string codigoProduto)
    {
        if (string.IsNullOrWhiteSpace(codigoProduto))
            throw new ArgumentNullException("Codigo do produto");
        CodigoProduto = codigoProduto;
    }
    public void SetCategoriaProduto(string categoriaProduto)
    {
        if (string.IsNullOrWhiteSpace(categoriaProduto))
            throw new ArgumentNullException("Categoria do produto");
        if (categoriaProduto.Length > 100)
            throw new ArgumentException("A categoria deve ter no máximo 100 caracteres");
        CategoriaProduto = categoriaProduto;
    }

}