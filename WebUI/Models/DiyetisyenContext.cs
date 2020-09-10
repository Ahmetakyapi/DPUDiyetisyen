using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class DiyetisyenContext : DbContext
    {
        public DiyetisyenContext() : base("DiyetisyenContext")
        {
        }

        public DbSet<Users> tbUsers { get; set; }
        public DbSet<About> tbAbout { get; set; }
        public DbSet<Contact> tbContact { get; set; }
        public DbSet<ProposalContext> tbProposalContext { get; set; }
        public DbSet<ProposalHeader> tbProposalHeader { get; set; }
        public DbSet<Recipes> tbRecipes { get; set; }
        public DbSet<RecipesContents> tbRecipesContents { get; set; }
        public DbSet<VisitorMessages> tbVisitorMessages { get; set; }

        public DbSet<Article> tbArticle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}