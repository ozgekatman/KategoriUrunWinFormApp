using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KategoriUrunWinFormApp.Models
{
    public class Kategori
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string KategoriAdi { get; set; }
        public virtual List<Urun> Urunler { get; set; }
        public Kategori()
        {
            Urunler = new List<Urun>();
        }
    }
}
