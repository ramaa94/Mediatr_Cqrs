using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

internal class CreateLeaveTypeValidator : AbstractValidator<CreateLeaveTypeCommand>

{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeValidator(ILeaveTypeRepository LeaveTypeRepository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters");
        RuleFor(p => p.DefaultDays)
.      LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
.      GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");
        RuleFor(p => p)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("already exists");
       this._leaveTypeRepository = LeaveTypeRepository;
    }

    private  Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return  _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
            }
}
