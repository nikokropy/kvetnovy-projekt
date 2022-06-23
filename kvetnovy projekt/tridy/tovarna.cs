using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kvetnovy_projekt.Tridy
{
    internal class Tovarna
    {
        Dictionary<string, string> URL = new Dictionary<string, string>()
        {
            {"Model S", "obrazky/TeslaModelS.jpg" },
            {"Model 3", "obrazky/TeslaModel3.jpg"},
            {"Model X", "obrazky/TeslaModelX.jpg" },
            {"Model Y", "obrazky/TeslaModelY.jpg" },
            {"CyberTruck", "obrazky/CyberTruck.jpg" },
        };
        public Tovarna()
        {
            Console.WriteLine("Vítejte v továrně na auta!");
            Console.WriteLine("V nabídce máme:");
            Console.WriteLine("              --------------------------");
            foreach (var predmet in URL)
            {
                Console.WriteLine(predmet.Key);
            }
            Console.WriteLine("--------------");
            Console.WriteLine("1. Chci zobrazit poslední vyrobené auto");
            Console.WriteLine("2. Chci vyrobit nové auto");
        }
        public Auto VytvorAuto()
        {
            Console.Clear();

            Auto vyrobeneAuto = new Auto();
            Console.WriteLine("Zadej model auta:");
            vyrobeneAuto.Model = Console.ReadLine();
            vyrobeneAuto.Obrazek = URL[vyrobeneAuto.Model];
            Console.WriteLine("Zadej počet sedadel:");
            vyrobeneAuto.PocetSedadel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Zadej druh auta:");
            Console.WriteLine("eletrický/hybridní");
            vyrobeneAuto.DruhPohonu = Console.ReadLine();
            Console.WriteLine("Zadejte cenu:      (des. čísla = čárka");
            vyrobeneAuto.Cena = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Chcete zobrazit vámi vytvořené auto? y/n");
            return vyrobeneAuto;
        }
        public void VytvorStranku(Auto vyrobeneAuto)
        {
            string html = $@"
            <html>
            <body>
            <h1>Tovarna na auta</h1>
            <h2 style='color: blue;'>{vyrobeneAuto.Znacka}</h2> 
            <h2>{vyrobeneAuto.Model}</h2>
            <h2>Počet sedaček: {vyrobeneAuto.PocetSedadel}</h2> 
            <h2>Druh pohonu: {vyrobeneAuto.DruhPohonu}</h2> 
            <img src='{vyrobeneAuto.Obrazek}' width='600px'>
            <h3>Rok výroby: {vyrobeneAuto.RokVyroby}</h3>
            <hr>
            <div>
                Cena: <h4 style='color: black;'>{vyrobeneAuto.Cena}</h4> 
            </div>
            </body>
            </html>";
            File.WriteAllText("index.html", html);
        }
        public void ZobrazStranku(string adresaSouboru)
        {
            var process = new System.Diagnostics.ProcessStartInfo();
            process.UseShellExecute = true;
            process.FileName = adresaSouboru;
            System.Diagnostics.Process.Start(process);
        }
    }


}
