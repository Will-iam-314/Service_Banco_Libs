namespace BK.Usuario.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteUsuario
        {
            // Read
            public const string GetAll = Base + "/usuario/all";
            public const string GetById = Base + "/usuario/{id}";

            // Write
            public const string Create = Base + "/usuario/create";
            public const string Update = Base + "/usuario/update";
            public const string Delete = Base + "/usuario/delete";

        }

        public static class RouteRol
        {
            // Read
            public const string GetAll = Base + "/Rol/all";
            public const string GetById = Base + "/Rol/{id}";

            // Write
            public const string Create = Base + "/Rol/create";
            public const string Update = Base + "/Rol/update";
            public const string Delete = Base + "/Rol/delete";
        }
    }
}
