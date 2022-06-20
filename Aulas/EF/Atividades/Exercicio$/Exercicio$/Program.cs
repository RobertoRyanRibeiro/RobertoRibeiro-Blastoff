// See https://aka.ms/new-console-template for more information

using Atividade4.Model;
using Atividade4.Data;
using Microsoft.EntityFrameworkCore;

using var context = new Atividade4DbContext();


//await InsertTables(context);
//await UpdateDatabase(context);
//await InsertCompra(context);
await List(context);

static async Task List(Atividade4DbContext context)
{
    var items = await context.Compras.AsNoTracking().Include(x => x.Cliente).Include(x => x.Produto)
        .Select(x => new { NomeCli = x.Cliente.Nome, NomeProd = x.Produto.Nome, DataCompra = x.Data, Quantidade = x.Quant })
        .ToListAsync();
    foreach(var item in items)
    {
        Console.WriteLine($"|Nome Cliente - {item.NomeCli} |Nome Prod - {item.NomeProd} |DataCompra - {item.DataCompra} |Quantidade - {item.Quantidade}");
    }
}

static async Task InsertCompra(Atividade4DbContext context)
{
    var compras = new Compra[]
    {
        new Compra { Cliente_Cpf = "492.441.760-25",Produto_Id = 0301,Data = DateTime.Parse("2018-08-20"), Quant = 1 },
        new Compra { Cliente_Cpf = "556.851.862-88",Produto_Id = 0503,Data = DateTime.Parse("2020-11-12"), Quant = 2 },
        new Compra { Cliente_Cpf = "456.841.862-03",Produto_Id = 0802,Data = DateTime.Parse("2020-10-30"), Quant = 1 },
    };

    context.Compras.AddRange(compras);
    context.SaveChanges();
}

static async Task UpdateDatabase(Atividade4DbContext context)
{
    var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Cpf == "556.851.862-88");
    cliente.Cep = "35460-153";
    context.Clientes.Update(cliente);

    cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Cpf == "492.441.760-25");
    cliente.Telefone = "(35)98834-4676";
    context.Clientes.Update(cliente);

    var produto = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 0400);
    produto.Nome = "Banquinhos Infantis";
    produto.Preco = 15.90f;
    produto.Quant = 12;
    context.Produtos.Update(produto);
    context.SaveChanges();
}

static async Task InsertTables(Atividade4DbContext context)
{
    var clientes = new Cliente[]
    {
        new Cliente { Cpf = "492.441.760-25",Nome = "Luciano",Telefone = "(35)99875-5572" },
        new Cliente { Cpf = "456.841.862-03",Nome = "Flavio",Telefone = "(35)3473-8562" },
        new Cliente { Cpf = "192.041.526-14",Nome = "Paola",Telefone = "(35)3471-1519" },
        new Cliente { Cpf = "556.851.862-88",Nome = "Aline",Telefone = "(11)99822-9639" },
    };

    context.Clientes.AddRange(clientes);
    context.SaveChanges();

    var produtos = new Produto[]
    {
        new Produto { Id = 0300, Nome = "Baleia Azul", Tipo = "Carvalho", Preco = 29.90f, Quant = 3},
        new Produto { Id = 0301, Nome = "Moinho de Vento", Tipo = "Ipê", Preco = 24.90f, Quant = 2},
        new Produto { Id = 0400, Nome = "Conjunto de Banquinhos", Tipo = "Carvalho", Preco = 42f, Quant = 4},
        new Produto { Id = 0500, Nome = "Porta-chaves", Tipo = "Goiabão", Preco = 8.90f, Quant = 7},
        new Produto { Id = 0501, Nome = "Mini Avião", Tipo = "Mogno", Preco = 27.90f, Quant = 4},
        new Produto { Id = 0502, Nome = "Tronco Esculpido", Tipo = "Goiabão", Preco = 69.90f, Quant = 2},
        new Produto { Id = 0503, Nome = "Vaso de Flores", Tipo = "Aroeira", Preco = 9.90f, Quant = 4},
        new Produto { Id = 0504, Nome = "Urso Pardo", Tipo = "Aroeira", Preco =  28.90f, Quant = 2},
        new Produto { Id = 0505, Nome = "Peixe Dourado", Tipo = "Ipê", Preco = 37.90f, Quant = 2},
        new Produto { Id = 0800, Nome = "Galinha Pintada'", Tipo = "Carvalho", Preco = 11.90f, Quant = 4},
        new Produto { Id = 0801, Nome = "Flauta", Tipo = "Mogno", Preco = 18.90f, Quant = 2},
        new Produto { Id = 0802, Nome = "Guitarra", Tipo = "Alder", Preco = 1000f, Quant = 5},
        new Produto { Id = 0900, Nome = "Tábua de Corte", Tipo = "Carvalho", Preco = 8.90f, Quant = 4}
    };

    context.Produtos.AddRange(produtos);
    context.SaveChanges();
}