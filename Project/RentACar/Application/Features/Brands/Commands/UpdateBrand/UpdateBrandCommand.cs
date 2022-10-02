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

namespace Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand :IRequest<UpdatedBrandDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler:IRequestHandler<UpdateBrandCommand,UpdatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _businessRules;

            public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules businessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<UpdatedBrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {

                await _businessRules.BrandNameCanNotDuplicatedWhenInserted(request.Name);

                Brand brand = _mapper.Map<Brand>(request);
                Brand updatedBrand = await _brandRepository.UpdateAsync(brand);
                UpdatedBrandDto result = _mapper.Map<UpdatedBrandDto>(updatedBrand);
                return result;
            }
        }
    }
}
