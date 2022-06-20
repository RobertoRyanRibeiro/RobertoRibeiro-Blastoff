// See https://aka.ms/new-console-template for more information
using Atividade2.Data;
using Atividade2.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using var context = new Atividade2DbContext();
//context.Dispose();
//Cadastrar(context);
//await ItensWithOutDiscount(context);
//await ItensWithDiscount(context);
//await UpdateNullValue(context);
//await SoldItens(context);
//await FindMaxMinValorTotalWithNF(context);
//await FindMaxMinValorVendidoWithNF(context);
//await FindMaxMinQuantWithCodProd(context);
//await FindMoreThen10NF(context);
await MaxMinAverage(context);

static async Task MaxMinAverage(Atividade2DbContext context)
{    
    var itens = await context.Itens.AsNoTracking()
        .GroupBy(x => x.CodProd )
        .Select (x => new
        {
        x.Key,
        Max = x.Max(z=> z.Desconto),
        Min = x.Min(z=> z.Desconto),
        Avg = x.Average(z=> z.Desconto),
        })
        .OrderBy(x => x.Key)
        .ToListAsync();

    foreach (var item in itens)
        Console.WriteLine($"COD_PROD - {item.Key} | Max - {item.Max} | Min {item.Min} | Avg {item.Avg}");

}

static async Task FindMoreThen10NF(Atividade2DbContext context)
{
    var itens = await context.Itens.AsNoTracking()
        .GroupBy(x => new { Key = x.IdNF, Key2 = x.CodProd, Itens = x.Quantidade })
        .OrderBy(x => x.Key.Key)
        .ThenBy(x => x.Key.Key2)
        .ThenBy(x => x.Key.Itens)
        .Select(x => new { x.Key.Key, x.Key.Key2, x.Key.Itens })
        .Where(x => x.Itens > 10)
        .ToListAsync();
    foreach (var item in itens)
        Console.WriteLine($"ID_NF - {item.Key} | COD_PROD - {item.Key2} | Quantidade {item.Itens}");

}

static async Task FindMaxMinQuantWithCodProd(Atividade2DbContext context)
{
    var itens = await context.Itens.AsNoTracking()
        .GroupBy(x => new { Key = x.CodProd, itens = x.Quantidade })
        .OrderByDescending(x => x.Key.Key)
        .ThenByDescending(x => x.Key.itens)
        .Select(x => new { x.Key.Key, x.Key.itens })
        .ToListAsync();
    foreach (var item in itens)
        Console.WriteLine($"COD_PROD - {item.Key} | Quantidade {item.itens}");

}

static async Task FindMaxMinValorVendidoWithNF(Atividade2DbContext context)
{
    var itens = await context.Itens.AsNoTracking()
        .GroupBy(x => new { Key = x.IdNF, ValorVendido = (x.ValorUnit - x.ValorUnit * x.Desconto / 100) })
        .OrderByDescending(x => x.Key.Key)
        .ThenByDescending(x => x.Key.ValorVendido)
        .Select(x => new { x.Key.Key, x.Key.ValorVendido })
        .ToListAsync();
    foreach (var item in itens)
    {
        Console.WriteLine($"NF -{item.Key} | Valor Vendido {item.ValorVendido}");
    }
}

static async Task FindMaxMinValorTotalWithNF(Atividade2DbContext context)
{
    var itens = await context.Itens.AsNoTracking()
        .GroupBy(x => new { Key = x.IdNF, ValorTotal = (x.Quantidade * x.ValorUnit) })
        .OrderByDescending(x => x.Key.Key)
        .ThenByDescending(x => x.Key.ValorTotal)
        .Select(x => new { x.Key.Key, x.Key.ValorTotal })
        .ToListAsync();
    foreach (var item in itens)
    {
        Console.WriteLine($"NF -{item.Key} | ValorTotal {item.ValorTotal}");
    }
}

static async Task SoldItens(Atividade2DbContext context)
{
    var itens = await context.Itens.AsNoTracking()
        .Select(x => new { x.IdNF, x.IdItem, x.CodProd, x.ValorUnit, x.Desconto, valorVenda = (x.ValorUnit - x.ValorUnit * x.Desconto / 100), valorTotal = (x.Quantidade * x.ValorUnit) })
        .ToListAsync();

    foreach (var item in itens)
        Console.WriteLine(
$"|ID_NF - {item.IdNF}| ID_ITEM - {item.IdItem} | COD_PROD - {item.CodProd} | VALOR_UNIT - {item.ValorUnit} | DESCONTO - {item.Desconto} | VALOR_VENDA - {item.valorVenda} | VALOR_TOTAL {item.valorTotal}");
}

static async Task UpdateNullValue(Atividade2DbContext context)
{
    var items = await context.Itens.AsNoTracking().Where(x => x.Desconto == null).ToListAsync();
    var itemsUpd = new List<Item>();
    foreach (var item in items)
    {
        item.Desconto = 0;
        itemsUpd.Add(item);
    }
    context.UpdateRange(itemsUpd);
    context.SaveChanges();
}

static async Task ItensWithDiscount(Atividade2DbContext context)
{
    var itens = await context
        .Itens
        .AsNoTracking()
        .Where(x => x.Desconto != null)
        .Select(x => new { x.IdNF, x.IdItem, x.CodProd, x.ValorUnit, valorVenda = (x.ValorUnit - x.ValorUnit * x.Desconto / 100) })
        .ToListAsync();

    foreach (var item in itens)
        Console.WriteLine(
$"|ID_NF - {item.IdNF}| ID_ITEM - {item.IdItem} | COD_PROD - {item.CodProd} | VALOR_UNIT - {item.ValorUnit} | VALOR_VENDA - {item.valorVenda}");
}

static async Task ItensWithOutDiscount(Atividade2DbContext context)
{
    var itens = await context.Itens.AsNoTracking().Where(x => x.Desconto == null).Select(x => new { x.IdNF, x.IdItem, x.CodProd, x.ValorUnit }).ToListAsync();
    foreach (var item in itens)
        Console.WriteLine($"ID_NF - {item.IdNF} | ID_ITEM - {item.IdItem} | COD_PROD - {item.CodProd} | VALOR_UNIT - {item.ValorUnit}");

}

static void Cadastrar(Atividade2DbContext context)
{
    do
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Insira os Dados");

            Console.WriteLine("|Digite o ID_NF");
            var idNF = Console.ReadLine();
            Console.WriteLine("|Digite o ID_ITEM");
            var idItem = Console.ReadLine();
            Console.WriteLine("|Digite o COD_PROD");
            var codProd = Console.ReadLine();
            Console.WriteLine("|Digite o VALOR_UNIT");
            var valorUnit = float.Parse(Console.ReadLine());
            Console.WriteLine("|Digite a QUANTIDADE");
            var quantidade = Console.ReadLine();
            Console.WriteLine("|Digite o DESCONTO");
            string desconto = Console.ReadLine();
            var item = new Item
            {
                IdNF = int.Parse(idNF),
                IdItem = int.Parse(idItem),
                CodProd = int.Parse(codProd),
                ValorUnit = valorUnit,
                Quantidade = int.Parse(quantidade),
            };

            if (String.IsNullOrEmpty(desconto))
                item.Desconto = null;
            else
                item.Desconto = int.Parse(desconto);

            context.Itens.Add(item);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Aperter Esc para sair");

    } while (Console.ReadKey().Key != ConsoleKey.Escape);
    context.SaveChanges();
}
