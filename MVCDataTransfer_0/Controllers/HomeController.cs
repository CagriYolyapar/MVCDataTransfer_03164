using MVCDataTransfer_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDataTransfer_0.Controllers
{
    public class HomeController : Controller
    {
        //MVC platformunda Controller icinde global alanda olusturduğunuz degişkenleri bir havuz gibi kullanamazsınız...Cünkü MVC platformunda bir Controller'a istekte bulunmak  demek o Controller'dan instance almak demektir...Instance aldıktan sonra ilgili Action'iniz görevini yapar ve sonra instance Ram'den kaldırılarak size performans kazandırması acısından hafızadan temizlenir...Doalyısıyla aynı Controller'a tekrar istek yapsanız bile  bu Controller'dan yeni bir instance alınacaktır...Dolayısıyla global alanda olusturulan degişkenler yeniden olusturulacaktır...O yüzden bu global alandaki degişkenlerin bir Action tarafından degiştirildiginde sonraki request'lerin o degişkenlerin son degerleri üzerinden işlem yapmasını beklememelisiniz...

        //Bu tarz verileri Action'dan View'a, View'dan Action'a aktarmak olsun, bu tarz verileri tutmamızı gerektiren bir senaryoda Action'dan Action'a veri transferi yapmamız da gerekebilir....Bu durumlarda yardımımıza DataTransfer nesneleri kosar...Data Transfer nesnelerinin amacı veri aktarmaktır...Bu nesneler 3 tanedir...


        //Data Transfer nesneleri potansiyel olarak kompleks tipleri de transfer edebilmelerine ragmen bu nesneleri kullanmayı kompleks tiplerde asla tercih etmeyin... Test edilebilirlikleri yoktur ve kompleks yapıdaki tiplerde performans düsüklügü meydana getirirler...


        //Data Transfer Nesneleri ile veri gönderme yönteminde View'in asla veriyi karsılamasına gerek yoktur...(zaten isteseniz de karsılayamazsınız cünkü sadece model karsılanabilir)

        /*
         
         Data Transfer Nesneleri

        Tüm Data Transfer nesneleri Dynamically typed yazılır...

       1 => ViewData : Sadece Action'dan View'a veri gönderebilen bir nesnenizdir... İcerisindeki degeri object olarak tuttuğundan dolayı kompleks tiplerde unboxing yapmanız gerekecektir...Kendisi(key,value) mantıgında olusturulan bir yapıdır...



        2=> ViewBag : Sadece Action'dan View'a veri gönderbilen bir nesnenizdir...İcerisindeki degeri Dynamic olarak tutar... Yine(key,value) mantıgında olusturulan bir yapıdır... ViewData ile aynı göreve sahip olsa da ondan daha modern bir yapınızdır...


        3=> TempData : Action'dan View'a veri gönderebildigi gibi Action'dan ACtion'a da veri gönderebilen bir DataTransfer nesnenizdir...İcerisindeki degeri object olarak tutar ve yine key, value mantıgında olusturulur...Normal şartlarda fazla performans harcamaması adına tek kullanımlık  bir nesnenizdir....Lakin kullanım süresininz uzatılması mümkündür...

        Her ne kadar bu nesneler kompleks bir tipteki data'yı transfer etme potansiyeline sahip olsalar da kesinlikle bu şekilde kullanımları terci edilmez...Cünkü bu yapıların asıl amacı ilkel tiplerle veya ilkel tip gibi davranan tiplerle calısmaktır...


        Data Transfer nesnelerini kullanara bir View'a veri göndermek kesinlikle Model göndermek deigldir...Model gönderme farklı bir yöntemdir, Data Tarnsfer nesneleri ile veri göndermek ayrı bir yöntemdir...Dolayısıyla Data Transfer nesneleri ile gönderilen verilerin View tarafından karsılanmasına gerek yoktur...
         
         
         */

        //           key, value
        //Dictionary<int,Egitmen> egitmenler  








        public HomeController()
        {

        }
        public ActionResult Index()
        {
            //Key, Value eşlisi demek aslında bir Dictionary yapısı belirtmektir...Dictionary bir koleksiyon yapısıdr...List'ten farklı olarak icerisinde iki tane tip vererek eleman tutmak ister (yani bir elemanı ekleyecekseniz iki tipte deger belirtisiniz...Bu tiplerden ilki elemanın anahtarını belirler(bu anahtar elemana ulasmak icin unique olan bir kimlik degeridir)...İkincisi ise onun degerinin hangi tipte olacagını belirler... Yani Dictionary'nin icinde tuttuğu veri aslında iki degerden olusur...Bu degerlerin tipleri de sizin tarafınızdan belirlenir...Mesela su sekilde bir "Dictionary<int,string>" demek bu Dictionary koleksiyonundaki bir anahtar ve bir value tipi demektir...Bu olusan esin icerisindeki her bir deger sizin Dictionary tanımlarken verdiginiz tiplere sahiptir...

            //Dictionary<int,string> degerler = new Dictionary<int,string>();





            //degerler.Add(34,"İstanbul");


            ViewData["sayi"] = 1;
            ViewData["sayi"] = 4; //Eger aynı anahtara baska bir deger veriyorsak unutmayın ki bir önceki degeri ezeriz...

            TempData["testVerisi"] = new Egitmen
            {
                Isim = "Hakan",
                SoyIsim = "Sahin"
            };
            Egitmen egt = new Egitmen
            {
                Isim = "Fatih",
                SoyIsim = "Gunalp"
            };

            ViewData["egitmen"] = egt;
            return View();
        }

        public ActionResult About()
        {
            //ViewBag dinamik yapıda olan bir tipinizdir...Burada ViewBag'e vereceginiz key siz ViewBag keyword'unu yazıp sonra nokta sembolünü koyduktan sonra ne yazarsanız o olarak algılanır...Dinamik tipte oldugu icin hangi tipte veri geliyorsa kendisini o tipe göre sekillendirir




            ViewBag.Sayi = 5;

            ViewBag.Egitmen = new Egitmen
            {
                Isim = "Cagri",
                SoyIsim = "Yolyapar"
            };

            return View();
        }


        public ActionResult Contact()
        {
            //TempData normal şartlarda 1 kullanımlık olan ve Action'dan ACtion'a da veri gönderebilen bir DataTransfer nesnemizdir...Object tipte veri tutar...


            TempData["sayi"] = 5;
            TempData.Keep("sayi");

            return View();
        }

        public ActionResult TestAction()
        {
            //int a = Convert.ToInt32(TempData["sayi"]);
            return View();
        }
    }
}