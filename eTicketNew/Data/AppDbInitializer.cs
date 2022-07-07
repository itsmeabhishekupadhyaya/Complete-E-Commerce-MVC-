using eTicketNew.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                     {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "",
                            Description = "This is the description of the Cinema"

                        }
                    });
                    context.SaveChanges();

                }
                //Actor
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                    new Actor()
                    {
                        FullName ="Ajay Devgan",
                        ProfilePrictureUrl ="",
                        Bio ="Ajay Devgan is best actor"

                    }
                    });
                    context.SaveChanges();
                }
                //Producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                    {
                        FullName = "Ajay Devgan",
                        ProfilePrictureUrl = "",
                        Bio = "Ajay Devgan is best actor"
                    }

                });

                    context.SaveChanges();

                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                    {
                        Name = "Runway 24",
                        Description = "Drama",
                        Price = 200,
                        ImageUrl="",
                        StartDate =DateTime.Now,
                        EndDate =DateTime.Now.AddDays(30),
                        MovieCategory = MovieCategory.Drama,
                       CinemaId=1,
                       ProducerId=1

                    }

                    });

                    context.SaveChanges();
                }
                //Actor_Movie
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId=1
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
