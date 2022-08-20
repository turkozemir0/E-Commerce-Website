using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using websitesiprojesi60820222.Models;

namespace websitesiprojesi60820222.MVVM
{
    public class anasayfamodel
    {
    public List<vw_urunler>yeniUrunler { get; set; }
    public List<vw_urunler> sliderUrunler { get; set; }
    public vw_urunler gunun_urunu { get; set; }
    public List<vw_urunler> ozelUrunler { get; set; }
    public List<vw_urunler> indirimliUrunler { get; set; }
    public List<vw_urunler> onecikanUrunler { get; set; }
    public List<vw_urunler> coksatanUrunler { get; set; }
    public List<vw_urunler> firsatUrunler { get; set; }
    public List<vw_urunler> yildizliUrunler { get; set; }
        
    }
}