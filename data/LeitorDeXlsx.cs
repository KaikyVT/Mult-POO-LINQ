using Multiplicacao.controller;
using Multiplicacao.models;
using NPOI.SS.UserModel;

namespace Multiplicacao.data;

class LeitorDeXlsx
{
    private static readonly string _path = Path.Combine(Environment.CurrentDirectory, "Pedidos.xlsx");
    public static void LerDadosExcel()
    {
        //! Abrindo stream de leitura do arquivo
        using var stream = new FileStream(_path, FileMode.Open, FileAccess.Read);

        //! Crio meu objeto de WorkBook a partir da stream lida da memória
        IWorkbook workbook = WorkbookFactory.Create(stream);

        //! Pego a primeira planilha da pasta
        ISheet sheet = workbook.GetSheetAt(0);

        //! Iterar por todas as linhas criando os pedidos
        for (int i = 1; i <= sheet.LastRowNum; i++)
        {
            //! Pego a linha no índice
            IRow row = sheet.GetRow(i);

            //! Separo os conteúdos
            string codigoPedido = row.GetCell(0).StringCellValue;
            DateTime dataPedido = row.GetCell(1).DateCellValue ?? DateTime.Now;
            string nomeCliente = row.GetCell(2).StringCellValue;
            string produto = row.GetCell(3).StringCellValue;
            int quantidade = (int)row.GetCell(4).NumericCellValue;
            decimal valorTotal = (decimal)row.GetCell(5).NumericCellValue;
            string nomeVendedor = row.GetCell(6).StringCellValue;
            string cidade = row.GetCell(7).StringCellValue;
            string estado = row.GetCell(8).StringCellValue;
            string codigoProduto = row.GetCell(9).StringCellValue;
            string categoriaProduto = row.GetCell(10).StringCellValue;

            //! Instancio um objeto com as variáveis criadas
            Pedido p = new(codigoPedido, dataPedido, nomeCliente, produto, quantidade, valorTotal, nomeVendedor, cidade, estado, codigoProduto, categoriaProduto);
            PedidoControle.AdicionaNaLista(p);
        }
    }
}