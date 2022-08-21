﻿using MedicalSolutions.BusinessModels.Common;
using MedicalSolutions.BusinessModels.HIS.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.DataAccess.IDAO.HIS.Dictionary
{
    public interface IUserDAO : IBaseDao
    {
        public Task<ResultDto<UserDto>> Inserṭ(UserDto user);
        public Task<ResultDto<UserDto>> Update(UserDto user);
        public Task<ResultDto<Guid>> Delete(Guid userId);
        public Task<ResultDto<List<UserDto>>> GetList();
        public Task<ResultDto<UserDto>> GetById(Guid userId);
    }
}