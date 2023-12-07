using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment1.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chairman>().HasData(
                    new Chairman
                    {
                        Id = 1,
                        Description = "Here is my Description",
                        Goal = "This is our Goal",
                        PhotoPath = "chairman.png",
                        Mission = "This is my Description",
                        Values = "This is my values",
                        Vision = "Here is our vision",
                        IsMissionSelected = true,
                        IsVisionSelected = true,
                        IsGoalSelected = true,
                        IsValuesSelected = true
                    }
                );
        }
    }
}
