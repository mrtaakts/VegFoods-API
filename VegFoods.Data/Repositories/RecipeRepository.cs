﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;

namespace VegFoods.Data.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        protected readonly AppDbContext _context;
        public RecipeRepository(AppDbContext dbContext):base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Recipe>> GetAllWithIngredientsAsync()
        {
           // return await _context.Recipes.Include(a => a.Ingredients).ToListAsync();
           throw new NotImplementedException();
        }


        public async Task<Recipe> GetByIdAsync(int id)
        {
            // return await _context.Recipes.Include(a => a.Ingredients).SingleOrDefaultAsync(a => a.Id == id);
            throw new NotImplementedException();
        }

        public async Task<Recipe> GetWithIngreById(int Recipeid)
        {
           var deneme = await _context.Recipes
                .Include(a => a.RecipeIngredients)
                .ThenInclude(x => x.Ingredient)
                .Where(x => x.Id == Recipeid)
                .FirstOrDefaultAsync();
            return deneme;
        }

        Task<IEnumerable<Recipe>> IRecipeRepository.GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

      

        
    }
}
