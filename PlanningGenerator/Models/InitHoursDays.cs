using PlanningGenerator.Models.Pln;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningGenerator.Models
{
    public class InitHoursDays
    {
        public static async Task Initialize(PlnContext ctx)
        {
            ctx.Database.EnsureCreated();

            //Init des heures
            List<Hour> h = new List<Hour>();
            List<DateTime> dt = new List<DateTime>();

            for (int i = 0; i <= 23; i++)
            {
                for (int y = 0; y <= 30; y = y + 30)
                {
                    dt.Add(new DateTime(1, 1, 1, i, y, 0));

                }

            }

            for (int i = 0; i < h.Count; i++)
            {
                Console.WriteLine($"ID:{h[i].Id} , Heure:{h[i]._hour} , Minutes{h[i]._minutes} Total:{h[i]._hms}");

            }

            foreach (var v in dt)
            {
                //Console.WriteLine($"{v.ToShortTimeString()}");
                h.Add(new Hour
                {
                    Id = v.ToShortTimeString(),
                    _hour = v.Hour,
                    _minutes = v.Minute,
                    _hms = v.Hour + "h" + v.Minute
                });
            }

            var defaultHours = ctx.Hour.ToList();
            if(defaultHours.Count != h.Count)
            {
                for(int i = 0; i < h.Count; i++)
                {        
                    await ctx.Hour.AddAsync(h[i]);
                }
                
            }

            ctx.SaveChanges();

            //Liste des jours
            List<Day> days = new List<Day>();
            string[] fr = new string[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            string[] en = new string[] { "Monday", "Tuesday", "Wednesday", "Thurday", "Friday", "Saturday", "Sunday" };

            for (int i = 1; i <= fr.Length; i++)
            {
                days.Add(new Day
                {
                    Id = i,
                    Fr = fr[i - 1],
                    En = en[i - 1]
                });


            }

            foreach (var d in days)
            {
                Console.WriteLine($"Day id:{d.Id} , fr:{d.Fr} , En:{d.En}");
            }

            List<Day> dayDefault = ctx.Day.ToList();

            if (dayDefault.Count != days.Count)
            {
                for (int i = 0; i < days.Count; i++)
                {
                    await ctx.Day.AddAsync(days[i]);
                }
            }
            ctx.SaveChanges();
        }
    }
}
