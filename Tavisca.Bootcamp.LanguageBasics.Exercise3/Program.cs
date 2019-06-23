using System;
using System.Linq;
using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            int[] dietResult = new int[dietPlans.Length];
            int[] calories = new int[protein.Length];

            /* Computing calories for each index */
            for (int i = 0; i < protein.Length; i++)
                 calories[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9; 

               for (int i = 0; i < dietPlans.Length; i++)
            {
                 List<int> first = new List<int>();
                 
                 for(int k=0;k<protein.Length;k++)
                     first.Add(k);
                   
                 string diet = dietPlans[i];
                
                 if(diet=="") dietResult[i]=0;
                 else 
                 {
                    for(int j=0;j<diet.Length;j++)
                    {    
                        if(diet[j]=='P')
                         { 
                          first = makeNewListMAX(protein,first);
                         }
                       else if(diet[j]=='p')
                         {
                          first = makeNewListMIN(protein,first);
                         }
                       else if(diet[j]=='C')
                         {
                           first = makeNewListMAX(carbs,first);
                         }
                       else if(diet[j]=='c')
                         {
                           first = makeNewListMIN(carbs,first);
                         }
                       else if(diet[j]=='F')
                         {
                           first = makeNewListMAX(fat,first);
                         }
                       else if(diet[j]=='f')
                         {
                           first = makeNewListMIN(fat,first);
                         }
                       else if(diet[j]=='T')
                         {
                           first = makeNewListMAX(calories,first);
                         }
                       else if(diet[j]=='t')
                         {
                           first = makeNewListMIN(calories,first);
                         } 
                     }
                 }
           
                  dietResult[i] = first[0];
            }
              return dietResult;
             throw new NotImplementedException();
        }
       
       /* Computing list for max */
       public static List<int> makeNewListMAX(int[] item, List<int> first)
        {
            int element = item[first[0]];
            List<int> newList = new List<int>();
            for(int i =1;i<first.Count;i++)
                 if(element<item[first[i]])
                     element = item[first[i]];    
            
            foreach(int i in first)
                 if(item[i]==element) 
                  newList.Add(i);
            return newList;
        }
        /* Computing list for min */
       public static List<int> makeNewListMIN(int[] item, List<int> first)
        {
            int element = item[first[0]];
            List<int> newList = new List<int>();
            for(int i =1;i<first.Count;i++)
                 if(element>item[first[i]])
                     element = item[first[i]];    
            
            foreach(int i in first)
                 if(item[i]==element) 
                  newList.Add(i);
            return newList;
        }       
    }
}
