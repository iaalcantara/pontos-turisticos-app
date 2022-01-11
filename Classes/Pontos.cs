namespace pontos_turisticos_app
{
    public class Pontos : EntidadeBase
    {
        //Atributos
        private City City { get; set; }
        private string Name { get; set; }

        private string Address { get; set; }

        private string Operation { get; set; }

        private string Price { get; set; }

        private string Description { get; set; }

        private bool Deleted { get; set; }

        //Métodos

        public Pontos(int id, City city, string name, string address, string operation, string price, string description)
        {
            this.Id = id;
            this.City = city;
            this.Name = name;
            this.Address = address;
            this.Operation = operation;
            this.Price = price;
            this.Description = description;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "City: " + this.City + Environment.NewLine;
            retorno += "Name: " + this.Name + Environment.NewLine;
            retorno += "Address: " + this.Address + Environment.NewLine;
            retorno += "Operation: " + this.Operation + Environment.NewLine;
            retorno += "Price: " + this.Price + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Deleted: " + this.Deleted + Environment.NewLine;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Name;
        }
        public int retornaId()
        {
            return this.Id;
        } 

        public bool retornaDeleted()
        {
            return this.Deleted;
        }
        public void Delete(){
            this.Deleted = true;
        }
    }
}