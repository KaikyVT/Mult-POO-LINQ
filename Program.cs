using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using Multiplicacao.controller;
using Multiplicacao.data;
using Multiplicacao.models;
using Multiplicacao.view;
using NPOI.SS.UserModel;
using NPOI.XWPF.UserModel;

namespace Multiplicacao;

public class Program
{
    public static void Main(string[] args)
    {
        LeitorDeXlsx.LerDadosExcel();
        Menu.Iniciar();
    }
}