using Smbs.Application.DTOs.CorporateTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Services.Interfaces
{
    public interface ICorporateTrainingService
    {
        Task<int> CreateAsync(CorporateTrainingCreateDto dto);
        Task UpdateAsync(int id, CorporateTrainingUpdateDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<CorporateTrainingGetAllDto>> GetAllAsync();
        Task<CorporateTrainingGetAllDto> GetByIdAsync(int id);

    }
}
