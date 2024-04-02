using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    internal class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(IMapper mapper ,ILeaveTypeRepository LeaveTypeRepository)
        {
            this._mapper = mapper;
            _leaveTypeRepository = LeaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            
            var leaveTypeToDelete = _mapper.Map<Domain.LeaveType>(request);
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);


            return Unit.Value;
        }
    }
}
