using System;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace EnilsonSolution.Tanks
{
    using Dto;

    [AbpAuthorize]
    public class TankAppService : AsyncCrudAppService<Tank, TankDto, string, PagedTankResultRequestDto, CreateTankDto, TankDto>, ITankAppService
    {
        public TankAppService(IRepository<Tank, string> tankRepository)
            : base(tankRepository)
        {
        }

        public async Task<TankDto> CreateTankAsync(CreateTankDto input)
        {
  
            if (string.IsNullOrWhiteSpace(input.Deposito))
            {
                throw new ArgumentException("O campo 'Deposito' não pode estar vazio.");
            }

            if (await Repository.FirstOrDefaultAsync(t => t.Deposito == input.Deposito) != null)
            {
                throw new ArgumentException($"Um tanque com o depósito '{input.Deposito}' já existe.");
            }

            var tank = ObjectMapper.Map<Tank>(input);

            await Repository.InsertAsync(tank);

            return ObjectMapper.Map<TankDto>(tank);
        }

        public async Task<TankDto> GetByIdAsync(string id)
        {
            var tank = await Repository.FirstOrDefaultAsync(t => t.Deposito == id);

            if (tank == null)
            {
                throw new ArgumentException($"Tanque com o depósito '{id}' não encontrado.");
            }

            return ObjectMapper.Map<TankDto>(tank);
        }
    }
}
