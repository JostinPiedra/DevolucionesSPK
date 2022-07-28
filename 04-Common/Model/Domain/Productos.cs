namespace Model.Domain
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int? Cantidad { get; set; }
    }
}
