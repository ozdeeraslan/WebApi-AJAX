namespace WebApiGorevler.Data
{
    public class Otobus
    {
        public int Id { get; set; }

        public int YolcuKapasitesi { get; set; }

        public string Marka { get; set; } = null!;

        public DateTime KayitTarihi { get; set; }

        public DateTime GuncellenmeTarihi { get; set; }


    }
}
