﻿using JuiceAutomatMachine.Models;

namespace JuiceAutomatMachine.Data
{
    public static class JuiceDbInitializer
    {
        public static void Initialize(JuiceDbContext juiceDbContext)
        {
            juiceDbContext.Database.EnsureCreated();
            if (juiceDbContext.Juices.Any())
            {
                return;
            }

            var juices = new Juice[]
            {
                new Juice(0, "Кленовый сауэр", 25, 15, "drink1.png"),
                new Juice(1, "Манхэттен", 15, 5, "drink2.png"),
                new Juice(2, "Карибское сокровище", 10, 10, "drink3.png"),
                new Juice(3, "Мохито", 30, 3, "drink4.png"),
                new Juice(4, "Кровавая Мэри", 20, 7, "drink5.png"),
                new Juice(5, "Японский урожай", 18, 9, "drink6.png"),
                new Juice(6, "Сказка", 35, 1, "drink7.png"),
                new Juice(7, "Пача Ибица", 40, 12, "drink8.png")
            };
            foreach (var juice in juices)
            {
                juiceDbContext.Add(juice);
            }
            //juiceDbContext.ChangeTracker.Clear();
            juiceDbContext.SaveChanges();
        }
    }
}
