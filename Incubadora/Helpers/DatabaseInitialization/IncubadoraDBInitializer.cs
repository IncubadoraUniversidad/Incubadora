using Incubadora.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Incubadora.Helpers.DatabaseInitialization
{
    public class IncubadoraDBInitializer : CreateDatabaseIfNotExists<IncubadoraDataBaseEntities>
    {
        public IncubadoraDBInitializer()
        {
            var olv = 1;
        }
        protected override void Seed(IncubadoraDataBaseEntities context)
        {
            var avatars = context.CatAvatars.Count();
            base.Seed(context);
        }
    }
}