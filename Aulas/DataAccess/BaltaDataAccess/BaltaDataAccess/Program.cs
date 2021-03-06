// See https://aka.ms/new-console-template for more information

using System;
using System.Data;
using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{

    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server =localhost,1433;Database=balta,User ID=sa;Password=1q2w3e4r@#$";

            using (var connection = new SqlConnection(connectionString))
            {
                //UpdateCategory(connection);
                //ListCategories(connection);
                //CreateManyCategory(connection);
                //CreateCategory(connection);
                //DeleteCategory(connection);
                //GetCategory(connection);
                //ExecuteProcedure(connection);
                //ExecuteReadProcedure(connection);
                //ExecuteScalar(connection);
                //ReadView(connection);
                //OneToOne(connection);
                //OneToMany(connection);
                //QueryMutiple(connection);
                //SelectIn(connection);
                //Like(connection);
                //Like(connection,"api");
                Transaction(connection);
            }
        }

        static void GetCategory(SqlConnection connection)
        {
            var category = connection
                .QueryFirstOrDefault<Category>(
                    "SELECT TOP 1 [Id], [Title] FROM [Category] WHERE [Id]=@id",
                    new
                    {
                        id = "af3407aa-11ae-4621-a2ef-2028b85507c4"
                    });
            Console.WriteLine($"{category.Id} - {category.Title}");

        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id],[Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "Amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;


            //SQL INJECTION CUIDADO
            var insert = @"INSERT INTO [Category~] 
            VALUES(
            @Id,
            @Title,
            @Url,
            @Summary,
            @Order,
            @Description,
            @Featured
            )";

            connection.Execute(insert, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            connection.Execute(updateQuery, new { id = new Guid("Algum Guid"), title = "Frontend 2021" });
        }

        static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = "DELETE [Category] WHERE [Id]=@id";
            var rows = connection.Execute(deleteQuery, new
            {
                id = new Guid("ea8059a2-e679-4e74-99b5-e4f0b310fe6f"),
            });

            Console.WriteLine($"{rows} registros excluídos");
        }

        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "Amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Categoria Nova";
            category2.Url = "categoria-nova";
            category2.Description = "Categoria nova";
            category2.Order = 9;
            category2.Summary = "Categoria";
            category2.Featured = true;

            //SQL INJECTION CUIDADO
            var insert = @"INSERT INTO [Category~] 
            VALUES(
            @Id,
            @Title,
            @Url,
            @Summary,
            @Order,
            @Description,
            @Featured
            )";

            connection.Execute(insert, new[]
            {
                new{
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            },
            new{
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            }
            });
        }

        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "[spDeleteStudent]";

            var parametro = new { StudentId = "Algum cod" };
            connection.Execute(procedure, parametro, commandType: CommandType.StoredProcedure);
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "Algum Cod" };
            var courses = connection.Query<Category>(procedure, pars, commandType: CommandType.StoredProcedure);

            foreach (var item in courses)
            {
                Console.WriteLine(item.Id);
            }
        }

        static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Category();
            category.Title = "Amazon AWS";
            category.Url = "Amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;


            //SQL INJECTION CUIDADO
            var insert = @"INSERT INTO [Category~] 
            OUTPUT insertd.[Id]
            VALUES(
            NEWGUID()
            @Title,
            @Url,
            @Summary,
            @Order,
            @Description,
            @Featured
            ) ";

            //SELECT SCOPE_IDENTITY()

            var id = connection.ExecuteScalar<Guid>(insert, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine(id);
        }

        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            var courses = connection.Query<Course>(sql);

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }

        }

        static void OneToOne(SqlConnection connection)
        {
            var sql =
                @"SELECT 
                    *
                FROM
                    [CareerItem] 
                INNER JOIN 
                    [Course] 
                ON
                [CareerItem].[CourseId] = [Course].[Id]";

            var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) =>
               {
                   careerItem.Course = course;
                   return careerItem;
               }, splitOn: "[Id]");

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
            }
        }

        static void OneToMany(SqlConnection connection)
        {
            var sql =
                @"   SELECT
                      [Career].[Id],
                      [Career].[Title],
                      [CareerItem].[CareerId],
                      [CareerItem].[Title]
                     FROM
                      [Career]
                     INNER JOIN
                      [CareerItem] ON[CareerItem].[CareerId] = [Career].[Id]
                    ORDER BY
                      [Career].[Title]";

            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(sql, (career, item) =>
            {
                var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                if (car == null)
                {
                    car = career;
                    car.Items.Add(item);
                    careers.Add(car);
                }
                else
                {
                    car.Items.Add(item);
                }
                return career;
            }, splitOn: "[CareerId]");

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }

        static void QueryMutiple(SqlConnection connection)
        {
            var query = "SELECT * FROM [Category]; SELECT * FROM [Course]";
            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var items in categories)
                {
                    Console.WriteLine(items.Title);
                }

                foreach (var items in courses)
                {
                    Console.WriteLine(items.Title);
                }
            }
        }

        static void SelectIn(SqlConnection connection)
        {
            var query = @"SELECT * FROM Career WHERE [Id] IN(@Id)";

            var items = connection.Query<Career>(query, new { Id = new[] { "Algum cod", "algum cod" } });
            
            foreach(var item in items)
            {
                Console.WriteLine("Texto");
            }
        }

        static void Like(SqlConnection connection,string term)
        {
            //var term = "api";
            var query = @"SELECT * FROM [Course] WHERE [Title] LIKE @exp)";

            var items = connection.Query<Course>(query, new { exp = $"%{term}%" });

            foreach (var item in items)
            {
                Console.WriteLine("Texto");
            }
        }

        static void Transaction(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Minha Categoria Não q";
            category.Url = "Amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            //SQL INJECTION CUIDADO
            var insert = @"INSERT INTO [Category] 
            VALUES(
            @Id,
            @Title,
            @Url,
            @Summary,
            @Order,
            @Description,
            @Featured
            )";

            connection.Open();
            using(var transaction = connection.BeginTransaction())
            {
                connection.Execute(insert, new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                }, transaction);

                //transaction.Commit();
                transaction.Rollback();
            }
        }
    }
}

