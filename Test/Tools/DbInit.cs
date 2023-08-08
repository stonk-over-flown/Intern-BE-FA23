using Test.Entity;

namespace Test.Tools
{
    public static class DbInit
    {
        public static async Task Initialize(AppDbContext dbContext)
        {
            if (!dbContext.Cards.Any())
            {
                var cards = new List<CardEntity>()
                {
                    new CardEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CardName = "Test",
                        Condition = "New",
                        Description = "This is a test product.",
                        Price = 1000000,
                        Discount = 10,
                        IsActive = true
                    },
                    new CardEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CardName = "Anyone Worldwide",
                        Condition = "Used",
                        Description = "This is a test product.",
                        Price = 1500000,
                        Discount = 20,
                        IsActive = false
                    },
                    new CardEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CardName = "Fontaine Holo",
                        Condition = "New",
                        Description = "This is a test product.",
                        Price = 2000000,
                        Discount = 30,
                        IsActive = true
                    }
                };

                foreach (var card in cards)
                {
                    await dbContext.Cards.AddAsync(card);
                }
            }

            if (!dbContext.Users.Any())
            {
                var users = new List<UserEntity>()
                {
                    new UserEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Username = "testuser123",
                        Password = "password",
                        Address = "123 freddy fazbear",
                        FirstName = "Test",
                        LastName = "User",
                        Email = "testuser123@gmail.com",
                        IsActive = true
                    },
                    new UserEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Username = "500bros",
                        Password = "password",
                        Address = "test",
                        FirstName = "Lmao",
                        LastName = "xd",
                        Email = "teamgrimore@gmail.com",
                        IsActive = false
                    },
                    new UserEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Username = "palmer",
                        Password = "jesus",
                        Address = "123 lamo, san andreas",
                        FirstName = "jupiter",
                        LastName = "lodge",
                        Email = "faketaxi123@test.com",
                        IsActive = true
                    },
                };
                
                foreach(var user in users)
                {
                    await dbContext.Users.AddAsync(user);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
