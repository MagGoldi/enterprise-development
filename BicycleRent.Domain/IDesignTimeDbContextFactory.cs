using Microsoft.EntityFrameworkCore;

namespace BicycleRent.Domain;

public interface IDesignTimeDbContextFactory<out TContext> where TContext : DbContext;