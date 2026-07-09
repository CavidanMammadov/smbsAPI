using Microsoft.AspNetCore.Routing;
using Smbs.Application.DTOs.CorporateTraining;
using Smbs.Application.Services.Interfaces;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Services.implements
{
    public class CorporateTrainingService(ICorporateTrainingRepository _repo) : ICorporateTrainingService
    {
        public async Task<int> CreateAsync(CorporateTrainingCreateDto dto)
        {
            var data = new CorporateTraining
            {
                CorporateTrainingCompanyName = dto.CorporateTrainingCompanyName,
                CorporateTrainingPosition = dto.CorporateTrainingPosition,
                CorporateTrainingDirection = dto.CorporateTrainingDirection,
                CorporateTrainingSchedule = dto.CorporateTrainingSchedule,
                CorporateTrainingContactInfo = dto.CorporateTrainingContactInfo,
                CorporateTrainingEmployeeCount = dto.CorporateTrainingEmployeeCount,
                CorporateTrainingContractDate = dto.CorporateTrainingContractDate
            };
            await _repo.Create(data);
            return data.CorporateTrainingId;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _repo.GetById(id);
            if (data is null)
                throw new DirectoryNotFoundException("Bu id-li data yoxdur");
            await _repo.Delete(data);
        }

        public async Task<IEnumerable<CorporateTrainingGetAllDto>> GetAllAsync()
        {
            var data = await _repo.GetAll();
            return data.Select(x => new CorporateTrainingGetAllDto
            {

                CorporateTrainingId = x.CorporateTrainingId,

                CorporateTrainingCompanyName =
                x.CorporateTrainingCompanyName,

                CorporateTrainingPosition =
                x.CorporateTrainingPosition,

                CorporateTrainingDirection =
                x.CorporateTrainingDirection,

                CorporateTrainingSchedule =
                x.CorporateTrainingSchedule,

                CorporateTrainingContactInfo =
                x.CorporateTrainingContactInfo,

                CorporateTrainingEmployeeCount =
                x.CorporateTrainingEmployeeCount,

                CorporateTrainingContractDate =
                x.CorporateTrainingContractDate,

                CorporateTrainingCreatedAt =
                x.CorporateTrainingCreatedAt,

                CorporateTrainingIsActive =
                x.CorporateTrainingIsActive
            });

        }

        public async Task<CorporateTrainingGetAllDto> GetByIdAsync(int id)
        {
            var entity = await _repo.GetById(id);
            if (entity is null)
                throw new DirectoryNotFoundException("bu id-li data yoxdur");
            return new CorporateTrainingGetAllDto
            {
                CorporateTrainingId = entity.CorporateTrainingId,
                CorporateTrainingCompanyName =
                    entity.CorporateTrainingCompanyName,

                CorporateTrainingPosition =
                    entity.CorporateTrainingPosition,

                CorporateTrainingDirection =
                    entity.CorporateTrainingDirection,

                CorporateTrainingSchedule =
                    entity.CorporateTrainingSchedule,

                CorporateTrainingContactInfo =
                    entity.CorporateTrainingContactInfo,

                CorporateTrainingEmployeeCount =
                    entity.CorporateTrainingEmployeeCount,

                CorporateTrainingContractDate =
                    entity.CorporateTrainingContractDate,

                CorporateTrainingCreatedAt =
                    entity.CorporateTrainingCreatedAt,

                CorporateTrainingIsActive =
                    entity.CorporateTrainingIsActive
            };

        }

        public async Task UpdateAsync(int id, CorporateTrainingUpdateDto dto)
        {
            var entity = await _repo.GetById(id);
            if (entity is null) throw new DirectoryNotFoundException("bu id-li data tapilmadi");


            entity.CorporateTrainingCompanyName =
               dto.CorporateTrainingCompanyName;

            entity.CorporateTrainingPosition =
                dto.CorporateTrainingPosition;

            entity.CorporateTrainingDirection =
                dto.CorporateTrainingDirection;

            entity.CorporateTrainingSchedule =
                dto.CorporateTrainingSchedule;

            entity.CorporateTrainingContactInfo =
                dto.CorporateTrainingContactInfo;

            entity.CorporateTrainingEmployeeCount =
                dto.CorporateTrainingEmployeeCount;

            entity.CorporateTrainingContractDate =
                dto.CorporateTrainingContractDate;

            entity.CorporateTrainingIsActive =
                dto.CorporateTrainingIsActive;
            await _repo.Update(entity);



        }
    }
}
