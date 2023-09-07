﻿using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<TeacherRepository> _logger;

        public TeacherRepository(RepositoryContext context, ILogger<TeacherRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<bool> AddTeacher(Teacher teacher)
        {
            try
            {
                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }  
        }

        public async Task<bool> DeleteTeacher(string id)
        {
            var teacherToDelete = await GetTeacherById(id);
            if(teacherToDelete != null)
            {
                _context.Teachers.Remove(teacherToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(string id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<bool> UpdateTeacher(string id, Teacher teacher)
        {
            var teacherToUpdate = await GetTeacherById(id);
            if(teacherToUpdate != null)
            {
                teacherToUpdate.Name = teacher.Name ?? teacherToUpdate.Name;
                teacherToUpdate.Surname = teacher.Surname ?? teacherToUpdate.Surname;
                teacherToUpdate.TeacherNumber = teacher.TeacherNumber ?? teacherToUpdate.TeacherNumber;
                teacherToUpdate.NationalIdNumber = teacher.NationalIdNumber ?? teacherToUpdate.NationalIdNumber;
                teacherToUpdate.Salary = teacher.Salary == 0 ? teacherToUpdate.Salary : teacher.Salary;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
