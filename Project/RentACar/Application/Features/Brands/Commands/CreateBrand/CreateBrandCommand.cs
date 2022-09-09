using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreateedBrandDto>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _businessRules;
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper,BrandBusinessRules businessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateedBrandDto> Handle(CreateBrandCommand createBrandCommand,
                CancellationToken cancellationToken)
            {
                await _businessRules.BrandNameCanNotDuplicatedWhenInserted(createBrandCommand.Name);
                Brand mappedBrand = _mapper.Map<Brand>(createBrandCommand);
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);
                CreateedBrandDto createdBrandDto = _mapper.Map<CreateedBrandDto>(createdBrand);
                return createdBrandDto;
            }
        }
    }
}