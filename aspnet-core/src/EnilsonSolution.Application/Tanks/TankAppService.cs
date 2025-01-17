using System;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace EnilsonSolution.Tanks
{
    using Dto;
    using Abp.UI;

    [AbpAuthorize]
    public class TankAppService : AsyncCrudAppService<Tank, TankDto, string, PagedTankResultRequestDto, CreateTankDto, TankDto>, ITankAppService
    {
        public TankAppService(IRepository<Tank, string> tankRepository)
            : base(tankRepository)
        {
        }

        public async Task<TankDto> CreateTankAsync(CreateTankDto input)
        {

            var existingTank = await Repository.FirstOrDefaultAsync(t => t.Deposit == input.Deposit);

            if (existingTank != null)
            {

                if (existingTank.IsDeleted)
                {
                    await Repository.DeleteAsync(existingTank);
                }
                else
                {
                    throw new UserFriendlyException($"Um tanque com a descrição '{input.Deposit}' já existe.");
                }
            }

            if (string.IsNullOrWhiteSpace(input.Deposit))
            {
                throw new UserFriendlyException("O campo 'Deposito' não pode estar vazio.");
            }

            var tank = ObjectMapper.Map<Tank>(input);
            await Repository.InsertAsync(tank);

            return ObjectMapper.Map<TankDto>(tank);
        }

        public async Task<TankDto> GetByIdAsync(string id)
        {
            var tank = await Repository.FirstOrDefaultAsync(t => t.Deposit == id);

            if (tank == null)
            {
                throw new UserFriendlyException($"Tanque com o depósito '{id}' não encontrado.");
            }

            return ObjectMapper.Map<TankDto>(tank);
        }

        public async Task DeleteTankAsync(string deposit)
        {
            var tank = await Repository.FirstOrDefaultAsync(t => t.Deposit == deposit);

            if (tank == null)
            {
                throw new ArgumentException($"Tanque com a descrição '{deposit}' não encontrado.");
            }

            tank.IsDeleted = true;

            await Repository.UpdateAsync(tank);

            await Repository.DeleteAsync(tank);
        }

        public async Task<TankDto> UpdateTankAsync(string deposit, CreateTankDto input)
        {
            var tank = await Repository.FirstOrDefaultAsync(t => t.Deposit == deposit);

            if (tank == null)
            {
                throw new UserFriendlyException($"Tanque com a descrição '{deposit}' não encontrado.");
            }

            if (string.IsNullOrWhiteSpace(input.Deposit))
            {
                throw new UserFriendlyException("O campo 'Deposito' não pode estar vazio.");
            }

            var existingTank = await Repository.FirstOrDefaultAsync(t => t.Deposit == input.Deposit && t.Id != tank.Id);

            if (existingTank != null)
            {
                throw new UserFriendlyException($"Já existe um tanque com descrição '{input.Deposit}'.");
            }

            tank.Deposit = input.Deposit;
            tank.IsDeleted = input.IsDeleted;
            tank.Capacity = input.Capacity;
            tank.ProductType = input.ProductType;

            await Repository.UpdateAsync(tank);

            return ObjectMapper.Map<TankDto>(tank);
        }

    }
}
