using CunDropShipping_Shipments.domain.Entity;
using CunDropShipping_Shipments.infrastructure.Entity;
using CunDropShipping_Shipments.infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace CunDropShipping_Shipments.infrastructure.DbContext;

public class Repository
{
    
    private readonly AppDbContext _appDbContext;
    private readonly IInfrastructureMapper _mapper;
    
    public Repository(AppDbContext appDbContext, IInfrastructureMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }
}