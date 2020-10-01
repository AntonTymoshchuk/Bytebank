using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bytebank
{
    public class BytebankDataBase : DbContext
    {
        public BytebankDataBase() : base("Data Source=LAPTOP-OCJDU2KO;Initial Catalog=Bytebank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        { }

        public DbSet<Administrator> Administration { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Conv_AtoU> Convs_AtoU { get; set; }
        public DbSet<Conv_UtoA> Convs_UtoA { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Lang> Languages { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class Lang
    {
        public int ID { get; set; }
        public string Language { get; set; }
    }

    public class Card
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CardNumber { get; set; }
        public int Value { get; set; }
    }

    public class Conv_AtoU
    {
        public int ID { get; set; }
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public string TextA { get; set; }
        public string TextU { get; set; }
    }

    public class Conv_UtoA
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int AdminID { get; set; }
        public string TextU { get; set; }
        public string TextA { get; set; }
    }

    public class Credit
    {
        public int ID { get; set; }
        public int CardID { get; set; }
        public int Value { get; set; }
        public float Percentage { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateB { get; set; }
    }

    public class Deposit
    {
        public int ID { get; set; }
        public int CardID { get; set; }
        public int Value { get; set; }
        public float Percentage { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateB { get; set; }
    }

    public class Administrator
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sirname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string SecureID { get; set; }
        public byte[] Image { get; set; }
        public int Language { get; set; }
        public bool Active { get; set; }
        public DateTime LastConnected { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sirname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int Language { get; set; }
        public bool Active { get; set; }
        public DateTime LastConnected { get; set; }
    }
}
