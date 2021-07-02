// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Newtonsoft.Json;


// namespace LinkDogs
// {
//   public static class Seeder
//   {
//     public static void Seedit(string jsonData,
//                               IServiceProvider serviceProvider)
//     {
//       JsonSerializerSettings settings = new JsonSerializerSettings
//       {
//         ContractResolver = new PrivateSetterContractResolver()
//       };
//       List<dogData> dogs =
//        JsonConvert.DeserializeObject<List<dogData>>(
//          jsonData, settings);
//       using (
//        var serviceScope = serviceProvider
//          .GetRequiredService<IServiceScopeFactory>().CreateScope())
//       {
//         var context = serviceScope
//                       .ServiceProvider.GetService<DbContext>();
//         if (!context.dogData.Any())
//         {
//           context.AddRange(dogs);
//           context.SaveChanges();
//         }
//       }
//     }
//   }
// }