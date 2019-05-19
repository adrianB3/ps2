using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class DataService: IDataService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DataService(IDataRepository dataRepository, IUnitOfWork unitOfWork)
        {
            _dataRepository = dataRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Data>> ListAsync()
        {
            return await _dataRepository.ListAsync();
        }

        public async Task<SaveDataResponse> SaveAsync(Data data)
        {
            try
            {
                await _dataRepository.AddAsync(data);
                await _unitOfWork.CompleteAsync();
			
                return new SaveDataResponse(data);
            }
            catch (Exception ex)
            {
                return new SaveDataResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}