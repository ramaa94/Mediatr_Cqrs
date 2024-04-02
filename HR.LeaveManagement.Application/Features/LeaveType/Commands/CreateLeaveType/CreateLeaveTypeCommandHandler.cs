using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        //injection we need repository
        public CreateLeaveTypeCommandHandler(IMapper mapper , ILeaveTypeRepository LeaveTypeRepository)
        {
            this._mapper = mapper;
            _leaveTypeRepository = LeaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateLeaveTypeValidator(_leaveTypeRepository);
            var validationRes=await validator.ValidateAsync(request);
            //if (validationRes.Errors.Any()) 
            if (!validationRes.IsValid)
                throw new BadRequestException("Invalid type", validationRes) ;
            //convert to domain entity obj
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
            //add to db 

            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            // return record
            return leaveTypeToCreate.Id;
        }
    }
}
