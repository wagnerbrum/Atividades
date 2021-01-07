namespace jogoDaVelha
{
    public class Elevador
    {
        public static int ANDAR_TERREO = 0;

        public int AndarAtual { get; private set; }
        public int TotalDeAndares { get; private set; }
        public int CapacidadeTotalDePessoas { get; private set; }
        public int NumeroAtualDePessoas { get; private set; }

        // A principio, o mais correto seria esse "Inicializa" ser o contrutor da classe ...
        public void Inicializa(int capacidadeTotalDePessoas, int totalDeAndares)
        {
            this.AndarAtual = ANDAR_TERREO;
            this.TotalDeAndares = 0;
            this.CapacidadeTotalDePessoas = capacidadeTotalDePessoas;
            this.TotalDeAndares = totalDeAndares;
        }

        public bool Entra()
        {
            if (this.NumeroAtualDePessoas < this.CapacidadeTotalDePessoas)
            {
                this.CapacidadeTotalDePessoas++;
                return true;
            }

            return false;
        }

        public bool Sai()
        {
            if (this.NumeroAtualDePessoas > 0)
            {
                this.NumeroAtualDePessoas--;
                return true;
            }

            return false;
        }

        public bool Sobe()
        {
            if (this.AndarAtual < this.TotalDeAndares)
            {
                this.AndarAtual++;
                return true;
            }

            return false;
        }

        public bool Desce()
        {
            if (this.AndarAtual > 0)
            {
                this.AndarAtual--;
                return true;
            }

            return false;
        }
    }
}