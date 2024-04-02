using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeValidator:AbstractValidator<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeValidator(ILeaveTypeRepository LeaveTypeRepository)
        {
            RuleFor(p => p.Id)
                .NotNull();
            this._leaveTypeRepository = LeaveTypeRepository;
        }
    }
}
