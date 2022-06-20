// See https://aka.ms/new-console-template for more information
using Atividade3.Data;
using Atividade3.Model;
using Microsoft.EntityFrameworkCore;


using Atividade3DbContext context = new Atividade3DbContext();

//Cadastrar(context);
//UpdateName(context);
//await FindCompatiable(context);
//await FindPcSoftEmp(context);
await DeletePcEmp(context);

static async Task DeletePcEmp(Atividade3DbContext context)
{
    var comp = await context.Computadors.FirstOrDefaultAsync(x => x.Id == 3);
    context.Computadors.Remove(comp);
    var emp = await context.Empresas.FirstOrDefaultAsync(x => x.Cnpj == "987654321");
    context.Empresas.Remove(emp);
    context.SaveChanges();
}

static async Task FindPcSoftEmp(Atividade3DbContext context)
{
    var items = await context.Funcionas
        .AsNoTracking()
        .Include(x => x.Computador).ThenInclude(x => x.Empresa)
        .Include(x => x.Software).ThenInclude(x => x.Empresa)
       .Select(x => new
       {
           Pc = x.Computador.Nome
       ,
           Soft = x.Software.Nome
       ,
           EmpPc = x.Computador.Empresa.Nome
       ,
           EmpSoft = x.Software.Empresa.Nome
       }).ToListAsync();
    foreach (var item in items)
    {
        Console.WriteLine($"|Pc - {item.Pc} = Empresa - {item.EmpPc} X Soft - {item.Soft} = Empresa - {item.EmpSoft}");
    }
}

static async Task FindCompatiable(Atividade3DbContext context)
{
    var items = await context.Compativels.AsNoTracking().Include(x => x.Computador).Include(x => x.Computador2)
       .Select(x => new { Pc = x.Computador, Pc2 = x.Computador2 }).ToListAsync();
    foreach (var item in items)
    {
        Console.WriteLine($"1º Pc Nome - {item.Pc.Nome} | 2º Pc Nome - {item.Pc2.Nome}");
    }
}

static async Task UpdateName(Atividade3DbContext context)
{
    var empresa = await context.Empresas.AsNoTracking().FirstOrDefaultAsync(x => x.Cnpj == "123456789");
    empresa.Nome = "Apple Computer Inc";
    context.Empresas.Update(empresa);
    context.SaveChanges();
}

static void Cadastrar(Atividade3DbContext context)
{
    var empresas = new Empresa[]
    {
        new Empresa { Cnpj = "123456789",Nome = "Apple Computer", Localizacao = "Cupertino" },
        new Empresa { Cnpj = "987654321",Nome = "Microdigital", Localizacao = "São Paulo" },
        new Empresa { Cnpj = "543216789",Nome = "Gradiente", Localizacao = "São Paulo" },
        new Empresa { Cnpj = "345672345",Nome = "Sharp-EPCOM", Localizacao = "São Paulo" },
        new Empresa { Cnpj = "123456721",Nome = "Intech", Localizacao = null },
        new Empresa { Cnpj = "654325674",Nome = "XSW Software", Localizacao = null },
        new Empresa { Cnpj = "424545657",Nome = "MicroPro International", Localizacao = null },
        new Empresa { Cnpj = "345676543",Nome = "Microsoft Corporation", Localizacao = "Redmond" },
    };

    context.Empresas.AddRange(empresas);
    context.SaveChanges();

    var softwares = new Software[]
   {
        new Software { Id = 1, Nome = "MS-DOS 6.22", AnoFab = 1994 , Armazenamento = "disquete" , Id_Empresa = "345676543" },
        new Software { Id = 2, Nome = "AppleWorks 2.0", AnoFab = 1983 , Armazenamento = "disquete" , Id_Empresa = "123456789" },
        new Software { Id = 3, Nome = "WordStar ", AnoFab = 1989 , Armazenamento = "disquete" , Id_Empresa = "424545657" },
        new Software { Id = 4, Nome = "O Tesouro Perdido", AnoFab = 1986 , Armazenamento = "disquete" , Id_Empresa = "345672345" },
        new Software { Id = 5, Nome = "MSX Write", AnoFab = null , Armazenamento = "disquete" , Id_Empresa = "654325674" }
   };

    context.Softwares.AddRange(softwares);

    var computadores = new Computador[]
    {
          new Computador { Id = 1 , Nome = "Apple IIe", AnoFab = 1982, Linha = "Apple" , Modelo_Cpu = "6502" , Qtd_Cpu = 1,Qtd_Ram= "64k",Id_Empresa="123456789"},
          new Computador { Id = 2 , Nome = "Apple IIc", AnoFab = 1984, Linha = "Apple" , Modelo_Cpu = "65C02" , Qtd_Cpu = 1,Qtd_Ram= "128k",Id_Empresa="123456789"},
          new Computador { Id = 3 , Nome = "TK-85’", AnoFab = 1983, Linha = "Sinclair" , Modelo_Cpu = "Z80" , Qtd_Cpu = 1,Qtd_Ram= "16k",Id_Empresa="987654321"},
          new Computador { Id = 4 , Nome = "MSX Expert", AnoFab = 1985, Linha = "MSX" , Modelo_Cpu = "Z80" , Qtd_Cpu = 3,Qtd_Ram= "80k",Id_Empresa="543216789"},
          new Computador { Id = 5 , Nome = "MSX HotBit HB-8000", AnoFab = 1985, Linha = "MSX" , Modelo_Cpu = "Z80" , Qtd_Cpu = 3,Qtd_Ram= "64k",Id_Empresa="345672345"},
          new Computador { Id = 6 , Nome = "Intech XT", AnoFab = 1987, Linha = "IBM-XT" , Modelo_Cpu = "80286" , Qtd_Cpu = 1,Qtd_Ram= "250k",Id_Empresa="123456721"},
    };

    context.Computadors.AddRange(computadores);
    context.SaveChanges();

    var compativeis = new Compativel[]
    {
         new Compativel { Id_Computador = 1, Id_Computador2 = 2},
         new Compativel { Id_Computador = 4, Id_Computador2 = 5}
    };

    context.Compativels.AddRange(compativeis);

    var funciona = new Funciona[]
    {
         new Funciona { Id_Computador = 1, Id_Software = 2},
         new Funciona { Id_Computador = 2, Id_Software = 2},
         new Funciona { Id_Computador = 4, Id_Software = 4},
         new Funciona { Id_Computador = 4, Id_Software = 5},
         new Funciona { Id_Computador = 5, Id_Software = 4},
         new Funciona { Id_Computador = 5, Id_Software = 5},
         new Funciona { Id_Computador = 6, Id_Software = 1},
         new Funciona { Id_Computador = 6, Id_Software = 3}
    };

    context.Funcionas.AddRange(funciona);
    context.SaveChanges();
}