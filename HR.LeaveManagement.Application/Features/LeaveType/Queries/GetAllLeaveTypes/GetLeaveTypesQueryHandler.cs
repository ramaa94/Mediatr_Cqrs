using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{// in handler specify the request we're handling and datatype
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        //dependency injection
        public GetLeaveTypesQueryHandler(IMapper mapper,ILeaveTypeRepository LeaveTypeRepository)
        {
            this._mapper = mapper;
            _leaveTypeRepository = LeaveTypeRepository;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //what we did 
            // query db,
            var leaveTypes = await _leaveTypeRepository.GetAsync();
            // convert data objs to dto objs,
           var data= _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            // return list of dto objects
            return data;
        }
    }
}
