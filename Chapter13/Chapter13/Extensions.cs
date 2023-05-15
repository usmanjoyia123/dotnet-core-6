using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13
{
    public static class Extensions
    {
        public static List<Car> GetAllData(this Car car, List<Car> data) {
            var subset = (from g in data select (g)).OrderBy(x => x.PetName).TakeWhile(x => x.Speed >= 120);
            //Explore ranges (..3) taking first three
            // (3..) skipping last three, (^2..) taking last two, (..^2) skipping last two
            //Explore SkipWhile(), SkipLast(), Skip()
            return  subset.ToList<Car>(); 
        }

        // let's get name and make using extension method

        public static Array GetProjectedSubset(this Car c, List<Car> cars)
        {
            ///var query = cars.Select(i => new  { i.PetName, i.Make }).OrderBy(x => x.PetName);
            //int count = query.Count();
            var query = from value in (from g in cars select  new { Name = g.PetName, Color = g.Color }) select value; 
            query.TryGetNonEnumeratedCount(out int count_);
            // do it in more LINQeyy Method!!
            Console.WriteLine($"Total results are: {count_}");
            return query.ToArray();    
        }

        public static List<Car> DisplayDiff(this Car car, List<Car> l1, List<Car>l2)
        
        {
            var query = (from g in l1 where g.Color == "White" select g).Except (from g in l2 where g.Speed>=120 select g);
            return query.ToList<Car>();

            //similary Union, Intersect, Concat
        }
    }
}
