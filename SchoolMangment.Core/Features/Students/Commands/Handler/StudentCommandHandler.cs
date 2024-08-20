using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Students.Commands.Models;
using SchoolMangment.Core.Features.Students.Queries.Models;
using SchoolMangment.Core.Resurses;
using SchoolMangment.Data.Entities;
using SchoolMangment.Services.Abstracts;

namespace SchoolMangment.Core.Features.Students.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<CreateStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>
    {

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public StudentCommandHandler(IStudentService studentService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> stringLocalizer)
                                     : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);

            var result = await _studentService.CreateAsync(student);

            // Update this
            if (result == "Exist")
                return UnprocessableEntity<string>("Name is Exist");

            return Created("Added Succeessfuly");

        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist or not 
            var student = await _studentService.GetByIdAsync(request.Id);

            if (student == null)
                return NotFound<string>("Student is not found");

            //mapping Between request and student
            var studentMapper = _mapper.Map(request, student);

            //Call Service that make Edit
            var result = await _studentService.EditAsync(studentMapper);

            if (result != "Succees")
                return BadRequest<string>();


            return Success($"Edit Successfuly{studentMapper.Id}");
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist or not 
            var student = await _studentService.GetByIdAsync(request.Id);

            if (student == null)
                return NotFound<string>("Student is not found");

            //Call Service that make Delete
            var result = await _studentService.DeleteAsync(student);

            if (result != "Succees")
                return BadRequest<string>();

            return Deleted<string>($"Delete Successfuly{student.Id}");
        }
    }
}
