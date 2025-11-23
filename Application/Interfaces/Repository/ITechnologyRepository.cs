using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface ITechnologyRepository
    {
        //create
        Task<Technologies> CreateTechnologyAsync(Technologies technology);
        //read
        Task<Technologies?> GetTechnologyByIdAsync(int id);
        //update
        Task<Technologies> UpdateTechnologyAsync(Technologies technology);
        //delete
        Task<bool> DeleteTechnologyAsync(Technologies technology);


    }
}
