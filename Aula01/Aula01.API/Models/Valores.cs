namespace Aula01.API.Models
{
    public class Valores
    {
        public float N1 { get; set; }
        public float N2 { get; set; }

        public bool N1MaiorN2 { get => N1 > N2; }
    }
}