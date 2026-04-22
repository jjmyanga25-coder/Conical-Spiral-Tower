using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ConicalSpiralTowerApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public double Radius { get; set; }

        [BindProperty]
        public double Height { get; set; }

        [BindProperty]
        public double K { get; set; }

        [BindProperty]
        public double Omega { get; set; }

        public double Volume { get; set; }

        public void OnPost()
        {
            int n = 1000;
            double dz = Height / n;
            double volume = 0;

            for (int i = 0; i < n; i++)
            {
                double z = i * dz;

                double r = Radius * (1 + K * Math.Sin(Omega * z));

                double area = Math.PI * r * r;

                volume += area * dz;
            }

            Volume = volume;
        }
    }
}