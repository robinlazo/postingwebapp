namespace SocialMedia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class CategorySeed : IEntityTypeConfiguration<Category> {
    public void Configure(EntityTypeBuilder<Category> model)
    {
        model.HasData (
            new Category {Name = "Sports", Description = "Skill which a team competes against another"
            , CategoryID = "sport", FontAwesomeIcon = "fas fa-futbol"},
            new Category {Name = "MMA", Description = "Full contact sport which allows a wide variety of combat sports techniques"
            , CategoryID = "mma", FontAwesomeIcon = "fas fa-skull"},
            new Category {Name = "Food", Description = "Learn how to do the best dishes on your own"
            , CategoryID = "food", FontAwesomeIcon = "fas fa-utensils"},
            new Category {Name = "Politics", Description = "Find the most recent news about politics all over the world"
            , CategoryID = "politic", FontAwesomeIcon = "fas fa-landmark"}
        );
    }
}