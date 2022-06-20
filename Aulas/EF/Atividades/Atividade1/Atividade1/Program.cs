// See https://aka.ms/new-console-template for more information
using Atividade1.Data;
using Atividade1.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using var context = new AtividadeDbContext();

//Cadastrar(context);
//List(context);
Delete(context);
List(context);

static void Delete(AtividadeDbContext context)
{
    var planetas = context.Planetas.Where(x => x.Habitavel != true || x.Distancia > 30);
    context.Planetas.RemoveRange(planetas);
    context.SaveChanges();
}

static void List(AtividadeDbContext context)
{
    var planetas = context
        .Planetas
        .AsNoTracking()
        .Include(x=>x.Estrela)
        .Include(x => x.Estrela.Galaxia)
        .ToList();

    foreach(var planeta in planetas)
    {
        Console.WriteLine($"Planeta - {planeta.Nome} | Estrela - {planeta.Estrela.Nome} | Planeta {planeta.Estrela.Galaxia.Nome}");
    }
}

static void Cadastrar(AtividadeDbContext context)
{

    var gal1 = new Galaxia()
    {
        Nome = "Via Lactea",
        Massa = 1.9m,
        Tamanho = "105700",
        Tipo = "Espiral"
    };

    var gal2 = new Galaxia()
    {
        Nome = "Andrômeda",
        Massa = 1.23m,
        Tamanho = "220000",
        Tipo = "Espiral"
    };

    var gal3 = new Galaxia()
    {
        Nome = "Pequena Nuvem de Magalhães",
        Massa = 6.5m,
        Tamanho = "7000",
        Tipo = "Irregular"
    };

    context.Galaxias.Add(gal1);
    context.Galaxias.Add(gal2);
    context.Galaxias.Add(gal3);
    context.SaveChanges();


    var est1 = new Estrela()
    {
        Nome = "Sol",
        Massa = 1989m,
        Tamanho = 1392,
        Luminosidade = 1,
        GalaxiaId = 1
    };

    var est2 = new Estrela()
    {
        Nome = "Kepler-438",
        Massa = 1082m,
        Tamanho = 723.84m,
        Luminosidade = 0.0044f,
        GalaxiaId = 1
    };

    var est3 = new Estrela()
    {
        Nome = "Gliese 667",
        Massa = 1372m,
        Tamanho = 974.4m,
        Luminosidade = 0.0137f,
        GalaxiaId = 1
    };

    context.Estrelas.Add(est1);
    context.Estrelas.Add(est2);
    context.Estrelas.Add(est3);
    context.SaveChanges();


    var pla = new Planeta()
    {
        Nome = "Terra",
        Massa = 59722m,
        Tamanho = 12742m,
        Habitavel = true,
        Distancia = 0,
        EstrelaId = 1
    };

    var pla2 = new Planeta()
    {
        Nome = "Kepler-438b",
        Massa = null,
        Tamanho = 14271,
        Habitavel = true,
        Distancia = 470,
        EstrelaId = 2
    };

    var pla3 = new Planeta()
    {
        Nome = "Gliese 667 Cc",
        Massa = 2621,
        Tamanho = 19113,
        Habitavel = true,
        Distancia = 22,
        EstrelaId = 3
    };

    var pla4 = new Planeta()
    {
        Nome = "Marte",
        Massa = 64174,
        Tamanho = 6779,
        Habitavel = false,
        Distancia = 3805,
        EstrelaId = 1
    };

    context.Planetas.Add(pla);
    context.Planetas.Add(pla2);
    context.Planetas.Add(pla3);
    context.Planetas.Add(pla4);

    context.SaveChanges();
    Console.WriteLine("Cadastrado Com Sucesso");
}