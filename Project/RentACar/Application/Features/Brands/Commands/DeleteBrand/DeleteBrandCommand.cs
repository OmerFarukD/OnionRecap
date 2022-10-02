using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand :IRequest<DeletedBrandDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _businessRules;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules businessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<DeletedBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand brand = _mapper.Map<Brand>(request);
                Brand deletedBrand = await _brandRepository.DeleteAsync(brand);
                DeletedBrandDto result = _mapper.Map<DeletedBrandDto>(deletedBrand);
                return result;
            }
        }
    }
}
