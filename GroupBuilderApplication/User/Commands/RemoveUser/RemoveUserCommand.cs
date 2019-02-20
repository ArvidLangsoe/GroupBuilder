using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveUser
{
    public class RemoveUserCommand : IRemoveUserCommand
    {

        private readonly IUserRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public RemoveUserCommand(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Execute(int userId)
        {
            var userToRemove = _repository.Get(userId);

            _repository.Remove(userToRemove);

            _unitOfWork.Save();

        }
    }
}
