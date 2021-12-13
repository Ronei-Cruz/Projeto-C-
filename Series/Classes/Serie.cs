using Series.Enum;

namespace Series.Classes
{
    public class Serie : EntidadeBase
    {
        private Categoria Categoria {get; set;}
        private Genero Genero {get; set;}
        private string? Titulo {get;set;}
        private string? Descricao {get; set;}
        private int Ano {get; set;}

        private bool Excluido {get; set;}

        public Serie (int id, Categoria categoria, Genero genero, string titulo, string descricao, int ano){
            this.Id = id;
            this.Categoria = categoria;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Categoria: " + this.Categoria + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano do início: " + this.Ano + Environment.NewLine;
            retorno += "Excluida: " + this.Excluido;

            return retorno;
        }

        public string? retornaTitulo(){
            return this.Titulo;
        }
        internal int retornaId(){
            return this.Id;
        }
        public bool retornaExcluido(){
            return this.Excluido;
        }
        public void Excluir(){
            this.Excluido = true;
        }
    }
}