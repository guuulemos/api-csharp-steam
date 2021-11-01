namespace Steam.Infra.Data.Repositories.Queries
{
    public static class GamesQueries
    {
        public static string Inserir = @"Insert Into Games (Nome, Developer) Values (@Nome, @Developer);
                                         Select SCOPE_IDENTITY();";

        public static string Obter = @"Select 
                                            Id as Id,
                                            Nome as Nome,
                                            Developer as Developer
                                       From Games
                                       Where Id = @Id;";

        public static string Listar = @"Select
                                            Id,
                                            Nome,
                                            Developer
                                        From Games
                                        Order By Id";

        public static string Alterar = @"Update Games Set Nome = @Nome, Developer = @Developer Where Id = @Id";

        public static string CheckId = @"Select Id From Games Where Id = @Id";

        public static string Excluir = @"Delete From Games Where Id = @Id";
                                       
    }
}
