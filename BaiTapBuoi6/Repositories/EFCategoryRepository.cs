﻿using BaiTapBuoi6.Models;
using BaiTapBuoi6.Repositories;
using Microsoft.EntityFrameworkCore;

public class EFCategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public EFCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Tương tự như EFProductRepository, nhưng cho Category
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

}