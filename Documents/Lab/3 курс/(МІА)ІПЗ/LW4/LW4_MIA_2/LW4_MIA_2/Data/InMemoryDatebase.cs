using LW4_MIA_2.Models;
using System.Collections.Generic;

namespace LW4_MIA_2.Data
{
    public static class InMemoryDatabase
    {
        public static List<Club> Clubs { get; } = new();
        public static List<User> Users { get; } = new();
        public static List<Todo> Todos { get; } = new();
        public static List<Category> Categories { get; } = new();
    }
}
