﻿using MG_HR.DATA.Entity.Address;

namespace HR.Service.Abstracts.Address
{
    public interface ICityServices
    {
        public Task<List<City>> GetCityListAsync();
        //public Task<Student> GetStudentByIDWithIncludeAsync(int id);
        //public Task<Student> GetByIDAsync(int id);
        //public Task<string> AddAsync(Student student);
        //public Task<bool> IsNameArExist(string nameAr);
        //public Task<bool> IsNameEnExist(string nameEn);
        //public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        //public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        //public Task<string> EditAsync(Student student);
        //public Task<string> DeleteAsync(Student student);
        //public IQueryable<Student> GetStudentsQuerable();
        //public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID);
        //public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);

    }
}
