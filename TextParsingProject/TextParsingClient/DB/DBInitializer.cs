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
            InputText first = new InputText { ID = 1, Text = "OneWord" };
            InputText second = new InputText { ID = 2, Text = "two words" };
            context.InputText.Add(first);
            context.InputText.Add(second);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
