using System;
using System.Collections.Generic;
using System.Data.Entity;
using TextParsingClient.DB.entities;

namespace TextParsingClient.DB
{
    public class DBInitializer : CreateDatabaseIfNotExists<ParsingDBContext>
    {
        protected override void Seed(ParsingDBContext context)
        {
            Console.WriteLine("Initializing database...");
            InputText first = new InputText { ID = 1, Text = "OneWord" };
            InputText second = new InputText { ID = 2, Text = "two words" };
            InputText third = new InputText { ID = 3, Text = "four words from database" };
            context.InputText.Add(first);
            context.InputText.Add(second);
            context.InputText.Add(third);
            context.SaveChanges();
            base.Seed(context);
            Console.WriteLine("database created and seeded");
        }
    }
}
